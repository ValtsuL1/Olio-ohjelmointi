using System;
using System.Diagnostics.CodeAnalysis;

namespace Tehtava
{
    public class Calculator
    {
        public double Addition(double number1, double number2)
        {
            return number1 + number2;
        }

        public double Substraction(double number1, double number2)
        {
            return number1 - number2;
        }

        public double Division(double number1, double number2)
        {
            return number1 / number2;
        }

        public double Multiplication(double number1, double number2)
        {
            return number1 * number2;
        }
    }

    class Program
    {
        static void Main()
        {
            Calculator calc = new();

            double value = 0;

            try
            {
                Console.WriteLine("Anna luvut:");
                double number1 = Convert.ToDouble(Console.ReadLine());
                double number2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Anna laskutoimitus: 1)+ 2)- 3)/ 4)* ");
                int calculation = Convert.ToInt32(Console.ReadLine());

                if (calculation == 1)
                {
                    value = calc.Addition(number1, number2);
                }
                else if (calculation == 2)
                {
                    value = calc.Substraction(number1, number2);
                }
                else if (calculation == 3)
                {
                    value = calc.Division(number1, number2);
                }
                else if (calculation == 4)
                {
                    value = calc.Multiplication(number1, number2);
                }
                else
                {
                    Console.WriteLine("Väärä luku");
                }

                Console.WriteLine(Math.Round(value, 2));
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Väärä muoto");
            }
        }
    }
}