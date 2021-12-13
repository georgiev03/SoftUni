using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _03.WordCount
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Dictionary<string, int> wordCounter = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("words.txt"))
            {
                string line = await reader.ReadLineAsync();

                while (line != null)
                {
                    string word = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray()[0].ToLower();

                    wordCounter[word] = 0;
                    line = await reader.ReadLineAsync();
                }
            }

            await using (StreamWriter writer = new StreamWriter("../../../actualResult.txt"))
            {
                using (StreamReader reader = new StreamReader("text.txt"))
                {
                    string line = await reader.ReadLineAsync();

                    while (line != null)
                    {
                        string[] words = line.Split()
                            .Select(x => x.TrimStart(new char[] {'-', ',', '.', '!', '?'}))
                            .Select(x => x.TrimEnd(new char[] {'-', ',', '.', '!', '?'}))
                            .Select(x => x.ToLower())
                            .ToArray();

                        foreach (var word in words)
                        {
                            if (wordCounter.ContainsKey(word))
                            {
                                wordCounter[word]++;
                            }
                        }

                        line = await reader.ReadLineAsync();
                    }

                    var sortedWords = wordCounter
                        .OrderByDescending(x => x.Value);

                    foreach (var kvp in sortedWords)
                    {
                        await writer.WriteLineAsync($"{kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }
    }
}
