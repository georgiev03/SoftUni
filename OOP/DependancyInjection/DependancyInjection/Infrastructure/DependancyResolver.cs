using System;
using System.Collections.Generic;
using System.Text;
using DependancyInjection.Contracts;
using DependancyInjection.Core;
using DependancyInjection.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DependancyInjection.Infrastructure
{
    public static class DependancyResolver
    {
        public static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IReader, ConsoleReader>()
                .AddTransient<IConsoleWriter, ConsoleWriter>()
                .AddTransient<IFileWriter, FileWriter>()
                .AddTransient<Engine>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
