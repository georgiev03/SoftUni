using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    class Tuple<FirstT, SecondT, ThirdT>
    {
        public FirstT Item1 { get; }

        public SecondT Item2 { get; }

        public ThirdT Item3 { get; }


        public Tuple(FirstT item1, SecondT item2, ThirdT item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
