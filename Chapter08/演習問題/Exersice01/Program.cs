
namespace Exersice01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();

            Exercise2(text);

        }


        private static void Exercise1(string text) {
            var dict = new Dictionary<Char, int>();//ディクショナリを作る
            foreach (var c in text.ToUpper()) {//大文字に変換
                //アルファベット(A～Z)ならディクショナリに登録
                if ('A'<= c && c <= 'Z') {
                    if (dict.ContainsKey(c))//ディクショナリにCharがあるかContainkey
                        dict[c]++;
                    else//一文字取り出し
                        dict[c] = 1;
                }
            }
            //アルファベット順に並び替えて出力
            foreach (var pair in dict.OrderBy(p => p.Key)) {
                Console.WriteLine($"{pair.Key}:{pair.Value}");
            }
        }


        private static void Exercise2(string text) {

        }
    }
}
