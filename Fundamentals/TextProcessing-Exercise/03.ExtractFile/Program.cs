using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] location = Console.ReadLine().Split('\\');

            string file = location[^1];

            int idx = file.LastIndexOf('.');
            string name = file.Substring(0, idx);
            string extension = file.Substring(idx + 1);

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
