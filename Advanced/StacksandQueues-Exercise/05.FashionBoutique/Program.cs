using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());
            int freeSpace = rackCapacity;
            int racks = 1;
            int currSum = 0;

            Stack<int> clothes = new Stack<int>(input);

            while (clothes.Count > 0)
            {
                if (currSum + clothes.Peek() <= freeSpace)
                {
                    currSum += clothes.Pop();
                }
                else
                {
                    racks++;
                    currSum = 0;
                    freeSpace = rackCapacity;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
