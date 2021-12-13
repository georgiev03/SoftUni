using System;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string pass = Console.ReadLine();
            string passCheck = Console.ReadLine();

            while (pass != passCheck)
            {
                passCheck = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {user}!");
        }
    }
}
