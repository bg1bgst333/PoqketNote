﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
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

            ApplicationBarMenuItem aboutmenu = new ApplicationBarMenuItem();
            aboutmenu.Text = "バージョン情報";
            ApplicationBar.MenuItems.Add(aboutmenu);
            aboutmenu.Click += new EventHandler(AboutMenu_Click);
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
                MessageBox.Show("ファイル名が入力されていません", "保存エラー", MessageBoxButton.OK);
                return;
            }

            if (filenameTextBox.Text == "__ApplicationSettings")
            {
                MessageBox.Show("このファイル名では保存できません", "保存エラー", MessageBoxButton.OK);
                return;
            }

            IsolatedStorageFile storage = null;
            IsolatedStorageFileStream stream = null;
            StreamWriter sw = null;

            storage = IsolatedStorageFile.GetUserStoreForApplication();

            if (storage.FileExists((filenameTextBox.Text)))
            {
                MessageBoxResult r;
                r = MessageBox.Show("ファイルを上書きしますか?", "上書き確認", MessageBoxButton.OKCancel);
                if (r == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            using(stream = storage.OpenFile(filenameTextBox.Text, FileMode.Create))
            using(sw = new StreamWriter(stream))
            {
                sw.Write(mainTextBox.Text);
            }

            MessageBox.Show("ファイルを保存しました", "保存成功", MessageBoxButton.OK);

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

        private void AboutMenu_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml?", UriKind.Relative));
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //string path;
            
            base.OnNavigatedTo(e);

            //string qs = NavigationContext.ToString();
            //string es = e.Uri.ToString();
            //NavigationContext.QueryString.TryGetValue("path", out path);
            //NavigationContext.QueryString.TryGetValue("btn", out btn);
            //if (path != "" && path != null && btn == "edit")
            //if (NavigationContext.QueryString.TryGetValue("path", out path))
            IsolatedStorageSettings appstore = IsolatedStorageSettings.ApplicationSettings;
            if (!appstore.Contains("command"))
            {
                return;
            }
            string val = Convert.ToString(appstore["command"]);
            string fn = Convert.ToString(appstore["filename"]);
            if (val == "edit" && (fn != null || fn != "-"))
            {

                IsolatedStorageFile storage = null;
                IsolatedStorageFileStream stream = null;
                StreamReader sr = null;

                storage = IsolatedStorageFile.GetUserStoreForApplication();

                if (!storage.FileExists(fn))
                {
                    string file = filenameTextBox.Text;
                    string text = mainTextBox.Text;

                    return;
                    //MessageBox.Show(file);
                }

                using (stream = storage.OpenFile(fn, FileMode.Open))
                using (sr = new StreamReader(stream))
                {
                    mainTextBox.Text = sr.ReadToEnd();
                    filenameTextBox.Text = fn;
                }

                MessageBox.Show("ファイルを開きました", "読み込み成功", MessageBoxButton.OK);

            }

        }
        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            IsolatedStorageSettings appstore = IsolatedStorageSettings.ApplicationSettings;
            appstore.Clear();
        }
    }
}