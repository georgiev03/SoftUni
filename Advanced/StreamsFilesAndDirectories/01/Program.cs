using System;
using System.IO;
using System.Threading.Tasks;

namespace _01_OddLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader str = new StreamReader("TextFile1.txt"))
            {
                int currLine = 0;
                string line = await str.ReadLineAsync();

                while (line != null) 
                {
                    if (currLine % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    currLine++;
                    line = await str.ReadLineAsync();
                }
            }
        }
    }
}
