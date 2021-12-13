using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    class Team
    {
        public Team()
        {
            Members = new List<string>();
        }

        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] teamData = Console.ReadLine()
                    .Split("-");

                string creator = teamData[0];
                string teamName = teamData[1];

                if (TeamIsCreated(teamName, teams))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (CreatorExists(creator, teams))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team team = new Team
                {
                    Creator = creator,
                    Name = teamName
                };

                teams.Add(team);

                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end of assignment")
                {
                    break;
                }

                string[] memberData = line.Split("->");

                string user = memberData[0];
                string teamName = memberData[1];

                if (!TeamIsCreated(teamName, teams))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (IsMember(teams, user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                Team existingTeam = GetTeamByName(teams, teamName);

                existingTeam.Members.Add(user);
            }

            List<Team> sorted = teams
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name)
                .ToList();

            foreach (var team in sorted)
            {
                if (team.Members.Count == 0)
                {
                    break;
                }

                Console.WriteLine(team.Name);
                Console.WriteLine($"- {team.Creator}");

                List<string> sortedMembers = team.Members
                    .OrderBy(m => m)
                    .ToList();

                foreach (var sortedMember in sortedMembers)
                {
                    Console.WriteLine($"-- {sortedMember}");
                }
            }

            List<Team> disbandedTeams = teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name)
                .ToList();

            Console.WriteLine("Teams to disband:");

            foreach (var disbandedTeam in disbandedTeams)
            {
                Console.WriteLine(disbandedTeam.Name);
            }
        }

        private static Team GetTeamByName(List<Team> teams, string teamName)
        {
            foreach (var team in teams)
            {
                if (team.Name == teamName)
                {
                    return team;
                }
            }

            return null;
        }

        private static bool IsMember(List<Team> teams, string user)
        {
            foreach (var team in teams)
            {
                if (team.Creator == user)
                {
                    return true;
                }

                foreach (var teamMember in team.Members)
                {
                    if (teamMember == user)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool CreatorExists(string creator, List<Team> teams)
        {
            foreach (var team in teams)
            {
                if (team.Creator == creator)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool TeamIsCreated(string teamName, List<Team> teams)
        {
            foreach (var team1 in teams)
            {
                if (team1.Name == teamName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
