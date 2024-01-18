using System;

namespace Tehtava2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // kysyy numeron ja muuntaa kokonaisluvuksi
            Console.WriteLine("Anna numero 1-10:");
            int number = Convert.ToInt32(Console.ReadLine());


            if ( number <= 10 && number >= 1)
            {
                Console.WriteLine($"Annoit numeron {number}");
            }
            else
            {
                Console.WriteLine("Väärä numero");
            }
        }
    }
}