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
    }
}