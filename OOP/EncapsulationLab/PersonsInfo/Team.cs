using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public string Name { get; }

        public IReadOnlyCollection<Person> FirstTeam => firstTeam.AsReadOnly();

        public IReadOnlyCollection<Person> ReserveTeam => reserveTeam.AsReadOnly();

        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
