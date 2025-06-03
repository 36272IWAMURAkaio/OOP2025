using System.Globalization;

namespace Exersice01 {
    internal class Program {
        static void Main(string[] args) {
            var s1 = Console.ReadLine();
            var S2 = Console.ReadLine();


            var cultureinfo = new CultureInfo("ja-JP");
            if (string.Compare(s1, S2, cultureinfo, CompareOptions.None) == 0)
                Console.WriteLine("等しい");
            else {
                Console.WriteLine("等しくない");
            }
            

            }
        }
    }
}
