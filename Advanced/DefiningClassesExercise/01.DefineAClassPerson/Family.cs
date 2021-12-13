﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {

        private readonly HashSet<Person> members;

        public Family()
        {
            this.members = new HashSet<Person>();
        }

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            Person person = this.members
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
            return person;
        }

        public HashSet<Person> GetAllPplAbove30()
            => this.members.Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToHashSet();
    }
}
