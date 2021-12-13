using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int len = int.Parse(Console.ReadLine());

            Predicate<string> predicate = n => n.Length <= len;

            Console.ReadLine()
               .Split()
               .Where(n => predicate(n))
               .ToList()
               .ForEach(n => Console.WriteLine(n));


        }
    }
}
