using DependancyInjection.Contracts;
using System;

namespace DependancyInjection.Services
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
