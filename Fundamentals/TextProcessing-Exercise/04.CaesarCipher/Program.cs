using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder result = new StringBuilder();

            foreach (var symbol in text)
            {
                result.Append((char)(symbol + 3));
            }

            Console.WriteLine(result);
        }
    }
}
