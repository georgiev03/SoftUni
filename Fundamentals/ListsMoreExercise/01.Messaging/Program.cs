using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string message = Console.ReadLine();

            int[] summedNums = new int[numbers.Count];

            for (int i = 0; i < numbers.Count; i++)
            {
                while (numbers[i] > 0)
                {
                    summedNums[i] += numbers[i] % 10;
                    numbers[i] /= 10;
                }
            }

            string output = string.Empty;
            
            for (int i = 0; i < summedNums.Length; i++)
            {
                int currentNum = summedNums[i];

                if (currentNum > message.Length)
                {
                    currentNum -= message.Length ;
                }
                for (int j = 0; j < message.Length; j++)
                {
                    if (currentNum == j)
                    {
                        output += message[j];
                        message = message.Remove(j, 1);
                    }
                }
            }

            Console.WriteLine(output);
        }
    }
}
