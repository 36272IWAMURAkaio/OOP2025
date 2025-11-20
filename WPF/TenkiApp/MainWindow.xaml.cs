using System.Windows;

namespace WeatherApp {
    public partial class MainWindow : Window {
        private readonly WeatherApiService _weatherService = new WeatherApiService();

        public MainWindow() {
            InitializeComponent();
        }

        private async void Search_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(CityTextBox.Text)) {
                MessageBox.Show("都市名を入力してください");
                return;
            }

            var result = await _weatherService.GetWeatherAsync(CityTextBox.Text);

            if (result == null) {
                MessageBox.Show("天気情報を取得できませんでした");
                return;
            }

            WeatherText.Text = $"天気: {result.Weather}";
            TempText.Text = $"気温: {result.Temperature} ℃";
        }
    }
}
