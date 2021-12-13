using System;

namespace _01.Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int m = 0; m < 60; m++)
                {
                    Console.WriteLine($"{i}:{m}");
                }
            }
        }
    }
}
