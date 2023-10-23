namespace CADictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var article =
            //    "Dot NET is a free cross-platform and open source developer platform" +
            //    "for building many different types of applications" +
            //    "With Dot NET you can use multiple languages and libraries" +
            //    "to build for web and IoT";
            //// i want to make every letter key 
            //// key:'d' value : Dot developer ...
            //Dictionary<char, List<string>> lettersDictionary = new Dictionary<char, List<string>>();
            //foreach (var word in article.Split())
            //{
            //    //Console.WriteLine(word);
            //    foreach (var ch in word)
            //    {
            //        char c = Char.ToLower(ch);
            //        if (!lettersDictionary.ContainsKey(c))
            //        {
            //            lettersDictionary.Add(c, new List<string> { word });
            //        }
            //        else
            //        {
            //            lettersDictionary[c].Add(word);
            //        }

            //    }

            //}
            //foreach (var entry in lettersDictionary)
            //{
            //    Console.Write($"'{entry.Key}': ");
            //    foreach (var word in entry.Value)
            //    {
            //        Console.WriteLine($"\t\t \"{word}\"");
            //    }
            //}
            var emps = new List<Employee>
            {
                new Employee {Id = 100, Name = "Reem S.", ReportTo = null},
                new Employee {Id = 101, Name = "Raed M.", ReportTo = 100 },
                new Employee {Id = 102, Name = "Ali B.", ReportTo = 100 },
                new Employee {Id = 103, Name = "Abeer S.", ReportTo = 102 },
                new Employee {Id = 104, Name = "Radwan N.", ReportTo = 102 },
                new Employee {Id = 105, Name = "Nancy R.", ReportTo = 101 },
                new Employee {Id = 106, Name = "Saleh A.", ReportTo = 104 }
            };
            //var managers1 = emps.ToLookup(y => y.ReportTo).ToDictionary(y => y.Key ?? -1, y => y.ToList());
            //foreach (var employee in managers1)
            //{
            //    Console.WriteLine(employee.Key);
            //}
            //Console.ReadKey();
            var managers = emps.GroupBy(x => x.ReportTo).ToDictionary(x => x.Key ?? -1, x => x.ToList());
            //foreach (var employee in managers)
            //{
            //    if (employee.Key == -1)
            //    {
            //        continue;
            //    }
            //    Console.WriteLine(employee.Key);
            //    foreach (var item in employee.Value)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            foreach (var entry in managers)
            {
                if (entry.Key == -1)
                    continue;
                var manager = emps.FirstOrDefault(x => x.Id == entry.Key);

                Console.WriteLine($"{manager}");

                foreach (var emp in entry.Value)
                {
                    Console.WriteLine($"\t\t\"{emp}\"");
                }
            }
            Console.ReadKey();
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ReportTo { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
    }
}