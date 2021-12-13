using System;
using System.IO.Compression;

namespace _06.ZipFIleAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\snimki", @"D:\Test\TestArchive.zip");

            ZipFile.ExtractToDirectory(@"D:\Test\TestArchive.zip", @"D:\Test");
        }
    }
}
