using System;
using System.Collections;
using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using Tehtava;

namespace Tehtava
{
    class LotteryCheck
    {
        // palauttaa lottorivin voittonumeroiden määrän
        public int CheckNumbers(List<int> numbers, List<int> winningNumbers)
        {
            IEnumerable<int> correctNumbers = numbers.Intersect(winningNumbers);

            int correctNumbersCount = correctNumbers.Count();

            return correctNumbersCount;
        }
    }

    class Lotto
    {
        public List<int>? Numbers = new();
        public List<int>? WinningNumbers = new();
        private int NumbersToRoll = 7;

        // palauttaa listan numeroista jotka käyttäjä valitsee
        // listan riippuu lotosta
        public virtual List<int> ChooseNumbers()
        {
            Console.WriteLine("Valitse numerot [1-40]:\n");
            for (int i = 0; i < NumbersToRoll; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());

                Numbers.Add(number);
            }

            return Numbers;
        }

        public virtual List<int> CalculateNumbers()
        {
            for (int i = 0; i < NumbersToRoll; i++)
            {
                Random random = new();

                // arpoo satunnaisen luvun ja lisää sen listaan jos se on uniikki
                while (WinningNumbers.Count < 7)
                {
                    int number = random.Next(0, 41);
                    if (!WinningNumbers.Contains(number))
                    {
                        WinningNumbers.Add(number);
                    }
                }
            }

            return WinningNumbers;
        }
    }

    class VikingLotto : Lotto
    {
        private int NumbersToRoll = 6;

        public override List<int> ChooseNumbers()
        {
            Console.WriteLine("Valitse numerot [1-48]:\n");
            for (int i = 0; i < NumbersToRoll; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());

                Numbers.Add(number);
            }

            return Numbers;
        }

        public override List<int> CalculateNumbers()
        {
            for (int i = 0; i < NumbersToRoll; i++)
            {
                Random random = new();

                while (WinningNumbers.Count < 6)
                {
                    int number = random.Next(0, 49);
                    if (!WinningNumbers.Contains(number))
                    {
                        WinningNumbers.Add(number);
                    }
                }
            }

            return WinningNumbers;
        }
    }

    class Eurojackpot : Lotto
    {
        private int NumbersToRoll = 5;

        public override List<int> ChooseNumbers()
        {
            Console.WriteLine("Valitse numerot [1-50]:\n");
            for (int i = 0; i < NumbersToRoll; i++)
            {
                int number = Convert.ToInt32(Console.ReadLine());

                Numbers.Add(number);
            }

            return Numbers;
        }

        public override List<int> CalculateNumbers()
        {
            for (int i = 0; i < NumbersToRoll; i++)
            {
                Random random = new();

                while (WinningNumbers.Count < 5)
                {
                    int number = random.Next(0, 51);
                    if (!WinningNumbers.Contains(number))
                    {
                        WinningNumbers.Add(number);
                    }
                }
            }

            return WinningNumbers;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            LotteryCheck lotteryCheck = new();
            Lotto lotto = new();
            VikingLotto vikingLotto = new();
            Eurojackpot eurojackpot = new();

            List<int> numbers = new();
            List<int> winningNumbers = new();

            while (true)
            {
                Console.WriteLine("Valitse peli | [1] Lotto, [2] Vikinglotto, [3] Eurojackpot:\n");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    numbers = lotto.ChooseNumbers();
                    winningNumbers = lotto.CalculateNumbers();
                }
                else if (choice == 2)
                {
                    numbers = vikingLotto.ChooseNumbers();
                    winningNumbers = vikingLotto.CalculateNumbers();
                }
                else if (choice == 3)
                {
                    numbers = eurojackpot.ChooseNumbers();
                    winningNumbers = eurojackpot.CalculateNumbers();
                }

                Console.WriteLine("Valitsemasi numerot:");

                foreach (int number in numbers)
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine($"\n\nOikeat numerot:");

                foreach (int number in winningNumbers)
                {
                    Console.Write($"{number} ");
                }

                int correctNumbersCount = lotteryCheck.CheckNumbers(numbers, winningNumbers);

                Console.WriteLine($"\n\n{correctNumbersCount} oikein.");

                numbers.Clear();
                winningNumbers.Clear();
            }
        }
    }
}