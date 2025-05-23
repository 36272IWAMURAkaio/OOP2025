
using System;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {
            //foreach文
            sw.Reset();
            sw.start();
            foreach (var lang in langs) {
                if (lang.Contains("S")) {
                    Console.WriteLine(lang);
                }
                Console.WriteLine("");
                sw.stop();
                //for文
                sw.start();
                for (int i = 0; i < langs.Count; i++) {
                    if (langs[i].Contains("S")) {
                        Console.WriteLine(langs[i]);
                    }
                    Console.WriteLine("");
                    //while文
                    int index = 0;
                    while (index < langs.Count) {
                        if (langs[index].Contains("S")) {
                            Console.WriteLine(langs[index]);
                        }
                        index++;
                        sw.stop();
                    }
                }
            }
        }
        //簡潔バージョン
        private static void Exercise2(List<string> langs) {
            var selected = langs.Where(x => x.Contains('S'));
            foreach (var item in selected) {
                Console.WriteLine(langs);
            }
            

        }
        //さらに簡潔バージョン
        private static void Exercise3(List<string> langs) {
            langs.Find(x => x.Length == 10);
        }
    }
}
