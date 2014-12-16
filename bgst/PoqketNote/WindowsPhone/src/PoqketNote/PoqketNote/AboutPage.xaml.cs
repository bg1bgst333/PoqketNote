using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace PoqketNote
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public const string mail = "bg1@hotmail.co.jp";
        public AboutPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            AssemblyTitleAttribute attrTitle = (AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute));
            appname.Text = attrTitle.Title;
            AssemblyFileVersionAttribute attrFileVer = (AssemblyFileVersionAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyFileVersionAttribute));
            appversion.Text = "Version " + attrFileVer.Version;
            AssemblyCopyrightAttribute attrCopyRight = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute));
            appcopyright.Text = attrCopyRight.Copyright;
            appmail.NavigateUri = new Uri("mailto:"+mail);
            appmail.Content = mail;
        }

        private void appmail_Click(object sender, RoutedEventArgs e)
        {
            string es;

            try
            {

                EmailComposeTask task = new EmailComposeTask()
                {
                    To = this.appmail.Content as string,
                    Subject = "[PoqketNote]"
                };

                task.Show();

            }
            catch (Exception ex)
            {
                es = ex.ToString();
            }
        }
    }
}