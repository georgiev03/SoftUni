using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int poked = 0;
            int staritngPoke = pokePower;

            for (pokePower = pokePower; pokePower >= distance; pokePower -= distance)
            {
                
                if (pokePower == 0.5 * staritngPoke && exhaustionFactor > 0)
                {
                    if (pokePower > exhaustionFactor)
                    {
                        pokePower /= exhaustionFactor;
                    }
                }

                if (pokePower >= distance)
                {
                    poked++;
                }

            }

            if (pokePower < 0)
            {
                Console.WriteLine(pokePower + distance);
            }
            else
            {
                Console.WriteLine(pokePower);
            }

            Console.WriteLine(poked);
        }
    }
}
