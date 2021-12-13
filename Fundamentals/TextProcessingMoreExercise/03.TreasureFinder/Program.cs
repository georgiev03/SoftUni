using System;
using System.Linq;
using System.Text;

namespace _03.TreasureFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string secretText = Console.ReadLine();
                StringBuilder text = new StringBuilder();

                if (secretText == "find")
                {
                    break;
                }

                for (int i = 0; i < secretText.Length; i++)
                {
                    char newLetter = (char)(secretText[i] - key[i % key.Length]);
                    text.Append(newLetter);
                }

                int startTreasure = text.ToString().IndexOf('&');
                int endTreasure = text.ToString().LastIndexOf('&');

                int startCoordinates = text.ToString().IndexOf('<');
                int endCoordinates = text.ToString().IndexOf('>');

                string treasure = text.ToString().Substring(startTreasure + 1, endTreasure - startTreasure - 1);
                string coordinates = text.ToString().Substring(startCoordinates + 1, endCoordinates - startCoordinates - 1);

                Console.WriteLine($"Found {treasure} at {coordinates}");
            }
        }
    }
}
