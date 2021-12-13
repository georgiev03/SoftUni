using System;
using System.Collections.Generic;

namespace _01.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> nameAndAge = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                int startName = text.IndexOf('@');
                int endName = text.IndexOf('|');

                int startAge = text.IndexOf('#');
                int endAge = text.IndexOf('*');

                string name = text.Substring(startName + 1, endName - startName - 1);
                string age = text.Substring(startAge + 1, endAge - startAge - 1);

                nameAndAge.Add(name, age);
            }

            foreach (var kvp in nameAndAge)
            {
                Console.WriteLine($"{kvp.Key} is {kvp.Value} years old.");
            }
        }
    }
}
