using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("ファイルパスを入力：");
            string path = Console.ReadLine();

            var service = new LineCounterService();
            var processor = new TextFileProcessor.TextFileProcessor(service);

            processor.Run(path);
        }
    }
}
