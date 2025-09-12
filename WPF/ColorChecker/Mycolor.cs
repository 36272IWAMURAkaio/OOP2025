using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorChecker {
    public class MyColor {
        public string Name { get; set; }   // 色の名前
        public Color Color { get; set; }   // 実際の色
                                           // 表示用に Brush を返すプロパティ
        public SolidColorBrush Brush => new SolidColorBrush(Color);
        // ToString をオーバーライドして名前を返す
        public override string ToString() {
            return Name;
        }
    }
}
