using System;

namespace _08.Numbersequence
{
    class Program
    {
        static void Main(string[] args)
        {
            // Напишете програма, която чете n на брой цели числа. Принтирайте най-голямото и най-малкото число сред въведените.

            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int min = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                int num2 = int.Parse(Console.ReadLine());

                if (num2 >= max)
                {
                    max = num2;
                }
                if (num2 <= min)
                {
                    min = num2;
                }
            }
            Console.WriteLine("Max number: " + max);
            Console.WriteLine("Min number: " + min);
        }
    }
}
