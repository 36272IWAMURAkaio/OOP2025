namespace WeatherApp.Models
{
    public class DailyWeather
    {
        public string Date { get; set; }
        public string Icon { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }

        public DailyWeather(string date, string icon, int maxTemp, int minTemp)
        {
            Date = date;
            Icon = icon;
            MaxTemp = maxTemp;
            MinTemp = minTemp;
        }
    }
}
