using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.EvenLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            char[] charToReplace = { '-', ',', '.', '!', '?' };

            using StreamReader reader = new StreamReader("text.txt");
            await using StreamWriter writer = new StreamWriter("output.txt");
            int count = 0;

            while (!reader.EndOfStream)
            {
                string line = await reader.ReadLineAsync();

                if (line == null)
                {
                    break;
                }

                if (count % 2 == 0)
                {
                    line = ReplaceAll(charToReplace, line, '@');
                    line = Reverse(line);
                    await writer.WriteLineAsync(line);
                    Console.WriteLine(line);
                }

                count++;
            }
        }

        private static string Reverse(string line)
        {
            StringBuilder sb = new StringBuilder();
            string[] words = line.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                sb.Append(words[words.Length - i - 1]);
                sb.Append(' ');
            }

            return sb.ToString().TrimEnd();
        }

        private static string ReplaceAll(char[] charToReplace, string line, char symbol)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                if (charToReplace.Contains(line[i]))
                {
                    sb.Append(symbol);
                }
                else
                {
                    sb.Append(line[i]);
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
