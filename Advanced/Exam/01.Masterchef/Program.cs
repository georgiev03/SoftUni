using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Reflection.Metadata;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> ingredientValue = new Queue<int>(firstLine.Where(i=>i != 0));
            Stack<int> freshness = new Stack<int>(secondLine);

            Dictionary<string, int> dishes = new Dictionary<string, int>
            {
                {"Chocolate cake" ,0},
                {"Dipping sauce", 0 },
                {"Green salad" ,0},
                {"Lobster" ,0}
            };

            while (freshness.Any() && ingredientValue.Any())
            {
                int value = ingredientValue.Peek();
                int fresh = freshness.Pop();
                int result = value * fresh;
                
                if (result == 150)
                {
                    dishes["Dipping sauce"]++;
                }
                else if (result == 250)
                {
                    dishes["Green salad"]++;
                }
                else if (result == 300)
                {
                    dishes["Chocolate cake"]++;
                }
                else if (result == 400)
                {
                    dishes["Lobster"]++;
                }
                else
                {
                    ingredientValue.Enqueue(value + 5);
                }

                ingredientValue.Dequeue();
            }

            var removedDishes = dishes.Where(d => d.Value > 0);

            if (removedDishes.Count() == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredientValue.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredientValue.Sum()}");
            }
            foreach (var dish in removedDishes)
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
