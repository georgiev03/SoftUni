using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();

            int volwels = VolwelsCount(text);

            Console.WriteLine(volwels);
        }

        private static int VolwelsCount(string text)
        {
            int count = 0;

            foreach (char letter in text)
            {
                if (letter == 'a' ||
                    letter == 'u' ||
                    letter == 'y' ||
                    letter == 'e' ||
                    letter == 'o' ||
                    letter == 'i')
                {
                    count++;
                }
            }

            return count;
        }
    }
}
