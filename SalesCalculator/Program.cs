namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            var a = 5;

            var sales = new SalesCounter(@"data\sales.csv");
            var amountsPerStore =  sales.GetPerStoreSales();
            foreach (var obj in amountsPerStore) {
                Console.WriteLine($"{obj.Key} {obj.Value}");
            }
        }

    }
}
