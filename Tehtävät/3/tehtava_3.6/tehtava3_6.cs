using System;

namespace Tehtava
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> nameAndAge = new()
                {
                    {"Rutherford B. Hayes",1822},
                    {"James A. Garfield",1831},
                    {"Chester A. Arthur",1829},
                    {"Grover Cleveland",1837},
                    {"Benjamin Harrison",1833},
                    {"William McKinley",1843},
                    {"Theodore Roosevelt",1858}
                };
            
            // luo muuttujat johon lisätään arvot
            int bornIn30sAmount = 0;

            var bornIn30sList = new List<string>();

            int totalAge = 0;

            foreach ( KeyValuePair<string, int> kvp in nameAndAge )
            {
                // jos syntymävuosi on 30-luvulla, lisää yhden muuttujaan
                if (kvp.Value > 1829 && kvp.Value < 1840)
                {
                    bornIn30sAmount++;
                }

                // jos syntymävuosi on 20-luvlla, lisää nimen listaan
                if (kvp.Value > 1819 && kvp.Value < 1830)
                {
                    bornIn30sList.Add(kvp.Key);
                }

                // lisää syntymävuoden muuttujaan
                totalAge += kvp.Value;
            }
            
            // jakaa kaikki vuodet yhdessä dictionaryn pituudella
            int avgAge = totalAge / nameAndAge.Count;

            Console.WriteLine($"1830 luvulla syntyneitä: {bornIn30sAmount}");

            Console.Write("1820 luvun henkilöt: ");

            foreach ( string name in bornIn30sList )
            {
                Console.Write($"{name} ");
            }

            Console.WriteLine($"\nKeskisyntymävuosi: {avgAge}");
        }
    }
}