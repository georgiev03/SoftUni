using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string[] line = Console.ReadLine().Split();
                string command = line[0];

                if (command == "End")
                {
                    break;
                }

                if (command == "Add")
                {
                    int number = int.Parse(line[1]);
                    numbers.Add(number);
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(line[1]);
                    int index = int.Parse(line[2]);

                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.Insert(index, number);
                }
                else if(command == "Remove")
                {
                    int index = int.Parse(line[1]);

                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.RemoveAt(index);
                }
                else if (command == "Shift")
                {
                    string side = line[1];
                    int times = int.Parse(line[2]);

                    if (side == "left")
                    {
                        for (int i = 0; i < times; i++)
                        {
                            int firstNum = numbers[0];

                           numbers.RemoveAt(0);
                           numbers.Add(firstNum);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < times; i++)
                        {
                            int lastNum = numbers[numbers.Count - 1];

                            numbers.RemoveAt(numbers.Count -1);
                            numbers.Insert(0, lastNum);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
