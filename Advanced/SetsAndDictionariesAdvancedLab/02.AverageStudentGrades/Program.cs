using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal mark = decimal.Parse(input[1]);

                if (!grades.ContainsKey(name))
                {
                    grades[name] = new List<decimal>();
                }

                grades[name].Add(mark);
            }

            foreach (var kvp in grades)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(" ", kvp.Value.Select(v => v.ToString("f2")))} " +
                                  $"(avg: {kvp.Value.Average():f2})");
            }
        }
    }
}
