namespace Section01 {
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
            var lowerList = cites.ConvertAll(s => s.ToUpper());
            lowerList.ForEach(s => Console.WriteLine(s));
            }
        }

    }