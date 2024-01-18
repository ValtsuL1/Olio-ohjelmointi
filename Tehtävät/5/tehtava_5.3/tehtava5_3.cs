using System;
using System.Globalization;

namespace Tehtava
{
    enum Choice
    {
        Kivi,
        Paperi,
        Sakset
    }
    class Player
    {
        public int Choice { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int RoundCounter { get; set; }

        // ilmoittaa monesko kierros on menossa, lisää yhden jos ei tullut tasapeliä
        public void CountRounds(int computerChoice, int humanChoice)
        {
            if (computerChoice != humanChoice)
            {
                RoundCounter++;
            }

            Console.WriteLine($"Kierros: {RoundCounter}\n");
        }
    }
    class Computer : Player
    {
        public void ComputerChoose()
        {
            // arpoo 0-2 väliltä luvun ja asettaa sen Choice muuttujaan
            Random rnd = new();
            int num = rnd.Next(0, 3);
            Choice = num;
        }

        public void ComputerWin()
        {
            Wins++;
            Console.WriteLine($"{Name} voitti kierroksen!\n");
        }
    }
    class Human : Player
    {
        public void HumanChoose()
        {
            Console.WriteLine("[1] Kivi, [2] Paperi, [3] Sakset\n");
            // vähentää syötteestä yhden jotta enum arvo osuisi oikeaan kohtaan
            int num = Convert.ToInt32(Console.ReadLine()) - 1;
            Choice = num;
        }

        public void HumanWin()
        {
            Wins++;
            Console.WriteLine($"{Name} voitti kierroksen!\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Player roundCount = new()
            {
                RoundCounter = 1
            };

            Computer computer = new()
            {
                Name = "Tietokone",
                Wins = 0
            };

            Human human = new()
            {
                Name = "",
                Wins = 0
            };

            Console.WriteLine("Syötä nimesi:");
            human.Name = Convert.ToString(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("Montako kierrosta haluat pelata?");

                int rounds = Convert.ToInt32(Console.ReadLine());
                // tässä jaetaan käyttäjän syöte 2 ja pyöristetään
                // seuraavaan kokonaislukuun, sen jälkeen se muutetaan int muotoon
                // näin saadaan minimimäärä kierroksia joka pitää voittaa
                int roundsToWin = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(rounds) / 2));

                // suoritetaan kunnes tietokoneen tai ihmisen voitetut kierrokset saavuttavat minimimäärän
                while (computer.Wins != roundsToWin & human.Wins != roundsToWin)
                {
                    // ilmoittaa kierrosluvun, parametreinä pelaajien valinta
                    roundCount.CountRounds(computer.Choice, human.Choice);

                    computer.ComputerChoose();
                    human.HumanChoose();

                    Console.WriteLine($"{computer.Name}: {(Choice)computer.Choice}\n");

                    Console.WriteLine($"{human.Name}: {(Choice)human.Choice}\n");

                    if (human.Choice == 0)
                    {
                        if (computer.Choice == 1)
                        {
                            computer.ComputerWin();
                        }
                        else if (computer.Choice == 2)
                        {
                            human.HumanWin();
                        }
                    }
                    else if (human.Choice == 1)
                    {
                        if (computer.Choice == 0)
                        {
                            human.HumanWin();
                        }
                        else if (computer.Choice == 2)
                        {
                            computer.ComputerWin();
                        }
                    }
                    else if (human.Choice == 2)
                    {
                        if (computer.Choice == 0)
                        {
                            computer.ComputerWin();
                        }
                        else if (computer.Choice == 1)
                        {
                            human.HumanWin();
                        }
                    }

                    Console.WriteLine($"{human.Name}: {human.Wins} | {computer.Name}: {computer.Wins}\n");
                }

                if (computer.Wins == roundsToWin)
                {
                    Console.WriteLine($"{computer.Name} voitti!\n");
                }
                else
                {
                    Console.WriteLine($"{human.Name} voitti!\n");
                }

                // nollaa lopuksi voitot sekä kierrosluvun
                computer.Wins = 0;
                human.Wins = 0;
                roundCount.RoundCounter = 0;
            }
        }
    }
}