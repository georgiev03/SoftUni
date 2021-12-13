using DependancyInjection.Contracts;
using System;

namespace DependancyInjection.Services
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
