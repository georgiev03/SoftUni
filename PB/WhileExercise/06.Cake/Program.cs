using System;

namespace _06.Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int cake = length * width;

            string pieces = Console.ReadLine();
            while (pieces != "STOP")
            {
                cake -= int.Parse(pieces);
                if(cake <= 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(cake)} pieces more.");
                    break;
                }
                pieces = Console.ReadLine();
            }
            if(pieces == "STOP")
            {
                Console.WriteLine($"{cake} pieces are left.");
            }
        }
    }
}
