using System;

class Program {
    static void Main() {
        Console.WriteLine("インチ → メートル変換:");
        Console.WriteLine("はじめ:" + 1);
        Console.WriteLine("はじめ:" + 10);
        for (int inch = 1; inch <= 10; inch++) {
            double meters = inch * 0.0254;
            Console.WriteLine($"{inch} in = {meters:F4} m");
        }

        Console.WriteLine("\nメートル → インチ変換:");
        Console.WriteLine("はじめ:" + 1);
        Console.WriteLine("はじめ:" + 10);
        for (int meter = 1; meter <= 10; meter++) {
            double inches = meter * 39.3701;
            Console.WriteLine($"{meter} m = {inches:F4} in");
        }
    }
}
