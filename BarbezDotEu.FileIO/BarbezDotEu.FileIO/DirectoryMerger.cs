// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.IO;
using System.Threading.Tasks;
using BarbezDotEu.String;

namespace BarbezDotEu.FileIO
{
    public static class DirectoryMerger
    {
        public static void MergeFilesFromSubDirectoryIntoRootDirectory(string rootDirectory, bool deleteSubDirectoriesOnFinish)
        {
            var paths = Directory.EnumerateDirectories(rootDirectory);
            Parallel.ForEach(paths, subPath =>
            {
                var files = Directory.EnumerateFiles(subPath);
                foreach (var file in files)
                {
                    var newFile = $@"{rootDirectory}\{file.GetFileName()}";
                    File.Move(file, newFile);
                }

                if (deleteSubDirectoriesOnFinish)
                    Directory.Delete(subPath);
            });
        }
    }
}
