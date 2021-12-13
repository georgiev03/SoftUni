using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int bestSequence = 1;
            int bestNum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int sequence = 1;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        sequence++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (sequence > bestSequence)
                {
                    bestSequence = sequence;
                    bestNum = arr[i];
                }
            }

            for (int i = 0; i < bestSequence; i++)
            {

                Console.Write(bestNum + " ");
            }
        }
    }
}
