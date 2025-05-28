namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Books.GetBooks();

            //本の平均価格の表示
            Console.WriteLine(books.Average(b => b.Price));
            //本のページ合計を表示
            Console.WriteLine(books.Sum(b => b.Pages));
            //金額の安い書籍名と金額を表示
            var book = books.Where(b => b.Price == books.Min(b => b.Price));
            //.Select(b => new { b.Title, b.Price });
            foreach (var item in book) {
                Console.WriteLine(item.Title + ":" + item.Price);

            }

            //ページ数の多い書籍名とページ数を表示
            books.Where(b => b.Pages == books
            .Max(x => x.Pages)).ToList()
            .ForEach(x => Console.WriteLine($"{x.Title} : {x.Pages}ページ"));
           
            //タイトルに「物語」が含まれている書籍名をすべて表示
            var titles = books.Where(b => b.Title.Contains("物語"));
            foreach (var item in titles) {
                Console.WriteLine(item.Title);

            }

        }
    }
}
