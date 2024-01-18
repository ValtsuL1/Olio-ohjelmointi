using System;

namespace Tehtava
{
    public class Car
    {
        public String Brand { get; set; }
        public String Model { get; set; }
        public String Color { get; set; }
        public Double Engine { get; set; }
        public Int32 CurrentSpeed { get; set; }
        public Boolean IsRunning { get; set; }

        public Boolean StartStopEngine(bool IsRunning)
        {
            if (!IsRunning)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int BrakeOrGas(int CurrentSpeed, int decision, bool IsRunning)
        {
            // auton nopeus alkaa nollasta ja nousee 5 km/h jos auto on 
            // käynnissä ja autoa kiihdytetään

            // auton nopeus ei muutu jos auto on käynnissä ja käyttäjä
            // antaa jonkun muun kokonaisluvun (esim 5)

            // auton nopeus laskee 5 km/h jos auto ei ole käynnissä 
            // (ns moottorijarru) tai autoa jarrutetaan

            // jos auton nopeus laskee alle nollan se asetetaan nollaksi

            if (IsRunning && decision == 2)
            {
                CurrentSpeed += 5;
            }

            if (decision == 3 | !IsRunning)
            {
                CurrentSpeed -= 5;
            }

            if (CurrentSpeed < 0)
            {
                CurrentSpeed = 0;
            }
            return CurrentSpeed;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new()
            {
                Brand = "Volkswagen",
                Model = "Polo",
                Color = "Punainen",
                Engine = 1.6,
                CurrentSpeed = 0,
                IsRunning = false
            };

            string message = "";

            Console.WriteLine($"Valmistaja: {car.Brand}");
            Console.WriteLine($"Malli: {car.Model}");
            Console.WriteLine($"Väri: {car.Color}");
            Console.WriteLine($"Moottorin tilavuus: {car.Engine} l");

            Console.WriteLine("Käynnistä/Sammuta (1) Kiihdytä (2) Jarruta (3) Lopeta (4)");

            while (true)
            {
                try
                {
                    int decision = Convert.ToInt32(Console.ReadLine());

                    if (decision == 4)
                    {
                        break;
                    }

                    if (decision == 1)
                    {
                        car.IsRunning = car.StartStopEngine(car.IsRunning);
                    }

                    car.CurrentSpeed = car.BrakeOrGas(car.CurrentSpeed, decision, car.IsRunning);

                    if (car.IsRunning)
                    {
                        message = "Auto on käynnissä";
                    }
                    else
                    {
                        message = "Auto on sammutettu";
                    }

                    Console.WriteLine($"Nopeus: {car.CurrentSpeed} km/h, {message}");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Väärä muoto");
                }
            }
        }
    }
}