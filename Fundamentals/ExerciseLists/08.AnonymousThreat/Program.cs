using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                string[] line = Console.ReadLine().Split();
                string command = line[0];

                if (command == "3:1")
                {
                    break;
                }

                if (command == "merge")
                {
                    int startIdx = int.Parse(line[1]);
                    int endIdx = int.Parse(line[2]);

                    if (startIdx > elements.Count || endIdx < 0)
                    {
                        continue;
                    }

                    if (startIdx < 0)
                    {
                        startIdx = 0;
                    }

                    if (endIdx >= elements.Count)
                    {
                        endIdx = elements.Count - 1;
                    }

                    string merged = string.Empty;

                    for (int i = startIdx; i <= endIdx; i++)
                    {
                        merged += elements[i];
                    }

                    elements.RemoveRange(startIdx, endIdx - startIdx + 1);
                    elements.Insert(startIdx, merged);
                }
                else
                {
                    int idx = int.Parse(line[1]);
                    int partitions = int.Parse(line[2]);

                    string element = elements[idx];

                    elements.RemoveAt(idx);

                    int partitionSize = element.Length / partitions;

                    List<string> substrings = new List<string>();

                    for (int i = 0; i < partitions - 1; i++)
                    {
                        string substring = element.Substring(i * partitionSize, partitionSize);
                        substrings.Add(substring);
                    }

                    string lastSubstring = element.Substring((partitions - 1) * partitionSize);
                    substrings.Add(lastSubstring);

                    elements.InsertRange(idx, substrings);
                }
            }

            Console.WriteLine(string.Join(' ', elements));
        }
    }
}
