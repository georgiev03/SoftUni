using System;
using System.Collections.Generic;

namespace _1.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> charStack = new Stack<char>();

            foreach (var VARIABLE in input)
            {
                charStack.Push(VARIABLE);
            }

            while (charStack.Count != 0)
            {
                Console.Write(charStack.Pop());
            }

            charStack.TrimExcess();
            
        }
    }
}
