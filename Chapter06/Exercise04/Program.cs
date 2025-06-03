namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var elements = line.Split(';');

            foreach (var element in elements) {
                var pair = element.Split('=');
                var key = pair[0];
                var value = pair[1];
                Console.WriteLine($"{ToJapanese(key)}：{value}");
            }
        }

        /// <summary>
        /// 引数の単語を日本語へ変換します
        /// </summary>
        /// <param name="key">"Novelist","BestWork","Born"</param>
        /// <returns>"作家","代表作","誕生年"</returns>
        static string ToJapanese(string key) {
            return key switch {
                "Novelist" => "作家",
                "BestWork" => "代表作",
                "Born" => "誕生年",
                => "不明"
            };
            
        }
    }
}
