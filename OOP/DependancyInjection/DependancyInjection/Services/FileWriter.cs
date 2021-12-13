using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DependancyInjection.Contracts;

namespace DependancyInjection.Services
{
   public class FileWriter : IFileWriter
    {
        public void Write(string text)
        {
            File.WriteAllText("log.txt", text);
        }
    }
}
