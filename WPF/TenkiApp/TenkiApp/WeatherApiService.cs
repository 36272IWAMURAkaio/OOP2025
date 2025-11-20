using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Models;  // ← WeatherRoot を使うなら必要

namespace WeatherApp.Services {
    public class WeatherApiService {
        private readonly string apiKey = "YOUR_API_KEY_HERE";

        public async Task<WeatherRoot> GetWeatherAsync(double lat, double lon) {
            string url = $"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&units=metric&lang=ja&appid={apiKey}";

            // C# 7.3 用
            var client = new HttpClient();
            try {
                var json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<WeatherRoot>(json);
            }
            finally {
                client.Dispose();
            }
        }
    }
}
