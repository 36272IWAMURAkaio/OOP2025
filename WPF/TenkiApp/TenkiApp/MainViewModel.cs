using System.Collections.ObjectModel;
using System.ComponentModel;
using WeatherApp.Models;

namespace WeatherApp.ViewModels {
    public class MainViewModel : INotifyPropertyChanged {

        public string Location { get; set; } = "東京都 江東区";
        public int CurrentTemperature { get; set; } = 29;
        public string Description { get; set; } = "曇り所により晴れ";

        public ObservableCollection<DailyWeather> DailyForecast { get; set; }

        public MainViewModel() {
            DailyForecast = new ObservableCollection<DailyWeather>
            {
                new DailyWeather("15日(日)", "/Images/cloudy.png", 32, 27),
                new DailyWeather("16日(月)", "/Images/sunny.png", 32, 27),
                new DailyWeather("17日(火)", "/Images/sunny.png", 31, 27)
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
