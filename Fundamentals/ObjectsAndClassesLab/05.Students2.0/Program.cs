using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students2._0
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
                bool isOverWritten = false;
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

                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].FirstName == firstName && students[i].LastName == lastName)
                    {
                        students[i].Age = age;
                        students[i].HomeTown = homeTown;
                        isOverWritten = true;
                    }
                }

                if (!isOverWritten)
                {
                    Student student = new Student
                    {
                        Age = age,
                        FirstName = firstName,
                        HomeTown = homeTown,
                        LastName = lastName
                    };

                    students.Add(student);
                }
            }

            string city = Console.ReadLine();

            List<Student> filteredStudents = students.Where(n => n.HomeTown == city).ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine("{0} {1} is {2} years old.", student.FirstName, student.LastName, student.Age);
            }
        }
    }
}
