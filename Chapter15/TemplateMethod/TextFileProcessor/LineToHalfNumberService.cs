using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextFileProcessor;
namespace TextFileProcessorDI {
    // P362 問題15.1
    public class LineToHalfNumberService : ITextFileService {
        private static Dictionary<char, char> _dictionary =
            new Dictionary<char, char>() {
               { '0', '0' }, { '1', '1' }, { '2', '2' }, { '3', '3' }, { '4', '4' },
               { '5', '5' }, { '6', '6' }, { '7', '7' }, { '8', '8' }, { '9', '9' }
            };
        public void Initialize(string fname) {
        }
        public void Execute(string line) {
            // string result = new string(
            //     line.Select(c => ('0' <= c && c <= '9') ? (char)(c - '0' + '0') : c).ToArray()
            // );
            // Console.WriteLine(result);

            // Dictionary を使った例
            var s = Regex.Replace(line, "[0-9]", c => _dictionary[c.Value[0]].ToString());
                Console.WriteLine(s);
        }
        public void Terminate() {
        }
    }
}