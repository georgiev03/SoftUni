using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            int won = 0;
            int lost = 0;
            int draw = 0;

            for (int i = 0; i < 3; i++)
            {
                string game = Console.ReadLine();
                char left = game[0];
                char right = game[2];
                int us = Convert.ToInt32(new string(left, 1));
                int them = Convert.ToInt32(new string(right, 1));
                if (us > them)
                {
                    won++;
                }
                else if(us < them)
                {
                    lost++;
                }
                else
                {
                    draw++;
                }

            }
            Console.WriteLine("Team won " + won + " games.");
            Console.WriteLine("Team lost " + lost + " games.");
            Console.WriteLine("Drawn games: " + draw);
        }
    }
}
