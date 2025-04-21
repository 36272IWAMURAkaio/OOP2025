namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123, "かりんとう", 180);
            Product daifuku = new Product(150, "大福", 270);

            //税抜き価格の表示{かりんとうの税抜き価格は○○円です}
            Console.WriteLine(karinto.Name +"の税抜き価格は" + karinto.Price + "円です");
            //消費税額の表示
            Console.WriteLine(karinto.Name +"の税抜き価格は" +karinto.GetTax() +"円です");
            //税込み価格の表示
            Console.WriteLine(karinto.Name + "税込み価格は" + karinto.GetPriceIncluduingTax() + "円です");

            //税抜き価格の表示{だいふくの税抜き価格は○○円です}
            Console.WriteLine(daifuku.Name + "の税抜き価格は" + daifuku.Price + "円です");
            //消費税額の表示
            Console.WriteLine(daifuku.Name + "の税抜き価格は" + daifuku.GetTax() + "円です");
            //税込み価格の表示
            Console.WriteLine(daifuku.Name + "税込み価格は" + daifuku.GetPriceIncluduingTax() + "円です");
        }
    }
}
