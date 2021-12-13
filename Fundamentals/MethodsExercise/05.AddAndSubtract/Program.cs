using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

           int sum = GetSum(first, second);
           int subtract = GetSubtraction(sum, third);

           Console.WriteLine(subtract);
        }

        private static int GetSubtraction(int first, int second)
        {
            int subtraction = first - second;

            return subtraction;
        }

        private static int GetSum(int first, int second)
        {
            int sum = first + second;

            return sum;
        }
    }
}
