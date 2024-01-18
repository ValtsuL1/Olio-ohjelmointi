using System;
using System.Diagnostics.CodeAnalysis;

namespace Tehtava
{
    class Item
    {
        public string Name {get;set;}
        public double Price {get;set;}
        public int TaxBracket {get;set;}
    }

    class TaxCalculator
    {
        private double tax = 24;

        public virtual double CalculateTax(double price)
        {
            return price * (1-(tax/100));
        }
    }

    class FoodTaxCalculator : TaxCalculator
    {
        private double tax = 14;

        public override double CalculateTax(double price)
        {
            return price * (1-(tax/100));
        }
    }

    class OtherTaxCalculator : TaxCalculator
    {
        private double tax = 10;

        public override double CalculateTax(double price)
        {
            return price * (1-(tax/100));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TaxCalculator taxCalculator = new();
            FoodTaxCalculator foodTaxCalculator = new();
            OtherTaxCalculator otherTaxCalculator = new();

            List<Item> items = new()
            {
                new() 
                {
                    Name = "Banaani",
                    Price = 0.40,
                    TaxBracket = 1
                },

                new() 
                {
                    Name = "Shamppoo",
                    Price = 2.30,
                    TaxBracket = 0
                },

                new() 
                {
                    Name = "Kirja",
                    Price = 7.50,
                    TaxBracket = 2
                },
                new()
                {
                    Name = "Kurkku",
                    Price = 0.45,
                    TaxBracket = 1
                },
                new()
                {
                    Name = "Sanomalehti",
                    Price = 2.45,
                    TaxBracket = 2
                },
                new()
                {
                    Name = "Pekoni",
                    Price = 1.55,
                    TaxBracket = 1
                },
                new()
                {
                    Name = "WC-paperi",
                    Price = 6.20,
                    TaxBracket = 0
                },
                new()
                {
                    Name = "Särkylääke",
                    Price = 7.75,
                    TaxBracket = 1
                },
                new()
                {
                    Name = "Villasukat",
                    Price = 12.20,
                    TaxBracket = 0
                }
            };

            int num = 1;

            Console.WriteLine("Tuotteet:\n");

            foreach (var item in items)
            {
                
                Console.WriteLine($"{item.Name}: {num++} | Hinta: {item.Price} €");
            }

            // tuotteiden kokonaissumma
            double totalPrice = 0;
            // tuotteiden kokonaissumma - verot
            double totalPriceTaxFree = 0;
            // jokaisen verokannan tuotteiden kokonaissumma
            double totalPriceTaxBracket1 = 0;
            double totalPriceTaxBracket2 = 0;
            double totalPriceTaxBracket3 = 0;
            // jokaisen verokannan tuotteiden kokonaissumma - verot
            double totalPriceTaxFreeBracket1 = 0;
            double totalPriceTaxFreeBracket2 = 0;
            double totalPriceTaxFreeBracket3 = 0;
            // jokaisen verokannan tuotteiden määrä
            int taxBracket1Count = 0;
            int taxBracket2Count = 0;
            int taxBracket3Count = 0;

            // lista jonka avulla saadaan jokaisen tuotteen määrä erikseen
            List<Item> checkout = new();

            Console.WriteLine("\nValitse tuotteet, Paina 0 jatkaaksesi:");
            
            while (true)
            {
                int choice = Convert.ToInt32(Console.ReadLine()) - 1;

                if (choice == -1)
                {
                    break;
                }

                switch (items[choice].TaxBracket)
                {
                    // kutsuu CalculateTax metodin tuotteen TaxBracket muuttujan perusteella
                    // lisää verottoman hinnan kokonaishintaan ja tietyn verokannan kokonaishintaan
                    // lisää yhden verokannan tuotteiden määrään
                    case 0:
                        totalPriceTaxFree += taxCalculator.CalculateTax(items[choice].Price);
                        totalPriceTaxFreeBracket1 += taxCalculator.CalculateTax(items[choice].Price);
                        totalPriceTaxBracket1 += items[choice].Price;
                        taxBracket1Count++;
                        break;
                    case 1:
                        totalPriceTaxFree += foodTaxCalculator.CalculateTax(items[choice].Price);
                        totalPriceTaxFreeBracket2 += foodTaxCalculator.CalculateTax(items[choice].Price);
                        totalPriceTaxBracket2 += items[choice].Price;
                        taxBracket2Count++;
                        break;
                    case 2:
                        totalPriceTaxFree += otherTaxCalculator.CalculateTax(items[choice].Price);
                        totalPriceTaxFreeBracket3 += otherTaxCalculator.CalculateTax(items[choice].Price);
                        totalPriceTaxBracket3 += items[choice].Price;
                        taxBracket3Count++;
                        break;
                }

                // lisää verollisen hinnan kokonaishintaan
                totalPrice += items[choice].Price;

                checkout.Add(items[choice]);
            }

            // luo checkoutOrdered listan johon asetetaan checkout listasta
            // jokaisen määrän nimen perusteella
            var checkoutOrdered = checkout.
                GroupBy(item => item.Name)
                .Where(group => group.Count() >= 1)
                .Select(group => new {Name = group.Key, Count = group.Count()})
                .ToList();

            Console.WriteLine("KUITTI\n");

            // tulostaa checkoutOrdered listasta kuittiin tiedot
            foreach (var item in checkoutOrdered)
            {
                Console.WriteLine($"{item.Name} | {item.Count}");
            }

            // verot saadaan vähentämällä loppusummasta veroton loppusumma
            double totalTax = totalPrice - totalPriceTaxFree;
            // sama tehdään joka verokannalle erikseen
            double totalTaxBracket1 = totalPriceTaxBracket1 - totalPriceTaxFreeBracket1;
            double totalTaxBracket2 = totalPriceTaxBracket2 - totalPriceTaxFreeBracket2;
            double totalTaxBracket3 = totalPriceTaxBracket3 - totalPriceTaxFreeBracket3;

            Console.WriteLine("\nALV\t\tVEROLLINEN\tVEROTON\t\tVERO");

            // jos listassa ei ole jonkun verokannan tuotteita niitä ei tulosteta
            if (taxBracket1Count > 0)
            {
                Console.WriteLine($"{taxBracket1Count} 24,00%\t{Math.Round(totalPriceTaxBracket1, 2)} €\t\t{Math.Round(totalPriceTaxFreeBracket1, 2)} €\t\t{Math.Round(totalTaxBracket1, 2)} €\n");
            }
            if (taxBracket2Count > 0)
            {
                Console.WriteLine($"{taxBracket2Count} 14,00%\t{Math.Round(totalPriceTaxBracket2, 2)} €\t\t{Math.Round(totalPriceTaxFreeBracket2, 2)} €\t\t{Math.Round(totalTaxBracket2, 2)} €\n");

            }
            if (taxBracket3Count > 0)
            {
                Console.WriteLine($"{taxBracket3Count} 10,00%\t{Math.Round(totalPriceTaxBracket3, 2)} €\t\t{Math.Round(totalPriceTaxFreeBracket3, 2)} €\t\t{Math.Round(totalTaxBracket3, 2)} €\n");

            }

            Console.WriteLine($"YHTEENSÄ\t{Math.Round(totalPrice, 2)} €\t\t{Math.Round(totalPriceTaxFree, 2)} €\t\t{Math.Round(totalTax, 2)} €");
        }
    }
}