using System;

namespace _01.SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string result = SignPrint(num);

            Console.WriteLine($"The number {num} is {result}.");
        }

        static string SignPrint(int n)
        {
            string sign = "";
            if (n > 0)
            {
                sign = "positive";
            }
            else if (n < 0)
            {
                sign = "negative";
            }
            else
            {
                sign = "zero";
            }

            return sign;
        }
    }
}
