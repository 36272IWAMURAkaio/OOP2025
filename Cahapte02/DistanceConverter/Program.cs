using System.Data;

namespace DistanceConverter {
    internal class Program {
        static void Main(string[] args) {

            int start = int.Parse(args[1]);
            int end = int.Parse(args[2]);

            if(args.Length >= 1 && args[0] == "-tom") {
                PrintMeterToFeetList(start, end);
            } else {
                PrintMeterToFeetList(start end);    
                }
            }
        static void PrintMeterToFeetList(int start, int stop) {
            for (int feet = start; feet <= end; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }
        }
        static void PrintMeterToFeetList(int start, int end) {
            for (int meter = start; meter <= end; meter++) {
                double feet= MeterToFeet(meter);
                Console.WriteLine($"{feet}m = {feet:0.0000}ft");
            }
        }

            static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }

        static double MeterToFeet(int meter) {
            return meter / 0.3048;

        }
    }
}
