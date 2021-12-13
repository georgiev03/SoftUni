using System;

namespace _04.SumofTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = num1; i <= num2; i++)
            {
                for (int j = num1; j <= num2; j++)
                {
                    count++;
                    if (j + i == magicNum)
                    {
                        Console.WriteLine($"Combination N:{count} ({i} + {j} = {magicNum})");
                        Environment.Exit(0);
                    }
                }
            }
            Console.WriteLine($"{count} combinations - neither equals {magicNum}");
        }
    }
}
