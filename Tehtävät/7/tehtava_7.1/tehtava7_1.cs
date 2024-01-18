using System;

namespace Tehtava
{
    abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public abstract void Move();
    }

    class Adult : Person
    {
        public override void Move()
        {
            Console.WriteLine($"Olen {Name} ja ikäni on {Age}");
            Console.WriteLine("Liikkumismuotoni on käveleminen\n");
        }
    }

    class Baby : Person
    {
        public override void Move()
        {
            Console.WriteLine($"Olen {Name} ja ikäni on {Age}");
            Console.WriteLine("Liikkumismuotoni on konttaaminen\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adult adult = new()
            {
                Name = "Kalevi",
                Age = 26
            };

            Baby baby = new()
            {
                Name = "Jonne",
                Age = 2
            };

            adult.Move();
            baby.Move();
        }
    }
}