using System;

namespace ForLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = "SoftUni";

            //Console.WriteLine(text.Length);

            //Console.WriteLine(text[4]);

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
            }
        }
    }
}
