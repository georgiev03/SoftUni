using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string[] line = Console.ReadLine().Split();
                string command = line[0];

                if (command == "end")
                {
                    break;
                }
                
                int element = int.Parse(line[1]);

                if (command == "Delete")
                {
                    numbers.RemoveAll(n => n == element);
                }
                else
                {
                    int position = int.Parse(line[2]);

                    numbers.Insert(position, element);
                }

            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
