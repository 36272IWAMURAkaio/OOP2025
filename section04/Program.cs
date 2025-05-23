namespace Section04 {
    internal class Program {

        public delegate bool Judgement(int value);  //デリゲートの宣言

        static void Main(string[] args) {
            var cites = new List<string> {
    "Tokyo",
    "New Delhi",
    "Bangkok",
    "London",
    "Paris",
    "Berlin",
    "Canberra",
    "Hong Kong",
};
            var query = cites.Where(s => s.Length <= 5);
            foreach (var item in query) {
                Console.WriteLine(item);
            }
            Console.WriteLine("------");

            cites[0] = "Osala";
            foreach (var item in query) {
                Console.WriteLine(item);
            }
        }
    }

}