﻿using System;

namespace _07.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                int n2 = int.Parse(Console.ReadLine());
                sum += n2;
            }
            Console.WriteLine(sum);
        }

    }
}
