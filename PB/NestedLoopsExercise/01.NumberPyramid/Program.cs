using System;

namespace _01.NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    Console.Write($"{num++} ");
                    if(num > n)
                    {
                        break;
                    }
                }
                if (num > n)
                {
                    break;
                }
                Console.WriteLine();

            }
        }
    }
}
