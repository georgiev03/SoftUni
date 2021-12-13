using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int num = int.Parse(Console.ReadLine());

            Predicate<int> predicate = n => n % num != 0;

            Console.WriteLine(string.Join(" ", arr.Reverse().Where(x => predicate(x))));
        }
    }
}
