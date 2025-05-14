namespace Section01 {
    internal class Program {

        public delegate bool judgment(int value);//デリケートの宣言

        static void Main(string[] args) {
            //Console.WriteLine("カウントしたい数値");
           // int num = int.Parse(Console.ReadLine());

            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 4, 10, 4 };

            judgment judge = IsEven;
            Console.WriteLine(Count(numbers,judge));
        }


        //メソッドへ渡す処理
        static bool IsEven(int n) {
            return n % 2 == 0;
        }
        static int Count(int[] numbers,judgment judge) {
           
            var count = 0;
            foreach (var n in numbers) {
                if(judge(n) == true ) {
                    count++;
                }
                
            }
           
            return count;
        }
        
    }
}
