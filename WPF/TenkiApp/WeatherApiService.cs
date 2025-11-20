using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class WeatherApiService {
    private const string ApiKey = "YOUR_API_KEY"; // ← API キーを入れる
    private static readonly HttpClient Client = new HttpClient();

    public async Task<WeatherResult?> GetWeatherAsync(string city) {
        string url =
            $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={ApiKey}&units=metric&lang=ja";

        try {
            var response = await Client.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();

            var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            return new WeatherResult {
                Weather = root.GetProperty("weather")[0].GetProperty("description").GetString(),
                Temperature = root.GetProperty("main").GetProperty("temp").GetDouble()
            };
        }
        catch {
            return null;
        }
    }
}
