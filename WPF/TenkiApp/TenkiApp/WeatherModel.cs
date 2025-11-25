// WeatherModels.cs というファイルを作成して貼り付けてください
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class WeatherResponse {
    [JsonPropertyName("current")]
    public CurrentWeather Current { get; set; }

    [JsonPropertyName("daily")]
    public DailyForecast Daily { get; set; }
}

public class CurrentWeather {
    [JsonPropertyName("temperature_2m")]
    public double Temperature { get; set; }

    [JsonPropertyName("relative_humidity_2m")]
    public double Humidity { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public double WindSpeed { get; set; }

    [JsonPropertyName("weather_code")]
    public int WeatherCode { get; set; }
}

public class DailyForecast {
    [JsonPropertyName("time")]
    public List<string> Time { get; set; }

    [JsonPropertyName("weather_code")]
    public List<int> WeatherCode { get; set; }

    [JsonPropertyName("temperature_2m_max")]
    public List<double> MaxTemp { get; set; }

    [JsonPropertyName("temperature_2m_min")]
    public List<double> MinTemp { get; set; }
}

// 画面表示用に使いやすく整理したクラス
public class DailyDisplayItem {
    public string Date { get; set; }
    public int WeatherCode { get; set; }
    public double MaxTemp { get; set; }
    public double MinTemp { get; set; }
}