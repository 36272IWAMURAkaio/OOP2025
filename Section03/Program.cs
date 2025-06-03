﻿using System.Text;

namespace Section03 {
    internal class Program {
        static void Main(string[] args) {
            var sb = new StringBuilder();
            foreach (var word in GetWords()) {
                sb.Append(word);

            }
            var text = sb.ToString();
            Console.WriteLine(text);
            //文字列の追加
            String str = "";
            foreach (var Word in GetWords()) {
                str += Word;
            }
            Console.WriteLine(str);
        }



        private static IEnumerable<object> GetWords() {
            return ["Orange", "Lemon", "Strawberry"];
        }
    }
}
