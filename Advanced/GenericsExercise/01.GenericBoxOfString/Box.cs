using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        public T Value { get; set; }
        public override string ToString()
        {
            return $"{Value.GetType()}: {Value}";
        }
    }
}
