using System;

namespace Tehtava
{
    class Program
    {
        static void Main(string[] args)
        {   
            // luo listan johon lisätään oppilaat
            var students = new List<String>();

            for (int i = 0; i < 5; i++)
            {   
                // kysyy oppilaan nimen ja lisää listaan
                Console.WriteLine("Anna oppilaan nimi:");
                string student = Convert.ToString(Console.ReadLine());
                students.Add(student);
            }

            Console.WriteLine("Tallennetut oppilaat:");

            // tulostaa oppilaiden nimet
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}