using System.Data;

namespace DistanceConverter {
class Program {
            static void Main() {
                Console.Write("インチを入力してください: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out double inches)) {
                    double meters = inches * 0.0254;
                    Console.WriteLine($"{inches} インチ は {meters} メートル です。");
                } else {
                    Console.WriteLine("数値を正しく入力してください。");
                }
            }
        }

    }




