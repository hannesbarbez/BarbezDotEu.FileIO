using System;

namespace BarbezDotEu.FileIO.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = @"D:\Thesis\whoisBatch";
            DirectorySplitter.MoveFilesIntoSubDirectories(directory, 1000);
        }
    }
}
