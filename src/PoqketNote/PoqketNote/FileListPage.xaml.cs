using System;
using System.Collections.Generic;
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

namespace PoqketNote
{
    public partial class FileListPage : PhoneApplicationPage
    {
        public FileListPage()
        {
            InitializeComponent();
        }

        private void listBox1_Loaded(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile storage = null;
            FileList fl = new FileList();
            try
            {
                storage = IsolatedStorageFile.GetUserStoreForApplication();
                //string[] d = storage.GetDirectoryNames();
                string[] filearray = storage.GetFileNames();
                //string[] s;
                //s = d;
                if (filearray.Length > 0){
                    foreach (var f in filearray)
                    {
                        //DateTime dt = File.GetLastWriteTime();
                        FileData fd = new FileData();
                        //fd.Updated = dt;
                        fd.FileName = f;
                        fl.Files.Add(fd);
                    }
                }
                listBox1.DataContext = fl;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                
            }
        }
    }
}