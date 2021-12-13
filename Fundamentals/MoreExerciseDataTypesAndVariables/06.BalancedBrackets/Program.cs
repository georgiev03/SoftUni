using System;

namespace _06.BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool IsOpened = false;
            bool IsBalanced = false;


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                if (input == "(")
                {
                    IsOpened = true;
                    IsBalanced = false;
                }

                if (IsOpened && input == ")")
                {
                    IsBalanced = true;
                    IsOpened = false;
                    continue;
                }

                if (input == ")")
                {
                    IsBalanced = false;
                }
                
            }

            if (IsBalanced && !IsOpened)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
