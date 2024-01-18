using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tehtava
{
    class Student
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Int32 BirthDay { get; set; }
        public Int32 BirthMonth { get; set; }
        public Int32 BirthYear { get; set; }
        public Int32 Gender { get; set; }
        public Int32 StudentId { get; set; }

        public static Dictionary<string, dynamic> ListStudentInfo<String>(object student)
        {
            // muuntaa objectin ensin dictionaryksi, josta ottaa valuet values listaan
            var json = JsonSerializer.Serialize(student);
            var dictToConvert = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(json);

            var values = dictToConvert.Values.ToList();

            // luo uuden dictionaryn jossa keyt on suomen kielellä
            var dict = new Dictionary<string, dynamic>()
            {
                {"Etunimi",values[0]},
                {"Sukunimi",values[1]},
                {"Syntymäpäivä",$"{values[2]}.{values[3]}.{values[4]}"},
                {"Sukupuoli",values[5]},
                {"Opiskelijatunnus",values[6]}
            };

            return dict;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var studentList = new List<Dictionary<string, dynamic>>();

            Student student1 = new()
            {
                FirstName = "Kalle",
                LastName = "Luja",
                BirthDay = 15,
                BirthMonth = 06,
                BirthYear = 1999,
                Gender = 0,
                StudentId = 44345
            };

            Student student2 = new()
            {
                FirstName = "Pertti",
                LastName = "Erä",
                BirthDay = 09,
                BirthMonth = 02,
                BirthYear = 2003,
                Gender = 0,
                StudentId = 98258
            };

            Student student3 = new()
            {
                FirstName = "Maija",
                LastName = "Madagascar",
                BirthDay = 24,
                BirthMonth = 12,
                BirthYear = 2000,
                Gender = 1,
                StudentId = 75521
            };

            // muuntaa jokaisen student objectin dictionaryksi ListStudentInfo metodilla
            var dictStudent1 = Student.ListStudentInfo<string>(student1);
            var dictStudent2 = Student.ListStudentInfo<string>(student2);
            var dictStudent3 = Student.ListStudentInfo<string>(student3);

            studentList.Add(dictStudent1);
            studentList.Add(dictStudent2);
            studentList.Add(dictStudent3);

            Console.WriteLine("Opiskelijoiden tiedot:\n");

            for (int i = 0; i < studentList.Count; i++)
            {
                foreach (KeyValuePair<string, dynamic> kvp in studentList[i])
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }

                Console.WriteLine();
            }

        }
    }
}