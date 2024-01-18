using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime;

namespace Tehtava
{
    class Program
    {
        static void Main(string[] args)
        {
            // tulostus while loopilla
            int y = 1;
            while (y < 26)
            {
                Console.WriteLine(y);
                y++;
            }

            int amount = 0;

            // tulostus for loopilla
            for (int i=1; i<26; i++)
            {
                Console.WriteLine(i);
                amount += i;
            }

            int avg = amount / 25;
            
            Console.WriteLine($"Yhteenlaskettu summa: {amount}");
            Console.WriteLine($"Keskiarvo: {avg}");
        }
    }
}