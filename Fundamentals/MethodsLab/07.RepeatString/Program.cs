using System;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());
            string result = RepeatingString(input, times);

            Console.WriteLine(result);
        }

        static string RepeatingString(string input, int times)
        {
            string result = "";
            for (int i = 0; i < times; i++)
            {
                result += input;
            }

            return result;
        }
    }
}
