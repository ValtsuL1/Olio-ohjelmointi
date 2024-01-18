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
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thermostat therm = new()
            {
                CurrentValue = 17,
                TargetValue = 24,
                IsStarted = false
            };

            if (!therm.IsStarted)
            {
                therm.IsStarted = true;
            }
            else
            {
                therm.IsStarted = false;
            }

            Console.WriteLine($"Tämän hetkinen lämpötila: {therm.CurrentValue} °C, Tavoitelämpö: {therm.TargetValue} °C");

            if (therm.CurrentValue < therm.TargetValue & therm.IsStarted)
            {
                while (therm.CurrentValue != therm.TargetValue)
                {
                    therm.CurrentValue++;
                }
            }
            else if (therm.CurrentValue > therm.TargetValue & therm.IsStarted)
            {
                while (therm.CurrentValue != therm.TargetValue)
                {
                    therm.CurrentValue--;
                }
            }

            Console.WriteLine($"Uusi lämpötila: {therm.CurrentValue} °C, Tavoitelämpö: {therm.TargetValue} °C");
        }
    }
}