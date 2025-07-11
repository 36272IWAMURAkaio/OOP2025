using static System.Reflection.Metadata.BlobBuilder;

namespace Test02 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new[] { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };

            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin",
                "Canberra", "Hong Kong",
            };

            #region テスト用ドライバ
            Console.WriteLine("問題１：合計値");
            Exercise01(numbers);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題２：偶数の最大値");
            Exercise02(numbers);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題３：昇順");
            Exercise03(numbers);
            Console.WriteLine("\n\n-----");

            Console.WriteLine("問題４：10 以上 50 以下のみ");
            Exercise04(numbers);
            Console.WriteLine("\n\n-----");

            Console.WriteLine("問題５：小文字の'n'が含まれている都市数");
            Exercise05(cities);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題６：全都市数");
            Exercise06(cities);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題７：各都市をアルファベット順（昇順）に出力");
            Exercise07(cities);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題８：各都市の文字数");
            Exercise08(cities);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題９：各都市名と文字数を文字数の昇順");
            Exercise09(cities);
            Console.WriteLine("\n-----");

            Console.WriteLine("問題１０：６文字の都市名");
            Exercise10(cities);
            Console.WriteLine("\n-----");

            #endregion
        }

        // 問題１：合計値（式形式）
        private static void Exercise01(int[] numbers) =>
            Console.WriteLine(numbers.Sum());

        // 問題２：偶数の最大値（式形式）
        private static void Exercise02(int[] numbers) =>
            Console.WriteLine(numbers.Where(n => n % 2 == 0).Max());

        // 問題３：昇順（遅延実行 → ToListしない）
        private static void Exercise03(int[] numbers) {
            var sorted = numbers.OrderBy(n => n);
            Console.WriteLine(string.Join(" ", sorted));
        }

        // 問題４：10以上50以下の数字のみ
        private static void Exercise04(int[] numbers) {
            var filtered = numbers.Where(n => n >= 10 && n <= 50);
            Console.WriteLine(string.Join(" ", filtered));
        }

        // 問題５：小文字の'n'が含まれる都市数
        private static void Exercise05(List<string> cities) {
            var count = cities.Count(c => c.Contains('n'));
            Console.WriteLine(count);
        }

        // 問題６：全都市数
        private static void Exercise06(List<string> cities) {
            Console.WriteLine(cities.Count);
        }

        // 問題７：各都市名をアルファベット順（昇順）に出力
        private static void Exercise07(List<string> cities) {
            foreach (var city in cities.OrderBy(c => c)) {
                Console.WriteLine(city);
            }
        }

        // 問題８：各都市の文字数
        private static void Exercise08(List<string> cities) {
            foreach (var city in cities) {
                Console.WriteLine($"{city} : {city.Length}文字");
            }
        }

        // 問題９：都市名と文字数を文字数の昇順で出力
        private static void Exercise09(List<string> cities) {
            var sorted = cities.OrderBy(c => c.Length);
            foreach (var city in sorted) {
                Console.WriteLine($"{city} : {city.Length}文字");
            }
        }

        // 問題１０：６文字の都市名を表示
        private static void Exercise10(List<string> cities) {
            var filtered = cities.Where(c => c.Length == 6);
            foreach (var city in filtered) {
                Console.WriteLine(city);
            }
        }
    }
}
