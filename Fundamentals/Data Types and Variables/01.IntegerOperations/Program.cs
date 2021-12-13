using System;

namespace _01.IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int fouth = int.Parse(Console.ReadLine());

            Console.WriteLine(((first + second)/third)*fouth);
        }
    }
}
