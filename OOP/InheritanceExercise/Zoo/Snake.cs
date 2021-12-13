using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public class Snake : Reptile
    {
        public string Name { get; set; }

        public Snake(string name)
            : base(name)
        {
            Name = name;
        }

        internal void Deconstruct(out string name, out int asd, out decimal kkk)
        {
            name = Name;
            asd = 5;
            kkk = 235.66M;
        }
    }
}
