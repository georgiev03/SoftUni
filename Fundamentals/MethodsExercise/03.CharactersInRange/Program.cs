﻿using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            char start = first;
            char end = second;

            if(second< first)
            {
                start = second;
                end = first;
            }

            PrintCharsBetween(start, end);
        }

        private static void PrintCharsBetween(char start, char end)
        {
            for (char i = (char)(start + 1); i < end; i++)
            {
                Console.Write($"{i} ");
            }
        }
    }
}
