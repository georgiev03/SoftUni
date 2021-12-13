using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>
            {
                { "shards", 0 },
                { "fragments", 0 },
                { "motes", 0 }
            };
            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();

            string winnerMaterial = string.Empty;
            bool isRunning = true;

            while (isRunning)
            {
                string[] line = Console.ReadLine().Split();

                for (int i = 0; i < line.Length; i += 2)
                {
                    int quantity = int.Parse(line[i]);
                    string item = line[i + 1].ToLower();

                    if (materials.ContainsKey(item))
                    {
                        materials[item] += quantity;

                        if (materials[item] >= 250)
                        {
                            materials[item] -= 250;
                            isRunning = false;
                            winnerMaterial = item;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(item))
                        {
                            junk[item] += quantity;
                        }
                        else
                        {
                            junk.Add(item, quantity);
                        }
                    }

                }
            }

            if (winnerMaterial == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (winnerMaterial == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else
            {
                Console.WriteLine("Dragonwrath obtained!");
            }


            Dictionary<string, int> sortedMaterials = materials.OrderByDescending(x => x.Value)
                 .ThenBy(n => n.Key)
                 .ToDictionary(x => x.Key, x => x.Value);

            foreach (var material in sortedMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
