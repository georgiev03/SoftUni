using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            Dictionary<char, int> charsCount = new Dictionary<char, int>();

            foreach (var word in input)
            {
                foreach (var letter in word)
                {
                    if (charsCount.ContainsKey(letter))
                    {
                        charsCount[letter]++;
                    }
                    else
                    {
                        charsCount.Add(letter, 1);
                    }
                }
            }

            foreach (var letter in charsCount)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");   
            }
        }
    }
}
