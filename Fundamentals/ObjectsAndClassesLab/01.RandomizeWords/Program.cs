using System;

namespace _01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split();

            Random random = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int rdm = random.Next(words.Length);

                string word = words[i];
                words[i] = words[rdm];
                words[rdm] = word;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
