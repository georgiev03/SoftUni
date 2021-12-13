using System;

namespace _02.RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split();

            string result = string.Empty;

            foreach (var word in words)
            {
                foreach (var t in word)
                {
                    result += word;
                }
            }

            Console.WriteLine(result);
        }
    }
}
