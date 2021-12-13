using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Zoo
{
    public class Reptile : Animal
    {
        public string Name { get; set; }

        public Reptile(string name)
            : base(name)
        {
            Name = name;
        }
    }
}
