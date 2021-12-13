using System;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            while (word != "END")
            {
                bool IsBoolean = bool.TryParse(word, out bool boolean);
                bool Isinteger = int.TryParse(word, out int integer);
                bool IsCharacter = char.TryParse(word, out char character);
                bool IsDouble = double.TryParse(word, out double floating);

                if (IsBoolean)
                {
                    Console.WriteLine($"{word} is boolean type");
                }
                else if (Isinteger)
                {
                    Console.WriteLine($"{word} is integer type");
                }
                else if (IsCharacter)
                {
                    Console.WriteLine($"{word} is character type");
                }
                else if (IsDouble)
                {
                    Console.WriteLine($"{word} is floating point type");
                }
                else
                {
                    Console.WriteLine($"{word} is string type");
                }

                word = Console.ReadLine();
            }
        }
    }
}
