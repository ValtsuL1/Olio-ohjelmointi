using System;
using System.Windows.Markup;

namespace Tehtava
{
    class Person
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string BirthDate {get;set;}
        public string Address {get;set;}
        public string ContactNumber {get;set;}
    }
    class Student : Person
    {
        public int StudentID {get;set;}
        public string Degree {get;set;}

        public override string ToString()
        {
            return $"Student - ToString {FirstName} {LastName} {BirthDate} {Address} {ContactNumber} {StudentID} {Degree}";
        }  
    }
    class ExhangeStudent : Person
    {
        public string Degree {get;set;}
        public string HomeCountry {get;set;}

        public override string ToString()
        {
            return $"ExhangeStudent - ToString {FirstName} {LastName} {BirthDate} {Address} {ContactNumber} {Degree} {HomeCountry}";
        } 
    }
    
    class Teacher : Person
    {
        public float MonthlySalary {get;set;}

        public override string ToString()
        {
            return $"Teacher - ToString {FirstName} {LastName} {BirthDate} {Address} {ContactNumber} {MonthlySalary} €";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new()
            {
                FirstName = "Jorma",
                LastName = "Jortikka",
                BirthDate = "20.05.1998",
                Address = "Kulkusenkuja 13 A 44",
                ContactNumber = "+358449967554",
                StudentID = 55623,
                Degree = "Tieto- ja viestintätekniikka"
            };

            ExhangeStudent exhangeStudent = new()
            {
                FirstName = "Trevor",
                LastName = "Philips",
                BirthDate = "04.05.1985",
                Address = "Väylätie 74 A 82",
                ContactNumber = "+358445567859",
                Degree = "Rakennusmestari",
                HomeCountry = "Kanada"
            };

            Teacher teacher = new()
            {
                FirstName = "Kari",
                LastName = "Jalonen",
                BirthDate = "19.11.1975",
                Address = "Kirkkokatu 7",
                ContactNumber = "+358452769043",
                MonthlySalary = 3940
            };

            Console.WriteLine(student.ToString());
            Console.WriteLine();

            Console.WriteLine(exhangeStudent.ToString());
            Console.WriteLine();

            Console.WriteLine(teacher.ToString());
        }
    }
}