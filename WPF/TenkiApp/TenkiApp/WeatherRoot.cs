using System.Collections.Generic;

namespace WeatherApp.Models {
    public class WeatherRoot {
        public Current current { get; set; }
        public List<Daily> daily { get; set; }
    }

    public class Current {
        public double temp { get; set; }
        public List<Weather> weather { get; set; }
    }

    public class Daily {
        public long dt { get; set; }
        public Temp temp { get; set; }
        public List<Weather> weather { get; set; }
    }

    public class Temp {
        public double min { get; set; }
        public double max { get; set; }
    }

    public class Weather {
        public string description { get; set; }
        public string icon { get; set; }
    }
}
