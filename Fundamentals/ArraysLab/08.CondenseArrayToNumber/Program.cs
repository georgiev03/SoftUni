using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Xml.Serialization;

namespace _08.CondenseArrayToNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int counter = arr.Length;

            while (counter > 1)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i] + arr[i + 1];
                }

                counter--;
            }

            Console.WriteLine(arr[0]);
        }
    }
}
