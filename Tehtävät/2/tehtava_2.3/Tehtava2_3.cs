using System;

namespace Tehtava
{
    class Program
    {
        static void Main(string[] args)
        {
            // kysyy numerot ja muuttaa desimaaliluvuksi
            Console.WriteLine("Anna ensimmäinen numero:");
            double number1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Anna toinen numero:");
            double number2 = Convert.ToDouble(Console.ReadLine());

            // suorittaa laskutoimitukset ja pyöristää kahteen desimaaliin
            double addition = Math.Round(number1 + number2, 2);
            double substraction = Math.Round(number1 - number2, 2);
            double multiplication = Math.Round(number1 * number2, 2);
            double division = Math.Round(number1 / number2, 2);

            Console.WriteLine($"Lukujen {number1} ja {number2} laskuoperaatiot");
            Console.WriteLine($"Yhteenlasku: {addition}");
            Console.WriteLine($"Vähennyslasku: {substraction}");
            Console.WriteLine($"Kertolasku: {multiplication}");
            Console.WriteLine($"Jakolasku: {division}");
        }
    }
}