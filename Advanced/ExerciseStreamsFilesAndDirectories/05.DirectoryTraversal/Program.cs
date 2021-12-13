using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var filesByExtension = new Dictionary<string, List<FileInfo>>();

            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;

                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension[extension] = new List<FileInfo>();
                }

                filesByExtension[extension].Add(info);
            }
            //DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  
            // DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  
            //  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  

            using StreamWriter writer = new StreamWriter(Environment
                                                             .GetFolderPath(Environment.SpecialFolder.Desktop)
                                                         + "/report.txt");

            //DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  
            // DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  
            //  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP  DESKTOP    

            foreach (var kvp in filesByExtension.OrderByDescending(x=> x.Value.Count)
                .ThenBy(x => x.Key))
            {
                writer.WriteLineAsync($".{kvp.Key}");

                foreach (var fileInfo in kvp.Value.OrderBy(x => Math.Ceiling((double)x.Length/ 1024)))
                {
                   writer.WriteLineAsync($"--{fileInfo.Name} - {Math.Ceiling((double) fileInfo.Length / 1024)}");
                }
            }
        }
    }
}
