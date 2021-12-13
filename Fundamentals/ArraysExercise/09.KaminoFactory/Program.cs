using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int idx = int.MaxValue;
            int bestSeq = 0;
            int sum = 0;

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split("!", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Clone them")
                {
                    break;
                }

                int[] sample = command
                    .Select(int.Parse)
                    .ToArray();

                int currSeq = 0;

                for (int i = length - 1; i > 0; i--)
                {
                    if (sample[i] == 1 && sample[i] == sample[i - 1])
                    {
                        currSeq++;
                    }
                    else
                    {
                        if (currSeq >= bestSeq && i <= idx)
                        {
                            if (sample.Sum() > sum)
                            {
                                sum = sample.Sum();
                                bestSeq = currSeq;
                                idx = i;
                            }
                        }
                        currSeq = 0;
                    }
                }
                
            }

            Console.WriteLine(idx);
            Console.WriteLine(bestSeq);
            Console.WriteLine(sum);

        }
    }
}
