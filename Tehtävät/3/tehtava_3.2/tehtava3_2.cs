using System;

namespace Tehtava
{
    class Program
    {
        static void Main(string[] args)
        {
            // luo muuttujan johon lisätään palkat
            double totalSalary = 0;
            
            for (int i = 0; i < 12; i++)
            {
                // kysyy palkkaa ja lisää totalSalary muuttujaan
                Console.WriteLine("Anna kuukausipalkka");
                double salary = Convert.ToDouble(Console.ReadLine());
                totalSalary += salary;
            }

            // laskee keskipalkan ja pyöristää molemmat palkat
            double avgSalary = Math.Round(totalSalary / 12, 2);
            Math.Round(totalSalary, 2);

            Console.WriteLine($"Kokonaispalkka: {totalSalary}");
            Console.WriteLine($"Keskipalkka: {avgSalary}");
        }
    }
}