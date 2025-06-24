using System.Globalization;

namespace section01 {
    internal class Program {
        static void Main(string[] args) {

            var today = new DateTime(2025, 7, 12);
            var now = DateTime.Now;


           
            Console.WriteLine($"{today.Month}");
            Console.WriteLine($"Now:{now}");


            //自分が生まれた生年月日は何曜日かをプログラムを書いて調べる
            //西暦
            Console.Write("西暦:");
            var year = int.Parse(Console.ReadLine());
            //月
            Console.WriteLine("月:");
            var mounth = int.Parse(Console.ReadLine());
            //日
            Console.WriteLine("日:");
            var day = int.Parse(Console.ReadLine());

            var birth = new DateTime(year, mounth, day);


            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var str = birth.ToString("ggyy年M月d日", culture);
            var shortDayOfWeek = culture.DateTimeFormat.GetShortestDayName(birth.DayOfWeek);

            Console.WriteLine(str + birth.ToString("ddd曜日", culture));

            //生まれてから○○○○○日です
            TimeSpan diff = DateTime.Today - birth;
            Console.WriteLine(diff.TotalDays + "日");

            //うるう年の判定プログラムを作成する
            //西暦の入力
            //0000念はうるう年です
        }
    }
}
