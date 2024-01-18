using System;

namespace Tehtava
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<String>
            {
                "Theodore,Roosevelt",
                "William,Taft",
                "Woodrow,Wilson",
                "Warren,Harding",
                "Calvin,Coolidge",
                "Herbert,Hoover",
                "Franklin,Roosevelt",
                "Harry,Truman",
                "Dwight,Eisenhower",
                "John,Kennedy",
                "Lyndon,Johnson",
                "Richard,Nixon"
            };

            // järjestää listan aakkosjärjestykseen
            names.Sort(delegate(String name1, String name2)
            {
                return name1.CompareTo(name2);
            });

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}