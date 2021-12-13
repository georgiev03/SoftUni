using System;
using System.Collections.Generic;

namespace _04.Students
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] data = line.Split();

                string firstName = data[0];
                string lastName = data[1];
                int age = int.Parse(data[2]);
                string homeTown = data[3];

                Student student = new Student
                {
                    Age = age,
                    FirstName = firstName,
                    HomeTown = homeTown,
                    LastName = lastName
                };


                students.Add(student);
            }

            string city = Console.ReadLine();

            foreach (Student student in students)
            {
                if (city == student.HomeTown)
                {
                    Console.WriteLine("{0} {1} is {2} years old.", student.FirstName, student.LastName, student.Age);
                }
            }
        }
    }
}
