using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string a = Console.ReadLine();

            while (true)
            {
                string[] line = a.Split();
                string command = line[0];

                if (command == "end")
                {
                    break;
                }

                if (command == "Add")
                {
                    int numberToAdd = int.Parse(line[1]);
                    numbers.Add(numberToAdd);
                }
                else if (command == "Remove")
                {
                    int numberToRemove = int.Parse(line[1]);
                    numbers.Remove(numberToRemove);
                }
                else if (command == "RemoveAt")
                {
                    int index = int.Parse(line[1]);
                    numbers.RemoveAt(index);
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(line[1]);
                    int index = int.Parse(line[2]);
                    numbers.Insert(index, number);
                }

                a = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
