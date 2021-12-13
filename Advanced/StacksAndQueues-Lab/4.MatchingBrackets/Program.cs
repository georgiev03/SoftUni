using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> bracket = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '(')
                {
                    bracket.Push(i);
                }

                if (input[i] == ')')
                {
                    int idx = bracket.Pop();

                    Console.WriteLine(input.Substring(idx, i - idx + 1));
                }
            }
        }
    }
}
