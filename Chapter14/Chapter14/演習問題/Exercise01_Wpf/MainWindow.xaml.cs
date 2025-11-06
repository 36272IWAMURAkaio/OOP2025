using Microsoft.Web.WebView2.Core;
using System;
using System.Windows;
using System.Windows.Input;

namespace SimpleWpfBrowser {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync() {
            await webView.EnsureCoreWebView2Async(null);
            webView.Source = new Uri("https://www.google.com");
        }

        private void btnGo_Click(object sender, RoutedEventArgs e) {
            NavigateToUrl();
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                NavigateToUrl();
            }
        }

        private void NavigateToUrl() {
            string url = txtUrl.Text.Trim();
            if (string.IsNullOrEmpty(url)) return;

            // httpを補完
            if (!url.StartsWith("http")) {
                url = "https://" + url;
            }

            try {
                webView.Source = new Uri(url);
            }
            catch (Exception ex) {
                MessageBox.Show("URLが正しくありません。\n" + ex.Message);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e) {
            if (webView.CanGoBack)
                webView.GoBack();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e) {
            if (webView.CanGoForward)
                webView.GoForward();
        }
    }
}
