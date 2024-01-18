using System;

namespace Tehtava
{
    class Car
    {
        private float CurrentSpeed {get;set;}
        private bool EngineStarted {get;set;}
        private bool DoorsOpen {get;set;}
        private float FuelLevel {get;set;}
        private float MaxSpeed {get;set;}

        // Sleep metodi käytössä selkeyden vuoksi
        public void StartEngine()
        {
            EngineStarted = true;
            Console.WriteLine("Moottori käynnistetty.");
            Thread.Sleep(250);
        }

        public void StopEngine()
        {
            EngineStarted = false;
            Console.WriteLine("Moottori sammutettu.");
            Thread.Sleep(250);
        }

        public void Accelerate()
        {
            Console.WriteLine("Kiihdytetään...");
            while (CurrentSpeed != MaxSpeed)
            {
                if (FuelLevel > 0 && EngineStarted)
                {
                    CurrentSpeed += 5;
                }
                else
                {
                    break;
                }

                if (CurrentSpeed > MaxSpeed)
                {
                    CurrentSpeed = MaxSpeed;
                }
                Console.WriteLine($"Nopeus: {CurrentSpeed} km/h");
                Thread.Sleep(250);
            }
        }

        public void Brake()
        {
            Console.WriteLine("Jarrutetaan...");
            while (CurrentSpeed != 0)
            {
                if (CurrentSpeed > 0)
                {
                    CurrentSpeed -= 5;
                }
                if (CurrentSpeed < 0)
                {
                    CurrentSpeed = 0;
                }
                Console.WriteLine($"Nopeus: {CurrentSpeed} km/h");
                Thread.Sleep(250);
            }
        }

        public void LockDoors()
        {
            if (CurrentSpeed == 0 && !EngineStarted)
            {
                DoorsOpen = false;
                Console.WriteLine("Ovet lukittu.");
                Thread.Sleep(250);
            }
        }

        public void AddFuel(float fuel)
        {
            FuelLevel = fuel;
        }

        public void SetMaxSpeed(float speed)
        {
            MaxSpeed = speed;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new();

            car.StartEngine();
            car.SetMaxSpeed(100);
            car.AddFuel(20);

            car.Accelerate();
            car.Brake();

            car.StopEngine();
            car.LockDoors();
        }
    }
}