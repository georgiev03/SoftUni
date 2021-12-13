using System;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            char lastLetter = '\0';

            foreach (char letter in input)
            {
                if (letter != lastLetter)
                {
                    result.Append(letter);
                }

                lastLetter = letter;
            }

            Console.WriteLine(result);
        }
    }
}
