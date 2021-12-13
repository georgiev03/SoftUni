using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split();

                Student student = new Student
                {
                    FirstName = info[0],
                    LastName = info[1],
                    Grade = double.Parse(info[2])
                };

                students.Add(student);
            }

            List<Student> orderedStudents = students
                .OrderBy(x => x.Grade)
                .ToList();

            orderedStudents.Reverse();

            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
