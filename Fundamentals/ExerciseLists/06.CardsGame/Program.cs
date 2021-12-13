using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondHand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            bool firstWon = true;

            while (true)
            {
                if (firstHand.Count == 0)
                {
                    firstWon = false;
                    break;
                }

                if (secondHand.Count == 0)
                {
                    break;
                }

                int firstCard = firstHand[0];
                int secondCard = secondHand[0];

                if (firstCard== secondCard)
                {
                    firstHand.Remove(firstCard);
                    secondHand.Remove(secondCard);
                }
                else if (firstCard > secondCard)
                {
                    firstHand.Remove(firstCard);
                    firstHand.Add(firstCard);
                    firstHand.Add(secondCard);
                    secondHand.Remove(secondCard);
                }
                else
                {
                    secondHand.Remove(secondCard);
                    secondHand.Add(secondCard);
                    secondHand.Add(firstCard);
                    firstHand.Remove(firstCard);
                }
            }

            int sum = 0;

            if (firstWon)
            {
                foreach (var card in firstHand)
                {
                    sum += card;
                }

                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                foreach (var card in secondHand)
                {
                    sum += card;
                }

                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}
