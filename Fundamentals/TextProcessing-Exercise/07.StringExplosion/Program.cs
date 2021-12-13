using System;
using System.Text;

namespace _07.StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int bomb = 0;

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '>')
                {
                    bomb += text[i + 1] - '0';
                    result.Append(text[i]);
                }
                else if (bomb > 0)
                {
                    bomb--;
                }
                else
                {
                    result.Append(text[i]);
                }
            }

            Console.WriteLine(result);
        }
    }
}
