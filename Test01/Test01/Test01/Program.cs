namespace Test01 {
    public class Program {
        static void Main(string[] args) {
            var score = new ScoreCounter("StudentScore.csv");
            var TotalBySubject = score.GetPerStudentScore();
            foreach (var obj in TotalBySubject) {
                Console.WriteLine("{0} {1}", obj.Key,obj.Value);
            }
        }
    }
}

