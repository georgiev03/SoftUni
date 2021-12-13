using System;
using System.IO;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] lines = await File.ReadAllLinesAsync("text.txt");
            int linesCount = 0;
            foreach (var line in lines)
            {
                int lettersCount = CountOfLetters(line);
                int punctCount = CountOfPunctunal(line);

                lines[linesCount++] = $"Line {linesCount}: {line} ({lettersCount})({punctCount})";
            }

            await File.WriteAllLinesAsync("output.txt", lines);
        }

        private static int CountOfPunctunal(string line)
        {
            int count = 0;

            foreach (var symbol in line)
            {
                if (char.IsPunctuation(symbol))
                {
                    count++;
                }
            }

            return count;
        }

        private static int CountOfLetters(string line)
        {
            int count = 0;

            foreach (var symbol in line)
            {
                if (char.IsLetter(symbol))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
