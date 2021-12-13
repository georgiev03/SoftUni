using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                int command = int.Parse(input[0]);

                if (command == 4 && stack.Any())
                {
                    stack.Pop();
                }
                else if (command == 1)
                {
                    stack.Push(input[1]);
                }
                else if (command == 2 && stack.Any())
                {
                    string last = stack.Peek();
                    last = last.Substring(0, last.Length - int.Parse(input[1]));

                    stack.Push(last);
                }
                else if (command == 3 && stack.Any())
                {
                    int idx = int.Parse(input[1]) - 1;
                    string last = stack.Peek();

                    Console.WriteLine(last[idx]);
                }
            }
        }
    }
}
