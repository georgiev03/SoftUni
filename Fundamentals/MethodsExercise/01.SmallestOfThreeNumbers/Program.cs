﻿using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int min = GetMinNum(first, second, third);

            Console.WriteLine(min);
        }

        private static int GetMinNum(int first, int second, int third)
        {
            int min = Math.Min(Math.Min(first, second), third);

            return min;
        }
    }
}
