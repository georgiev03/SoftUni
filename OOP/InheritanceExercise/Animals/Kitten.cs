using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Animal
    {
        public Kitten(string name, int age)
            : base(name, age, "female")
        {
            
        }
        public Kitten(string name, int age, string gender)
            : base(name, age, "female")
        {

        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
