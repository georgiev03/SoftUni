﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Pokemon
    {
        public string Name { get; set; }

        public string Element { get; set; }

        public int Health { get; set; }

        public Pokemon(string name, string element, int hp)
        {
            Name = name;
            Element = element;
            Health = hp;
        }
    }
}
