using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQの例 {
    public class Person {//プロパティ
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    class Program {
        static void Main(string[] args) {
            var people = new List<Person> {
                new Person { Name = "Alice", Age = 30, City = "Tokyo" },
                new Person { Name = "Bob", Age = 17, City = "Osaka" },
                new Person { Name = "Charlie", Age = 25, City = "Tokyo" },
                new Person { Name = "David", Age = 22, City = "Nagoya" },
                new Person { Name = "Eve", Age = 18, City = "Osaka" }
            };

            Console.WriteLine("=== 1. Where / Select (メソッド構文) ===");
            var adults = people
                .Where(p => p.Age >= 18)
                .Select(p => p.Name);

            foreach (var name in adults) {
                Console.WriteLine(name);
            }

            Console.WriteLine("\n=== 2. クエリ構文 ===");
            var tokyoPeople = from p in people
                              where p.City == "Tokyo"
                              select p;

            foreach (var p in tokyoPeople) {
                Console.WriteLine($"{p.Name} ({p.Age})");
            }

            Console.WriteLine("\n=== 3. OrderBy / ThenBy ===");
            var sorted = people
                .OrderBy(p => p.City)
                .ThenBy(p => p.Name);

            foreach (var p in sorted) {
                Console.WriteLine($"{p.City} - {p.Name}");
            }

            Console.WriteLine("\n=== 4. GroupBy ===");
            var groupedByCity = people.GroupBy(p => p.City);
            foreach (var group in groupedByCity) {
                Console.WriteLine($"City: {group.Key}");
                foreach (var person in group) {
                    Console.WriteLine($" - {person.Name} ({person.Age})");
                }
            }

            Console.WriteLine("\n=== 5. Any / All ===");
            bool anyTeen = people.Any(p => p.Age < 20);
            bool allAdult = people.All(p => p.Age >= 18);
            Console.WriteLine($"10代がいるか: {anyTeen}");
            Console.WriteLine($"全員が18歳以上か: {allAdult}");

            Console.WriteLine("\n=== 6. FirstOrDefault / SingleOrDefault ===");
            var firstOsaka = people.FirstOrDefault(p => p.City == "Osaka");
            Console.WriteLine($"最初の大阪出身: {firstOsaka?.Name}");

            var exactTokyo = people.SingleOrDefault(p => p.Name == "Charlie");
            Console.WriteLine($"東京のCharlie: {exactTokyo?.Name}");

            Console.WriteLine("\n=== 7. Count / Sum / Average / Max / Min ===");
            int count = people.Count();
            int adultCount = people.Count(p => p.Age >= 18);
            double avgAge = people.Average(p => p.Age);
            int maxAge = people.Max(p => p.Age);
            int minAge = people.Min(p => p.Age);
            Console.WriteLine($"人数: {count}, 大人の人数: {adultCount}");
            Console.WriteLine($"平均年齢: {avgAge}, 最年長: {maxAge}, 最年少: {minAge}");

            Console.WriteLine("\n=== 8. SelectMany (ネストの平坦化) ===");
            var schoolClasses = new List<List<string>> {
                new List<string> { "Alice", "Bob" },
                new List<string> { "Charlie", "David" }
            };

            var allStudents = schoolClasses.SelectMany(c => c);
            foreach (var student in allStudents) {
                Console.WriteLine(student);
            }

            Console.WriteLine("\n=== 9. ToDictionary ===");
            var peopleDict = people.ToDictionary(p => p.Name, p => p.Age);
            foreach (var kv in peopleDict) {
                Console.WriteLine($"{kv.Key}: {kv.Value}歳");
            }

            Console.WriteLine("\n=== 10. Join (内部結合) ===");
            var cities = new[] {
                new { Name = "Tokyo", Population = 9000000 },
                new { Name = "Osaka", Population = 2700000 },
                new { Name = "Nagoya", Population = 2300000 }
            };

            var joined = people.Join(
                cities,
                p => p.City,
                c => c.Name,
                (p, c) => new {
                    Person = p.Name,
                    City = c.Name,
                    Population = c.Population
                });

            foreach (var item in joined) {
                Console.WriteLine($"{item.Person} lives in {item.City} (pop: {item.Population})");
            }
        }
    }
}
//概要・用途別まとめ
//用途 関数名 / 構文
//フィルタ	Where
//投影	Select
//並び替え	OrderBy, ThenBy
//グループ化	GroupBy
//集計	Count, Sum, Average など
//存在確認	Any, All
//要素取得	First, FirstOrDefault
//平坦化	SelectMany
//辞書に変換	ToDictionary
//結合（Join）	Join, GroupJoin