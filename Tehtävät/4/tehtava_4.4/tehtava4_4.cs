using System;

namespace Tehtava
{
    class Thermostat
    {
        public Boolean IsStarted { get; set; }
        public Double CurrentValue { get; set; }
        public Double TargetValue { get; set; }

        public bool StartUp(bool IsStarted)
        {
            if (!IsStarted)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double HeatUp(double CurrentValue, double TargetValue)
        {
            while (CurrentValue != TargetValue)
            {
                CurrentValue++;
            }
            return CurrentValue;
        }
        public double CoolDown(double CurrentValue, double TargetValue)
        {
            while (CurrentValue != TargetValue)
            {
                CurrentValue--;
            }
            return CurrentValue;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Thermostat therm = new()
            {
                CurrentValue = 20,
                TargetValue = 0,
                IsStarted = false
            };

            Console.WriteLine("Anna tavoitelämpötila");

            while (true)
            {
                try
                {
                    therm.TargetValue = Convert.ToDouble(Console.ReadLine());

                    therm.IsStarted = therm.StartUp(therm.IsStarted);

                    Console.WriteLine($"Tämän hetkinen lämpötila: {therm.CurrentValue} °C, Tavoitelämpö: {therm.TargetValue} °C");

                    if (therm.CurrentValue < therm.TargetValue)
                    {
                        therm.CurrentValue = therm.HeatUp(therm.CurrentValue, therm.TargetValue);
                    }

                    if (therm.CurrentValue > therm.TargetValue)
                    {
                        therm.CurrentValue = therm.CoolDown(therm.CurrentValue, therm.TargetValue);
                    }

                    // tähän vielä esto jos mennään absoluuttisen nollapisteen alle
                    if (therm.CurrentValue < -273.15)
                    {
                        therm.CurrentValue = -273.15;
                    }

                    Console.WriteLine($"Uusi lämpötila: {therm.CurrentValue} °C");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Väärä muoto");
                }
            }
        }
    }
}