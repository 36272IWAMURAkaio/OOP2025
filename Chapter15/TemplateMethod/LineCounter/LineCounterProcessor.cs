using TextFileProcessor;

namespace LineCounter {
    public class LineCounterProcessor : ITextFileService {
        private int _count = 0;
        private string _searchWord = "";

        public void Initialize(string fileName) {
            _count = 0;
            Console.Write("カウントしたい単語を入力：");
            _searchWord = Console.ReadLine();
        }

        public void Execute(string line) {
            _count += line.Split(_searchWord).Length - 1;
        }

        public void Terminate() {
            Console.WriteLine($"「{_searchWord}」の出現回数：{_count}");
        }
    }
}
