using System;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Console.WriteLine(GetMiddleChars(text));
        }

        private static string GetMiddleChars(string text)
        {
            string middleChars = "";

            if (text.Length % 2 == 0)
            {
                middleChars += text[(text.Length / 2) - 1];
                middleChars += text[text.Length / 2];
            }
            else
            {
                middleChars += text[text.Length / 2];
            }

            return middleChars;
        }
    }
}
