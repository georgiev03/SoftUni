using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();
            Stack<char> skoba = new Stack<char>();

            bool sequence = true;

            for (int i = 0; i < input.Length / 2; i++)
            {
                indexes.Push(i);
                skoba.Push(input[i]);
            }

            for (int i = input.Length / 2; i < input.Length; i++)
            {
                char currSkoba = skoba.Pop();
                int idx = indexes.Pop();

                switch (currSkoba)
                {
                    case '(':
                        if()
                        break;
                }
            }
        }
    }
}
