using System;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] bugs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] field = new int[fieldSize];

            foreach (var bug in bugs)
            {
                if (bug >= fieldSize || bug < 0)
                {
                    continue;
                }

                field[bug] = 1;
            }

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens[0] == "end")
                {
                    break;
                }

                int idx = int.Parse(tokens[0]);
                string direction = tokens[1];
                int jump = int.Parse(tokens[2]);

                if (idx < 0 || idx >= fieldSize || field[idx] == 0)
                {
                    continue;
                }

                field[idx] = 0;

                if (direction == "right")
                {
                    idx += jump;

                    while (idx < fieldSize)
                    {
                        if (field[idx] == 0)
                        {
                            field[idx] = 1;
                            break;
                        }

                        idx+= jump;
                    }
                }
                else
                {
                    idx -= jump;

                    while (idx >= 0)
                    {
                        if (field[idx] == 0)
                        {
                            field[idx] = 1;
                            break;
                        }

                        idx -= jump;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
