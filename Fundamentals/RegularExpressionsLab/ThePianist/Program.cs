using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string[]> 
                pieces = new Dictionary<string, string[]>(); 

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split('|');

                pieces.Add(tokens[0], new string[] { tokens[1], tokens[2] });
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split('|');

                if (command[0] == "Stop")
                {
                    break;
                }

                if (command[0] == "Add")
                {
                    if (!pieces.ContainsKey(command[1]))
                    {
                        pieces.Add(command[1], new string[] { command[2], command[3] });


                        Console.WriteLine($"{command[1]} by {command[2]} in {command[3]} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{command[1]} is already in the collection!");
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (pieces.Remove(command[1]))
                    {
                        Console.WriteLine($"Successfully removed {command[1]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
                    }
                }
                else if (command[0] == "ChangeKey")
                {
                    if (pieces.ContainsKey(command[1]))
                    {
                        pieces[command[1]][1] = command[2];

                        Console.WriteLine($"Changed the key of {command[1]} to {command[2]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
                    }
                }
            }

            var orderedPieces = pieces
                .OrderBy(x => x.Key)
                .ThenBy(x => x.Value[1]);

            foreach (var kvp in orderedPieces)
            {
                Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value[0]}, Key: {kvp.Value[1]}");
            }
        }
    }
}
