using System;
using System.Globalization;
using System.Text;

namespace _05.HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Decode")
                {
                    break;
                }

                string[] tokens = command.Split('|');

                if (tokens[0] == "Move")
                {
                    int n = int.Parse(tokens[1]);

                    for (int i = 0; i < n; i++)
                    {
                        text += text[i];
                    }

                    text = text.Remove(0, n);
                }
                else if (tokens[0] == "Insert")
                {
                    int idx = int.Parse(tokens[1]);
                    string value = tokens[2];
                    text = text.Insert(idx, value);
                }
                else
                {
                    char substring = char.Parse(tokens[1]);
                    char replacement =char.Parse(tokens[2]);

                   text = text.Replace(substring, replacement);
                }
            }

            Console.WriteLine(text);

        }
    }
}
