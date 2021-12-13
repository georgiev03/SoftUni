using System;
using System.Runtime.Loader;

namespace _05.Digits_LettersandOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string numbers = string.Empty;
            string letters = string.Empty;
            string others = string.Empty;

            foreach (var symbol in input)
            {
                if (char.IsDigit(symbol))
                {
                    numbers += symbol;
                }
                else if (char.IsLetter(symbol))
                {
                    letters += symbol;
                }
                else
                {
                    others += symbol;
                }
            }

            Console.WriteLine(numbers);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
