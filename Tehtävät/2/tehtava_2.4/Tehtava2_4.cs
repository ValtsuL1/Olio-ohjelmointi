using System;
using Microsoft.Win32.SafeHandles;

namespace Tehtava
{
    class Program
    {
        static void Main(string[] args)
        {
            // kysyy käyttäjältä minuutit ja muuntaa ne kokonaisluvuksi
            Console.WriteLine("Anna kokonaisaika minuutteina:");
            int minutes = Convert.ToInt32(Console.ReadLine());

            // päivät saadaan jakamalla minuutit 1440
            int days = minutes / 1440;
            // tunnit saadaan vähentämällä ensin kokonaisten päivien minuutit 
            // kokonaisminuuteista ja jakamalla 60
            int hours = (minutes - (days * 1440)) / 60;
            // loput minuutit saadaan vähentämällä kokonaisten päivien ja
            // tuntien minuutit kokonaisminuuteista
            int minutesRemainder = minutes - (days * 1440 + hours * 60);

            Console.WriteLine($"Antamasi aika muutettuna: {days} päivää {hours} tuntia {minutesRemainder} minuuttia");
        }
    }
}