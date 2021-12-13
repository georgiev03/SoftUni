using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string banWord = Console.ReadLine().ToLower();
            string input = Console.ReadLine();

            string result = input;

            while (result.Contains(banWord))
            {
               result = result.Replace(banWord, "");
            }

            Console.WriteLine(result);

        }
    }
}
