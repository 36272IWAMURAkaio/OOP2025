using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WeatherApp {
    // 都市データの定義
    public class CityLocation {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public partial class MainWindow : Window {
        // 都市リストを作成
        private List<CityLocation> cities = new List<CityLocation>
        {
            new CityLocation { Name = "札幌", Latitude = 43.0667, Longitude = 141.3500 },
            new CityLocation { Name = "仙台", Latitude = 38.2682, Longitude = 140.8694 },
            new CityLocation { Name = "東京", Latitude = 35.6895, Longitude = 139.6917 },
            new CityLocation { Name = "名古屋", Latitude = 35.1815, Longitude = 136.9066 },
            new CityLocation { Name = "大阪", Latitude = 34.6937, Longitude = 135.5023 },
            new CityLocation { Name = "広島", Latitude = 34.3853, Longitude = 132.4553 },
            new CityLocation { Name = "福岡", Latitude = 33.5902, Longitude = 130.4017 },
            new CityLocation { Name = "那覇", Latitude = 26.2124, Longitude = 127.6809 },
        };

        public MainWindow() {
            InitializeComponent();

            // コンボボックスに都市リストを設定
            CityComboBox.ItemsSource = cities;

            // 初期選択を「東京」にする (インデックス2)
            CityComboBox.SelectedIndex = 2;
        }

        // コンボボックスが変更された時に呼ばれる
        private async void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (CityComboBox.SelectedItem is CityLocation selectedCity) {
                await LoadWeatherData(selectedCity.Latitude, selectedCity.Longitude);
            }
        }

        // 緯度経度を受け取って天気を取得するメソッドに変更
        private async Task LoadWeatherData(double lat, double lon) {
            string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,relative_humidity_2m,weather_code,wind_speed_10m&daily=weather_code,temperature_2m_max,temperature_2m_min&timezone=Asia%2FTokyo";

            try {
                using (var client = new HttpClient()) {
                    var response = await client.GetStringAsync(url);
                    var data = JsonSerializer.Deserialize<WeatherResponse>(response);

                    if (data != null) {
                        // 画面更新
                        UpdateBackground(data.Current.WeatherCode);
                        CurrentTempText.Text = $"{data.Current.Temperature}℃";
                        CurrentWindText.Text = $"風速: {data.Current.WindSpeed} m/s";
                        CurrentHumidityText.Text = $"湿度: {data.Current.Humidity}%";

                        // 画像の切り替え処理
                        string iconPath = GetIconPath(data.Current.WeatherCode);
                        // 画像パスが正しいか確認するためにtry-catchやURIチェックを入れるとより安全です
                        CurrentWeatherIcon.Source = new BitmapImage(new Uri(iconPath, UriKind.RelativeOrAbsolute));

                        // 週間予報の更新
                        var weeklyList = new List<DailyDisplayItem>();
                        for (int i = 0; i < data.Daily.Time.Count; i++) {
                            weeklyList.Add(new DailyDisplayItem {
                                Date = DateTime.Parse(data.Daily.Time[i]).ToString("MM/dd"),
                                WeatherCode = data.Daily.WeatherCode[i],
                                MaxTemp = data.Daily.MaxTemp[i],
                                MinTemp = data.Daily.MinTemp[i]
                            });
                        }
                        DailyForecastList.ItemsSource = weeklyList;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("データの取得に失敗しました: " + ex.Message);
            }
        }

        // 画像パス取得ロジック（プロジェクトに画像がある前提）
        private string GetIconPath(int code) {
            // ※実際のファイルパスに合わせて変更してください
            // 例: プロジェクト直下のImagesフォルダにある場合
            if (code == 0) return "pack://application:,,,/Images/sun.png";
            if (code >= 1 && code <= 3) return "pack://application:,,,/Images/cloud.png";
            if (code >= 51 && code <= 67) return "pack://application:,,,/Images/rain.png";
            if (code >= 71) return "pack://application:,,,/Images/snow.png";

            return "pack://application:,,,/Images/cloud.png";
        }
        // MainWindow.xaml.cs に追加

        // 背景色を変更するメソッド
        private void UpdateBackground(int code) {
            var brush = new System.Windows.Media.LinearGradientBrush();
            brush.StartPoint = new Point(0, 0); // 左上
            brush.EndPoint = new Point(1, 1);   // 右下

            // 天気コードによる色の分岐
            if (code == 0 || code == 1) // 快晴・晴れ
            {
                // 鮮やかな青空
                brush.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromRgb(79, 172, 254), 0.0));
                brush.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromRgb(0, 242, 254), 1.0));
            } else if (code >= 2 && code <= 48) // 曇り
              {
                // 落ち着いたグレーブルー
                brush.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromRgb(161, 196, 253), 0.0));
                brush.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromRgb(194, 233, 251), 1.0));
            } else if (code >= 51) // 雨や雪
              {
                // 暗めのディープブルー・グレー
                brush.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromRgb(102, 125, 182), 0.0));
                brush.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromRgb(0, 130, 200), 0.0));
                brush.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromRgb(102, 125, 182), 1.0));
            }

            // XAMLで名前をつけたBorderの背景を更新
            MainBackground.Background = brush;
        }
    }
}