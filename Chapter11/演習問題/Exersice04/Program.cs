using System.Text.RegularExpressions;

namespace Exersice04 {
    internal class Program {
        static void Main(string[] args) {

            var lines = File.ReadAllLines("sample.txt");

            var newlines = lines.Select(s => Regex.Replace(s => ))

                File.WriteAllLines("sampleChange.txt", newlines);
        }
    }
}
