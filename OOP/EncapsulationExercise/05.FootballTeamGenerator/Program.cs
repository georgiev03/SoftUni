using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(";");
                string command = input[0];

                if (command == "END")
                {
                    break;
                }

                string teamName = input[1];

                switch (command)
                {
                    case "Team":
                        teams.Add(new Team(teamName));

                        break;

                    case "Add" when teams.Any(t => t.Name == teamName):
                        string playerName = input[2];
                        int endurance = int.Parse(input[3]);
                        int sprint = int.Parse(input[4]);
                        int dribble = int.Parse(input[5]);
                        int passing = int.Parse(input[6]);
                        int shooting = int.Parse(input[7]);

                        try
                        {
                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                            teams.First(t => t.Name == teamName).AddPlayer(player);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Remove" when teams.Any(t => t.Name == teamName):
                        try
                        {
                            teams.First(t => t.Name == teamName).RemovePlayer(input[2]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "Rating" when teams.Any(t => t.Name == teamName):
                        Team team = teams.First(t => t.Name == teamName);

                        Console.WriteLine($"{teamName} - {team.GetRating}");
                        break;

                    default:
                        Console.WriteLine($"Team {teamName} does not exist.");
                        break;
                }
            }
        }
    }
}
