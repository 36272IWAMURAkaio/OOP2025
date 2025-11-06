namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            HttpClient hc = new HttpClient();
            var text = await GetHtmlExample(hc);
            Console.WriteLine(text);
        }


        static async Task GetHtmlExample(HttpClient httpClient) {
            var url = "https://w.atwiki.jp/sword-masters/pages/57.html";
            var text = await httpClient.GetStringAsync(url);
            Console.WriteLine(text);
        }
    }
}
