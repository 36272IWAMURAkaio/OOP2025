using System;

class Program {
    static void Main() {
        Console.WriteLine("変換したい方向を選んでください:");
        Console.WriteLine("1: インチ → メートル");
        Console.WriteLine("2: メートル → インチ");

        string choice = Console.ReadLine();

        if (choice == "1") {
            Console.WriteLine("\nインチ → メートル変換:");
            for (int inch = 1; inch <= 10; inch++) {
                double meters = inch * 0.0254;
                Console.WriteLine($"{inch} in = {meters:F4} m");
            }
        } else if (choice == "2") {
            Console.WriteLine("\nメートル → インチ変換:");
            for (int meter = 1; meter <= 10; meter++) {
                double inches = meter * 39.3701;
                Console.WriteLine($"{meter} m = {inches:F4} in");
            }
        }

    }
}

