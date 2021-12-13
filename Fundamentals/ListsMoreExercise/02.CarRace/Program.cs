using System;
using System.Linq;

namespace _02.CarRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            double leftTime = 0;
            double rightTime = 0;

            for (int i = 0; i < numbers.Length / 2; i++)
            {
                int currentTime = numbers[i];
                leftTime += currentTime;

                if (currentTime == 0)
                {
                    leftTime *= 0.8;
                }
            }

            for (int i = numbers.Length - 1; i > numbers.Length / 2; i--)
            {
                int currentTime = numbers[i];
                rightTime += currentTime;

                if (currentTime == 0)
                {
                    rightTime *= 0.8;
                }
            }
            if (leftTime < rightTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightTime}");
            }
        }
    }
}
