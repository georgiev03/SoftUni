using System;
using DependancyInjection.Core;
using DependancyInjection.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace DependancyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicePrivider = DependancyResolver.GetServiceProvider();
            var engine = servicePrivider.GetService<Engine>();

            engine.Run();
        }
    }
}
