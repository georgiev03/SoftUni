using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public List<Player> Players { get; private set; }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            var player = Players.FirstOrDefault(p => p.Name == name);
            if (player is null)
            {
                throw new InvalidOperationException($"Player {name} is not in {Name} team.");
            }

            Players.Remove(player);
        }

        public int GetRating => Rating();
        private int Rating()
        {
            double result = 0;

            foreach (var player in Players)
            {
                result += player.AvgPoints;
            }

            if (result == 0)
            {
                return 0;
            }

            return (int)result / Players.Count;
        }
    }

}

