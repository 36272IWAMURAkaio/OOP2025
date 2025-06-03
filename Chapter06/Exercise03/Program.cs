﻿
using System.Globalization;
using static System.Reflection.Metadata.BlobBuilder;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            //Console.WriteLine("6.3.3");
            //Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);


        }

        private static void Exercise1(string text) {
            var count = text.Count(char.IsWhiteSpace );
            Console.WriteLine($"{count}文字");
        }
        //
        private static void Exercise2(string text) {
            var replace = text.Replace("big","small");
            Console.WriteLine(replace);
            }
        

        //private static void Exercise3(string text) {
        //    throw new NotImplementedException();
        //}

        private static void Exercise4(string text) {
            var count = text.Split(' ').Length;
            Console.WriteLine("単語数:{0}",count);
        }

        private static void Exercise5(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);

            foreach (var word in words) ;
            Console.WriteLine(word);
                }
    }
}
