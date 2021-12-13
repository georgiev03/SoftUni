using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split(" : ");

                string course = tokens[0];
                string student = tokens[1];

                if (courses.ContainsKey(course))
                {
                    courses[course].Add(student);
                }
                else
                {
                    courses.Add(course, new List<string> {student});
                }
            }

            var sortedCourses = courses
                .OrderByDescending(x => x.Value.Count);

            foreach (var kvp in sortedCourses)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                foreach (var student in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
