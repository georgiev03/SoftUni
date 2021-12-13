using System;

namespace _09.SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int days = 0;
            int spice = 0;
            if (start < 100)
            {
                Console.WriteLine(days);
                Console.WriteLine(spice);
            }
            else
            {
                for (int i = start; i >= 100; i -= 10)
                {
                    days++;
                    spice += i - 26;
                }

                Console.WriteLine(days);
                Console.WriteLine(spice - 26);
            }
        }
    }
}
