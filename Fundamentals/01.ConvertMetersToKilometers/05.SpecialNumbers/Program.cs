using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            for (int i = 1; i <= n; i++)
            {
                int digitsSum = 0;
                int digit = i;
                while (digit> 0)
                {
                    digitsSum += digit % 10;
                    digit /= 10;
                }

                Console.WriteLine($"{i} -> {digitsSum == 5 || digitsSum == 7 || digitsSum == 11}");
            }
        }
    }
}
