using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> grades = new Dictionary<string, double[]>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (grades.ContainsKey(name))
                {
                    grades[name][0] += grade;
                    grades[name][1] ++;
                }
                else
                {
                    grades.Add(name, new []{grade, 1});
                }
            }

            Dictionary<string, double> sortedStudents = grades
                .Where(g => g.Value[0] / g.Value[1] >= 4.5)
                .ToDictionary(n => n.Key, g => g.Value[0] / g.Value[1]);

            sortedStudents = sortedStudents.OrderByDescending(g => g.Value)
                .ToDictionary(n => n.Key, g => g.Value);

            foreach (var kvp in sortedStudents)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:f2}");
            }
        }
    }
}
