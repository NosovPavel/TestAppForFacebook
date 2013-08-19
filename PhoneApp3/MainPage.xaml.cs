using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PhoneApp3.Resources;

namespace PhoneApp3
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Конструктор
        public MainPage()
        {
            InitializeComponent();
            webBrowser.Navigated += webBrowser_Navigated;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var url = "https://m.facebook.com/dialog/oauth?client_id=154349468104054&redirect_uri=http://www.skaterka.ru&scope=email,user_about_me,user_photos";
            webBrowser.Navigate(new Uri(url));
        }

        async void webBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            Dictionary<string, string> yourDictionary = ParseQueryString(webBrowser.Source.AbsoluteUri);
            if (yourDictionary.ContainsKey("code"))
            {
                MessageBox.Show(yourDictionary["code"], "Oh my god, i found the CODE!!! ", MessageBoxButton.OK);
            }
        }

        public static Dictionary<string, string> ParseQueryString(string uri)
        {

            string substring = uri.Substring(((uri.LastIndexOf('?') == -1) ? 0 : uri.LastIndexOf('?') + 1));

            string[] pairs = substring.Split('&');

            Dictionary<string, string> output = new Dictionary<string, string>();

            foreach (string piece in pairs)
            {
                string[] pair = piece.Split('=');
                if (pair.Count() == 1)
                    continue;
                output.Add(pair[0], pair[1]);
            }

            return output;

        }
    }
}