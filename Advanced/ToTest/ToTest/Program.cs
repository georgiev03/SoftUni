using System;
using System.Collections.Generic;

namespace ToTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<object, object> aaas = new Dictionary<object, object>();

            aaas.Add(12, "sasa");
            Console.WriteLine(aaas[12]);
        }
    }
}
