﻿

using System.Diagnostics.Metrics;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            int[] numbers = [5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35];

            Console.WriteLine("7.1.1");
            Exercise1(numbers);

            Console.WriteLine("7.1.2");
            Exercise2(numbers);

            Console.WriteLine("7.1.3");
            Exercise3(numbers);

            Console.WriteLine("7.1.4");
            Exercise4(numbers);

            Console.WriteLine("7.1.5");
            Exercise5(numbers);


            

        }

        private static void Exercise1(int[] numbers) {
            int max = numbers.Max();
            Console.WriteLine($"最大値は:{max}");
        }

        private static void Exercise2(int[] numbers) {
            var books = new List<int>;
        }

        private static void Exercise3(int[] numbers) {
            throw new NotImplementedException();
        }

        private static void Exercise4(int[] numbers) {
            throw new NotImplementedException();
        }

        private static void Exercise5(int[] numbers) {
            throw new NotImplementedException();
        }
    }
    }
}