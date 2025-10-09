using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter
{
    class MetricUnit : DistanceUnit{
        private static List<MetricUnit> units = new List<MetricUnit> {
            new MetricUnit{Name = "in" ,Cofficient = 1,},
            new MetricUnit{Name = "ft" ,Cofficient = 12,},
            new MetricUnit{Name = "yd" ,Cofficient = 12 * 3,},
            new MetricUnit{Name = "ml" ,Cofficient = 12 * 3 * 1760,},

            };
        public static ICollection<MetricUnit> Units { get => units; }
            
    }
}
