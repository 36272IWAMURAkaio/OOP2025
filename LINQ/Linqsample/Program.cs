namespace Linqsample {
    internal class Program {
        static void Main(string[] args) {

            var numbers = Enumerable.Range(1, 100);

            ////合計値を出力
            ////足し算
            //Console.WriteLine(numbers.Sum());
            ////平均
            //Console.WriteLine(numbers.Average());

            Console.WriteLine(numbers.Where(n => n % 8 == 0).Max());
            ////偶数Sum(n => n % 2));


        }


    //        foreach(var num in numbers) {
    //            Console.WriteLine(num){ 
    //        }
        }
    }
}
