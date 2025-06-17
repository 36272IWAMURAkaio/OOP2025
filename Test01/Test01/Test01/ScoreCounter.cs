namespace Test01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        //メソッドの概要： 
        private static IEnumerable<Student> ReadScore(string filePath) {
            var score = new List<Student>();
            var lines = File.ReadScore(filePath);
            foreach (var line in lines){
                var score = line.Split(',');
                var score = new Student() { }


            }
        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var sale in _score) {
                if (dict.ContainsKey(sale.Name)) {
                    dict[Student.] += sale.Name;
                } else {
                    dict[sale.Name] = sale.Score;
                }
            }
            return dict;
        }
    }
}
