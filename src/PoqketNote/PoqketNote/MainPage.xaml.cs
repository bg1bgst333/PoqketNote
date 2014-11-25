using System;
using System.Collections.Generic;
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
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = false;
        }

        private void TextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBlock_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void mainTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = false;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = true;
        }

        private void mainTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ((ApplicationBarIconButton)ApplicationBar.Buttons[0]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[1]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[2]).IsEnabled = true;
            ((ApplicationBarIconButton)ApplicationBar.Buttons[3]).IsEnabled = false;
        }

        private void ApplicationBarIconButton3_Click(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}