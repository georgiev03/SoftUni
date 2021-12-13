using System;

namespace _09.CharToString
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());
            string word = string.Concat(a, b, c);
            Console.WriteLine(word);
        }
    }
}
