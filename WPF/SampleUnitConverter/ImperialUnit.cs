using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    class ImperialUnit : DistanceUnit {
        private static List<ImperialUnit> units = new List<ImperialUnit> {
            new ImperialUnit{Name = "in" ,Cofficient = 1,},
            new ImperialUnit{Name = "ft" ,Cofficient = 12,},
            new ImperialUnit{Name = "yd" ,Cofficient = 12 * 3,},
            new ImperialUnit{Name = "ml" ,Cofficient = 12 * 3 * 1760,},

            };
        public static ICollection<ImperialUnit> Units { get => units; }
    }
}
