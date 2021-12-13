using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = 0;

            while (elements.Count > 0)
            {
                int idx = int.Parse(Console.ReadLine());
                int removed;

                if (idx < 0)
                {
                    int lastElement = elements[^1];
                    removed = elements[0];

                    elements.Insert(0, lastElement);
                    elements.RemoveAt(0);
                }
                else if (idx >= elements.Count)
                {
                    removed = elements[^1];

                    elements.RemoveAt(elements.Count - 1);
                    elements.Add(elements[0]);
                }
                else
                {
                    removed = elements[idx];
                    elements.RemoveAt(idx);
                }

                sum += removed;

                for (int i = 0; i < elements.Count; i++)
                {
                    int current = elements[i];

                    if (current <= removed)
                    {
                        elements[i] += removed;
                    }
                    else
                    {
                        elements[i] -= removed;
                    }
                }

            }

            Console.WriteLine(sum);
        }
    }
}
