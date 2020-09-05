// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System.IO;
using System.Threading.Tasks;
using BarbezDotEu.String;

namespace BarbezDotEu.FileIO
{
    public static class DirectoryMerger
    {
        /// <summary>
        /// Moves all files, found in any subdirectories a given root directory, into the root directory.
        /// </summary>
        /// <param name="rootDirectory">The root directory where all files in its subdirectories should be moved into.</param>
        /// <param name="deleteSubDirectoriesOnFinish">Set to true to delete the actual subdirectories after all files have been moved. Set to false to keep the (potentially empty) subdirectories.</param>
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
