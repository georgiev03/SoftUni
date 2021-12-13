using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string readLine = Console.ReadLine();
            bool isChanged = false;
            while (true)
            {
                string[] line = readLine.Split();
                string command = line[0];

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "Add":
                        {
                            int numberToAdd = int.Parse(line[1]);
                            numbers.Add(numberToAdd);
                            isChanged = true;
                            break;
                        }
                    case "Remove":
                        {
                            int numberToRemove = int.Parse(line[1]);
                            numbers.Remove(numberToRemove);
                            isChanged = true;
                            break;
                        }
                    case "RemoveAt":
                        {
                            int index = int.Parse(line[1]);
                            numbers.RemoveAt(index);
                            isChanged = true;
                            break;
                        }
                    case "Insert":
                        {
                            int number = int.Parse(line[1]);
                            int index = int.Parse(line[2]);
                            numbers.Insert(index, number);
                            isChanged = true;
                            break;
                        }
                    case "Contains":
                        {
                            int checkNum = int.Parse(line[1]);
                            if (numbers.Contains(checkNum))
                            {
                                Console.WriteLine("Yes");
                            }
                            else
                            {
                                Console.WriteLine("No such number");
                            }

                            break;
                        }
                    case "PrintEven":
                        {
                            List<int> evenNums = PrintEven(numbers);
                            Console.WriteLine(string.Join(" ", evenNums));
                            break;
                        }
                    case "PrintOdd":
                        {
                            List<int> oddNums = PrintOdd(numbers);
                            Console.WriteLine(string.Join(" ", oddNums));
                            break;
                        }
                    case "GetSum":
                    {
                        int sum = GetSum(numbers);
                        Console.WriteLine(sum);
                        break;
                    }
                    case "Filter":
                    {
                        string condition = line[1];
                        int number = int.Parse(line[2]);

                        List<int> filtered = FilterNumbers(numbers, condition, number);
                        Console.WriteLine(String.Join(" ", filtered));
                        break;
                    }
                }

                readLine = Console.ReadLine();
            }

            if (isChanged)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
        }

        private static List<int> FilterNumbers(List<int> list, string condition, int number)
        {
            List<int> filtered = new List<int>(list.Count);
            switch (condition)
            {
                case ">":
                   filtered = list.Where(n => n > number).ToList();
                    break;
                case "<":
                    filtered=list.Where(n => n < number).ToList();
                    break;
                case ">=":
                    filtered = list.Where(n => n >= number).ToList();
                    break;
                case "<=":
                    filtered = list.Where(n => n <= number).ToList();
                    break;
            }

            return filtered;
        }

        private static int GetSum(List<int> numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        private static List<int> PrintOdd(List<int> numbers)
        {
            List<int> oddNums = new List<int>(numbers.Count);

            foreach (int num in numbers)
            {
                if (num % 2 != 0)
                {
                    oddNums.Add(num);
                }
            }

            return oddNums;
        }
        private static List<int> PrintEven(List<int> numbers)
        {
            List<int> evenNums = new List<int>(numbers.Count);

            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                {
                    evenNums.Add(num);
                }
            }

            return evenNums;
        }
    }
}

