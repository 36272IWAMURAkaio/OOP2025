using System;

class Program {
    static void Main() {
        Console.WriteLine("変換したい方向を選んでください:");
        Console.WriteLine("1: ヤード → メートル");
        Console.WriteLine("2: メートル → ヤード");

        string choice = Console.ReadLine();

        if (choice == "1") {
            Console.WriteLine("\nヤード → メートル変換:");
            for (int yard = 1; yard <= 10; yard++) {
                double meters = yard * 0.9144;
                Console.WriteLine($"{yard} yd = {meters:F4} m");
            }
        } else if (choice == "2") {
            Console.WriteLine("\nメートル → ヤード変換:");
            for (int meter = 1; meter <= 10; meter++) {
                double yards = meter * 1.09361;
                Console.WriteLine($"{meter} m = {yards:F4} yd");
            }
        }
    }
}
