using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PoqketNote
{
    public partial class FileListPage : PhoneApplicationPage
    {
        public FileListPage()
        {
            InitializeComponent();
        }

        public string flmessage;
        private FileList fl = null;

        private void Load()
        {

            IsolatedStorageFile storage = null;
            fl = new FileList();
            //try
            //{
            storage = IsolatedStorageFile.GetUserStoreForApplication();
            //string[] d = storage.GetDirectoryNames();
            string[] filearray = storage.GetFileNames();
            List<string> ls = new List<string>(filearray);
            ls.Remove("__ApplicationSettings");
            //string[] s;
            //s = d;
            filearray = ls.ToArray();
            if (filearray.Length > 0)
            {
                foreach (var f in filearray)
                {
                    //DateTime dt = File.GetLastWriteTime();
                    FileData fd = new FileData();
                    //fd.Updated = dt;
                    fd.FileName = f;
                    fl.Files.Add(fd);
                }
                flmessage = "ファイルを選択してください";
            }
            else
            {
                flmessage = "ファイルがありません";
            }
            listBox1.DataContext = fl;
            msgtext1.Text = flmessage;
            //msgtext1.Visibility = Visibility.Visible;
            //}
            //catch(Exception ex)
            //{
            //MessageBox.Show(ex.ToString());

            //}
            //finally
            //{

            //}

        }
        private void listBox1_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FileData fd = (FileData)listBox1.SelectedItem;
            if (fd != null)
            {

                ApplicationBar = new ApplicationBar();

                ApplicationBarIconButton editbtn = new ApplicationBarIconButton();
                editbtn.IconUri = new Uri("/icons/appbar.edit.rest.png", UriKind.Relative);
                editbtn.Text = "編集";
                ApplicationBar.Buttons.Add(editbtn);
                editbtn.Click += new EventHandler(EditButton_Click);

                ApplicationBarIconButton deletebtn = new ApplicationBarIconButton();
                deletebtn.IconUri = new Uri("/icons/appbar.delete.rest.png", UriKind.Relative);
                deletebtn.Text = "削除";
                ApplicationBar.Buttons.Add(deletebtn);
                deletebtn.Click += new EventHandler(DeleteButton_Click);

                //NavigationService.Navigate(new Uri("/MainPage.xaml?path=" + fd.FileName, UriKind.Relative));
            }
            else
            {
                ApplicationBar.Buttons.Clear();
            }

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            FileData fd = (FileData)listBox1.SelectedItem;
            if (fd != null)
            {
                IsolatedStorageSettings appstore = IsolatedStorageSettings.ApplicationSettings;
                appstore["command"] = "edit";
                appstore["filename"] = fd.FileName;
                NavigationService.GoBack();
                //NavigationService.Navigate(new Uri("/MainPage.xaml?path=" + fd.FileName, UriKind.Relative));
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            FileData fd = (FileData)listBox1.SelectedItem;
            if (fd != null)
            {
                IsolatedStorageFile storage = null;

                storage = IsolatedStorageFile.GetUserStoreForApplication();

                if (storage.FileExists((fd.FileName)))
                {
                    MessageBoxResult r;
                    r = MessageBox.Show("本当にファイルを削除しますか?", "削除確認", MessageBoxButton.OKCancel);
                    if (r == MessageBoxResult.Cancel)
                    {
                        return;
                    }

                    storage.DeleteFile(fd.FileName);

                    MessageBox.Show("ファイルを削除しました", "削除成功", MessageBoxButton.OK);

                    fl.Files.RemoveAt(listBox1.SelectedIndex);
                    //listBox1.UpdateLayout();
                    Load();
                    //NavigationService.Navigate(new Uri("/FileListPage.xaml?", UriKind.Relative));

                }
            }
        }
        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            IsolatedStorageSettings appstore = IsolatedStorageSettings.ApplicationSettings;
            appstore["command"] = "back";
            appstore["filename"] = "-";
            base.OnBackKeyPress(e);
        }
    }
}