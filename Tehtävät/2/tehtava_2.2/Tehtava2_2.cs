using System;

namespace Tehtava
{
    class Program
    {
        static void Main(string[] args)
        {
            // kysyy pistemäärän, muuttaa desimaaliluvuksi ja jakaa 81
            // result muuttujaan
            Console.WriteLine("Anna pisteet:");
            int points = Convert.ToInt32(Console.ReadLine());
            double result = points / 81;
            
            // tulostaa arvosanan pisteiden perusteella
            if ( result >= 0.9 )
            {
                Console.WriteLine("Opiskelijan arvosana: 5");
            }
            
            else if ( result >= 0.8 && result < 0.9 )
            {
                Console.WriteLine("Opiskelijan arvosana: 4");
            }
            
            else if ( result >= 0.7 && result < 0.8 )
            {
                Console.WriteLine("Opiskelijan arvosana: 3");
            }
            
            else if ( result >= 0.6 && result < 0.7 )
            {
                Console.WriteLine("Opiskelijan arvosana: 2");
            }
            
            else if ( result >= 0.5 && result < 0.6 )
            {
                Console.WriteLine("Opiskelijan arvosana: 1");
            }
            
            else if ( result < 0.5 )
            {
                Console.WriteLine("Opiskelijan arvosana: 0");
            }
        }
    }
}