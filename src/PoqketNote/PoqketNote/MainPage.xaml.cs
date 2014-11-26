using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
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
    public partial class MainPage : PhoneApplicationPage
    {
        // コンストラクター
        public MainPage()
        {
            InitializeComponent();
        }

        private void scrollview1_KeyDown(object sender, KeyEventArgs e)
        {
            scrollview1.ScrollToVerticalOffset(scrollview1.VerticalOffset + 60);
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton savebtn = new ApplicationBarIconButton();
            savebtn.IconUri = new Uri("/icons/appbar.save.rest.png", UriKind.Relative);
            savebtn.Text = "保存";
            ApplicationBar.Buttons.Add(savebtn);
            savebtn.Click += new EventHandler(SaveButton_Click);

            ApplicationBarIconButton loadbtn = new ApplicationBarIconButton();
            loadbtn.IconUri = new Uri("/icons/appbar.list.rest.png", UriKind.Relative);
            loadbtn.Text = "開く";
            ApplicationBar.Buttons.Add(loadbtn);
            loadbtn.Click += new EventHandler(LoadButton_Click);
            /*
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = false;
             */
        }

        private void TextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBlock_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void mainTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton hidekeybtn = new ApplicationBarIconButton();
            hidekeybtn.IconUri = new Uri("/icons/appbar.download.rest.png", UriKind.Relative);
            hidekeybtn.Text = "キーボードを閉じる";
            ApplicationBar.Buttons.Add(hidekeybtn);
            hidekeybtn.Click += new EventHandler(HideKeyButton_Click);
            /*
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = true;
            */
        }

        private void mainTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton savebtn = new ApplicationBarIconButton();
            savebtn.IconUri = new Uri("/icons/appbar.save.rest.png", UriKind.Relative);
            savebtn.Text = "保存";
            ApplicationBar.Buttons.Add(savebtn);
            savebtn.Click += new EventHandler(SaveButton_Click);

            ApplicationBarIconButton loadbtn = new ApplicationBarIconButton();
            loadbtn.IconUri = new Uri("/icons/appbar.list.rest.png", UriKind.Relative);
            loadbtn.Text = "開く";
            ApplicationBar.Buttons.Add(loadbtn);
            loadbtn.Click += new EventHandler(LoadButton_Click);
            /*
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = false;
            */
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (filenameTextBox.Text == "")
            {
                MessageBox.Show("ファイル名が入力されていません");
                return;
            }

            IsolatedStorageFile storage = null;
            IsolatedStorageFileStream stream = null;
            StreamWriter sw = null;

            storage = IsolatedStorageFile.GetUserStoreForApplication();

            using(stream = storage.OpenFile(filenameTextBox.Text, FileMode.Create))
            using(sw = new StreamWriter(stream))
            {
                sw.Write(mainTextBox.Text);
            }
        }

        private void ApplicationBarIconButton0_Click(object sender, EventArgs e)
        {
            /*
            IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream stream = storage.OpenFile(filenameTextBox.Text, FileMode.Create);
            StreamWriter sw = new StreamWriter(stream, Encoding.UTF8);
            sw.Write(mainTextBox.Text);
            sw.Close();
            stream.Close();
            */
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/FileListPage.xaml?", UriKind.Relative));
        }

        private void ApplicationBarIconButton1_Click(object sender, EventArgs e)
        {
            /*
            NavigationService.Navigate(new Uri("/FileListPage.xaml?", UriKind.Relative));
            */
        }

        private void HideKeyButton_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void ApplicationBarIconButton2_Click(object sender, EventArgs e)
        {

        }

        private void ApplicationBarIconButton3_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void filenameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton hidekeybtn = new ApplicationBarIconButton();
            hidekeybtn.IconUri = new Uri("/icons/appbar.download.rest.png", UriKind.Relative);
            hidekeybtn.Text = "キーボードを閉じる";
            ApplicationBar.Buttons.Add(hidekeybtn);
            hidekeybtn.Click += new EventHandler(HideKeyButton_Click);
        }

        private void filenameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton savebtn = new ApplicationBarIconButton();
            savebtn.IconUri = new Uri("/icons/appbar.save.rest.png", UriKind.Relative);
            savebtn.Text = "保存";
            ApplicationBar.Buttons.Add(savebtn);
            savebtn.Click += new EventHandler(SaveButton_Click);

            ApplicationBarIconButton loadbtn = new ApplicationBarIconButton();
            loadbtn.IconUri = new Uri("/icons/appbar.list.rest.png", UriKind.Relative);
            loadbtn.Text = "開く";
            ApplicationBar.Buttons.Add(loadbtn);
            loadbtn.Click += new EventHandler(LoadButton_Click);
        }
    }
}