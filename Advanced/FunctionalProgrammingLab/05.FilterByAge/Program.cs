using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<(string name, int age)> people = new List<(string name, int age)>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people.Add((info[0], int.Parse(info[1])));
            }

            Func<(string name, int age), int, bool> younger = (person, age) => person.age < age;
            Func<(string name, int age), int, bool> older = (person, age) => person.age >= age;

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            if (condition == "younger")
            {
                people = people.Where(p => younger(p, age))
                    .ToList();
            }
            else if(condition == "older")
            {
                people = people.Where(p => older(p, age))
                    .ToList();
            }

            foreach (var person in people)
            {
                List<string> output = new List<string>();

                if (format.Contains("name"))
                {
                    output.Add(person.name);
                }

                if (format.Contains("age"))
                {
                    output.Add(person.age.ToString());
                }

                Console.WriteLine(string.Join(" - ", output));
            }
        }
    }
}
