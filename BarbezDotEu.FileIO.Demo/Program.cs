// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;

namespace BarbezDotEu.FileIO.Demo
{
    class Program
    {
        const string rootDirectory = @"D:\Thesis\whoisBatch";

        static void Main(string[] args)
        {
            Program p = new Program();
            //p.DemonstrateSplitter();
            //p.DemonstrateMerger();
            p.DemonstrateDumper();
        }

        private void DemonstrateDumper()
        {
            var textFileName = @$"{rootDirectory}\{Guid.NewGuid()}.txt";
            DirectoryDumper.ListFilesInFile(rootDirectory, textFileName);
        }

        private void DemonstrateMerger()
        {
            DirectoryMerger.MergeFilesFromSubDirectoryIntoRootDirectory(rootDirectory, deleteSubDirectoriesOnFinish: true);
        }

        private void DemonstrateSplitter()
        {
            DirectorySplitter.MoveFilesIntoSubDirectories(rootDirectory, 1000);
        }
    }
}
