using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        MyColor currentColor;

        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
        }
        private List<MyColor> stockColors = new List<MyColor>();

        /// <summary>
        /// 色の一覧を取得するメソッド
        /// </summary>
        /// <returns></returns>
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name })
                .ToArray();
        }
        // バインドのスライダーが変更された時のイベントハンドラ
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            // RGBのスライダーで指定したRGBの色を表示する
            var myColor = new MyColor{ Color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value),
                Name = string.Empty };
            colorArea.Background = new SolidColorBrush(myColor.Color);
        }
        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem is MyColor selectedColor) {
                setSliderValue(selectedColor.Color);
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
                stockList.SelectedItem = null;
            }
        }
        // ストックボタンがクリックされたとき
        private void stockButton_Click(object sender, RoutedEventArgs e) {
            var rgbColor = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            var selectedComboColor = colorSelectComboBox.SelectedItem as MyColor;
            string colorName;
            if (selectedComboColor != null &&
                selectedComboColor.Color.R == rgbColor.R &&
                selectedComboColor.Color.G == rgbColor.G &&
                selectedComboColor.Color.B == rgbColor.B) {
                colorName = selectedComboColor.Name;  // コンボの名前を使う
            } else {
             
                colorName = $"R{rgbColor.R}:G{rgbColor.G}:B{rgbColor.B}";
            }
            var myColor = new MyColor {
                Color = rgbColor,
                Name = colorName
            };
            stockColors.Add(myColor);
            stockList.ItemsSource = null; // 更新用リセット
            stockList.ItemsSource = stockColors;
        }

        // コンボボックスから色を選択
        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var comboSelectColor = (MyColor)((ComboBox)sender).SelectedItem;
            setSliderValue(comboSelectColor.Color);  // スライダーを設定
        }
        // 各スライダーの値を設定する
        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }
    }
}
