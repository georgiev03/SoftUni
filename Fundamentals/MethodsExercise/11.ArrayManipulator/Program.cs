using System;
using System.Linq;
using System.Security.Authentication;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                string[] parts = line.Split();
                string command = parts[0];

                if (command == "exchange")
                {
                    int index = int.Parse(parts[1]);

                    Exchange(numbers, index);
                }
                else if (command == "max")
                {
                    string evenOrOdd = parts[1];
                    int index = GetMax(numbers, evenOrOdd);

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }
                else if (command == "min")
                {
                    string evenOrOdd = parts[1];
                    int index = GetMin(numbers, evenOrOdd);

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }
                else if (command == "first")
                {
                    int count = int.Parse(parts[1]);
                    string evenOrOdd = parts[2];

                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    int[] firstNumbers = GetFirstNums(numbers, count, evenOrOdd);
                    bool isFound = false;

                    PrintArry(firstNumbers);
                }
                else if (command == "last")
                {
                    int count = int.Parse(parts[1]);
                    string evenOrOdd = parts[2];

                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    int[] lastNumbers = GetLastNums(numbers, count, evenOrOdd);
                    PrintArry(lastNumbers);
                    
                }
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static void PrintArry(int[] elements)
        {
            bool isFound = false;

            Console.Write("[");

            foreach (var number in elements)
            {
                if (number != -1)
                {
                    if (isFound)
                    {
                        Console.Write($", {number}");
                    }
                    else
                    {
                        Console.Write($"{number}");
                        isFound = true;
                    }
                }
            }

            Console.WriteLine("]");
        }

        private static int[] GetLastNums(int[] numbers, int count, string evenOrOdd)
        {
            int[] result = new int[count];
            int index = 0;
            int parity = 1;

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }

            if (evenOrOdd == "even")
            {
                parity = 0;
            }

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                int number = numbers[i];
                if (number % 2 == parity)
                {
                    result[index] = number;
                    index++;

                    if (index >= result.Length)
                    {
                        break;
                    }
                }
            }

            return result.Reverse().ToArray();
        }

        private static int[] GetFirstNums(int[] numbers, int count, string evenOrOdd)
        {
            int[] result = new int[count];
            int index = 0;
            int parity = 1;

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = -1;
            }

            if (evenOrOdd == "even")
            {
                parity = 0;
            }

            foreach (int number in numbers)
            {
                if (number % 2 == parity)
                {
                    result[index] = number;
                    index++;

                    if (index >= result.Length)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        private static int GetMin(int[] numbers, string evenOrOdd)
        {
            int index = -1;
            int parity = 1; //number % 2 == x

            if (evenOrOdd == "even")
            {
                parity = 0;
            }

            int minNum = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNum = numbers[i];

                if (currentNum <= minNum &&
                    currentNum % 2 == parity)
                {
                    index = i;
                    minNum = currentNum;
                }
            }

            return index;
        }

        private static int GetMax(int[] numbers, string evenOrOdd)
        {
            int parity = 1; //number % 2 == x
            if (evenOrOdd == "even")
            {
                parity = 0;
            }
            
            int index = -1;
            int maxNum = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNum = numbers[i];

                if (currentNum >= maxNum &&
                    currentNum % 2 == parity)
                {
                    index = i;
                    maxNum = currentNum;
                }
            }

            return index;
        }

        private static void Exchange(int[] numbers, int index)
        {
            if (index < 0 || index >= numbers.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            for (int i = 0; i <= index; i++)
            {
                int firstDigit = numbers[0];

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }

                numbers[numbers.Length - 1] = firstDigit;
            }

        }
    }
}
