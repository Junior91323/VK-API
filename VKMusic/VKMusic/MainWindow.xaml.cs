using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VKMusic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            webBrowser.Visibility = Visibility.Visible;
            webBrowser.Navigate(String.Format("https://oauth.vk.com/authorize?client_id={0}&scope={1}&redirect_uri={2}&display=page&response_type=token", ConfigurationSettings.AppSettings["VKAppId"], ConfigurationSettings.AppSettings["VKScope"], ConfigurationSettings.AppSettings["VKRedirectUri"])); 

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
