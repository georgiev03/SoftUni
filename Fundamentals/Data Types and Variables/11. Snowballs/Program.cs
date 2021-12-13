﻿using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int bestsnowballSnow = 0;
            int bestsnowballTime = 0;
            int bestsnowballQuality = 0;
            BigInteger bestsnowballValue = 0;

            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);
                if (snowballValue > bestsnowballValue)
                {
                    bestsnowballSnow = snowballSnow;
                    bestsnowballTime = snowballTime;
                    bestsnowballQuality = snowballQuality;
                    bestsnowballValue = snowballValue;
                }
            }

            Console.WriteLine($"{bestsnowballSnow} : {bestsnowballTime} = {bestsnowballValue} ({bestsnowballQuality})");
        }
    }
}
