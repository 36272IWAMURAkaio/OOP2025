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
    // MainWindow.xaml.cs にある CityLocation クラスと cities リストを以下に置き換えます

    public class CityLocation {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public partial class MainWindow : Window {
        // 47都道府県の代表都市の緯度経度データリスト
        private List<CityLocation> cities = new List<CityLocation>
        {
        new CityLocation { Name = "北海道 (札幌)", Latitude = 43.06417, Longitude = 141.34694 },
        new CityLocation { Name = "青森", Latitude = 40.82444, Longitude = 140.74056 },
        new CityLocation { Name = "岩手 (盛岡)", Latitude = 39.70361, Longitude = 141.15250 },
        new CityLocation { Name = "宮城 (仙台)", Latitude = 38.26889, Longitude = 140.87222 },
        new CityLocation { Name = "秋田", Latitude = 39.71861, Longitude = 140.10250 },
        new CityLocation { Name = "山形", Latitude = 38.25556, Longitude = 140.36333 },
        new CityLocation { Name = "福島", Latitude = 37.75028, Longitude = 140.46778 },
        new CityLocation { Name = "茨城 (水戸)", Latitude = 36.36583, Longitude = 140.47333 },
        new CityLocation { Name = "栃木 (宇都宮)", Latitude = 36.56583, Longitude = 139.88250 },
        new CityLocation { Name = "群馬 (前橋)", Latitude = 36.39111, Longitude = 139.06083 },
        new CityLocation { Name = "埼玉 (さいたま)", Latitude = 35.86167, Longitude = 139.64500 },
        new CityLocation { Name = "千葉", Latitude = 35.60472, Longitude = 140.12333 },
        new CityLocation { Name = "東京", Latitude = 35.68950, Longitude = 139.69170 },
        new CityLocation { Name = "神奈川 (横浜)", Latitude = 35.44778, Longitude = 139.64250 },
        new CityLocation { Name = "新潟", Latitude = 37.90222, Longitude = 139.02361 },
        new CityLocation { Name = "富山", Latitude = 36.69528, Longitude = 137.21139 },
        new CityLocation { Name = "石川 (金沢)", Latitude = 36.56111, Longitude = 136.65694 },
        new CityLocation { Name = "福井", Latitude = 36.06528, Longitude = 136.22194 },
        new CityLocation { Name = "山梨 (甲府)", Latitude = 35.66389, Longitude = 138.56833 },
        new CityLocation { Name = "長野", Latitude = 36.65194, Longitude = 138.18111 },
        new CityLocation { Name = "岐阜", Latitude = 35.39111, Longitude = 136.72222 },
        new CityLocation { Name = "静岡", Latitude = 34.97694, Longitude = 138.38306 },
        new CityLocation { Name = "愛知 (名古屋)", Latitude = 35.18139, Longitude = 136.90667 },
        new CityLocation { Name = "三重 (津)", Latitude = 34.73028, Longitude = 136.50861 },
        new CityLocation { Name = "滋賀 (大津)", Latitude = 35.00444, Longitude = 135.86833 },
        new CityLocation { Name = "京都", Latitude = 35.02139, Longitude = 135.75556 },
        new CityLocation { Name = "大阪", Latitude = 34.68639, Longitude = 135.52000 },
        new CityLocation { Name = "兵庫 (神戸)", Latitude = 34.69000, Longitude = 135.19556 },
        new CityLocation { Name = "奈良", Latitude = 34.68528, Longitude = 135.80583 },
        new CityLocation { Name = "和歌山", Latitude = 34.22611, Longitude = 135.16750 },
        new CityLocation { Name = "鳥取", Latitude = 35.50361, Longitude = 134.23833 },
        new CityLocation { Name = "島根 (松江)", Latitude = 35.47222, Longitude = 133.05056 },
        new CityLocation { Name = "岡山", Latitude = 34.66167, Longitude = 133.91667 },
        new CityLocation { Name = "広島", Latitude = 34.39639, Longitude = 132.45944 },
        new CityLocation { Name = "山口", Latitude = 34.18583, Longitude = 131.47056 },
        new CityLocation { Name = "徳島", Latitude = 34.06583, Longitude = 134.55944 },
        new CityLocation { Name = "香川 (高松)", Latitude = 34.34028, Longitude = 134.04333 },
        new CityLocation { Name = "愛媛 (松山)", Latitude = 33.84167, Longitude = 132.76611 },
        new CityLocation { Name = "高知", Latitude = 33.55972, Longitude = 133.53111 },
        new CityLocation { Name = "福岡", Latitude = 33.59028, Longitude = 130.40167 },
        new CityLocation { Name = "佐賀", Latitude = 33.24944, Longitude = 130.29889 },
        new CityLocation { Name = "長崎", Latitude = 32.74472, Longitude = 129.87361 },
        new CityLocation { Name = "熊本", Latitude = 32.78972, Longitude = 130.74167 },
        new CityLocation { Name = "大分", Latitude = 33.23806, Longitude = 131.61250 },
        new CityLocation { Name = "宮崎", Latitude = 31.91111, Longitude = 131.42389 },
        new CityLocation { Name = "鹿児島", Latitude = 31.56028, Longitude = 130.55806 },
        new CityLocation { Name = "沖縄 (那覇)", Latitude = 26.21250, Longitude = 127.68111 }
    };

        // ... (MainWindow クラスの残りのコード) ...
        public MainWindow() {
            InitializeComponent();

            // コンボボックスに47都道府県リストを設定
            CityComboBox.ItemsSource = cities;

            // 初期選択を「北海道 (札幌)」にする (インデックス0)
            CityComboBox.SelectedIndex = 0; // ★ここを0に変更
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