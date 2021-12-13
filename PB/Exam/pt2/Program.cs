using System;

namespace pt2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int days = 1;
            int start = 5364;
            bool succeeded = false;
            while (input != "END")
            {
                int meters = int.Parse(Console.ReadLine());
                if (input == "Yes")
                {
                    days++;
                    if (days > 5)
                    {
                        break;
                    }
                }
                start += meters;
                if (start >= 8848)
                {
                    succeeded = true;
                    break;
                }
                input = Console.ReadLine();
            }
            if (succeeded)
            {
                Console.WriteLine($"Goal reached for {days} days!");
            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine($"{start}");
            }
        }
    }
}
