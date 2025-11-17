namespace TextFileMethots {
    internal class Program {
        static void Main(string[] args) {
            TextProcessor.Run<LineCounterProcessor>(args[0]);
            Console.WriteLine("カウントしたい単語 :");
        }
    }
}
