using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VKApi;
using VKMusic.Models;

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

        private void webBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            var clearUriFragment = e.Uri.Fragment.Replace("#", "").Trim();
            var parameters = HttpUtility.ParseQueryString(clearUriFragment);
            VK.AccessToken = parameters.Get("access_token");
            VK.UserId = parameters.Get("user_id");
            if (VK.AccessToken != null && VK.UserId != null)
            {
                webBrowser.Visibility = Visibility.Hidden;
                var a = Audio.GetList(String.Format("https://api.vk.com/method/audio.search?uid={0}&q={1}&access_token={2}", VK.UserId, "beatles",VK.AccessToken));
            }
            
        }


    }
}
