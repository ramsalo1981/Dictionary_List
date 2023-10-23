namespace CALists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var egypt = new Country { ISOCode = "EGY", Name = "Egypt" };
            var jordan = new Country { ISOCode = "JOR", Name = "Jordan" };
            var iraq = new Country { ISOCode = "IRQ", Name = "Iraq" };

            Country[] countriesArray = new Country[] { egypt, jordan, iraq };


            // Constructors

            //List<Country> countries = new List<Country>();
            //List<Country> countries = new List<Country>(3);
            List<Country> countries = new List<Country>(countriesArray);
            Print(countries);
            Console.WriteLine("----------------");
            //Methods
            countries.Add(new Country { ISOCode = "BRA", Name = "Brasil" });
            Print(countries);
            Console.WriteLine("----------------");

            //countries.AddRange(countriesArray);
            //Print(countries);
            //Console.WriteLine("----------------");

            countries.Insert(1, new Country { ISOCode = "FRA", Name = "France" });//Insert[index,object]
            Print(countries);
            Console.WriteLine("----------------");
            //remove an element
            countries.RemoveAt(4);
            Print(countries);
            Console.WriteLine("----------------");
            //remove all elements end with ce
            countries.RemoveAll(x => x.Name.EndsWith("ce"));
            Print(countries);
            Console.WriteLine("----------------");
            //remove an object
            //countries.Remove(iraq);
            //------------------------------(1)------------------------
            countries.Remove(new Country { ISOCode = "IRQ", Name = "Iraq" });// we use equal and gethush for delete it (see 1)
            Print(countries);




            Console.ReadKey();
        }
        static void Print(List<Country> countries)
        {
            foreach (var c in countries)
            {
                Console.WriteLine(c);
            }

            // Properties 
            Console.WriteLine($"Count: {countries.Count}"); // actual count
            Console.WriteLine($"Capacity: {countries.Capacity}"); // initial capacity for inner data structure
        }
    }
    class Country
    {
        public string ISOCode { get; set; }
        public string Name { get; set; }

        //---------------(1)--------------------
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                hash = hash * 23 + ISOCode.GetHashCode();
                hash = hash * 23 +Name.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object? obj)
        {
            var country = obj as Country;
            if(country is null) return false;
            return this.ISOCode.Equals(country.ISOCode, StringComparison.OrdinalIgnoreCase) 
                && this.Name.Equals(country.Name, StringComparison.OrdinalIgnoreCase);
            
        }
        //----------------------------------------------------------------------------------
        public override string ToString()
        {
            return $"{Name} ({ISOCode})"; // Egypt (EGY)
        }
    }
}