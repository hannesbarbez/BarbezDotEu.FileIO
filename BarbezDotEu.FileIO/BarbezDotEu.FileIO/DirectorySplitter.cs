// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbezDotEu.FileIO
{
    /// <summary>
    /// Splits (the contents of) a directory.
    /// </summary>
    public static class DirectorySplitter
    {
        /// <summary>
        /// In a best-effort kind of a way, moves files in a directory into subdirectories created on the fly.
        /// </summary>
        /// <param name="directory">The relative or absolute path to the directory to search. This string is not case-sensitive.</param>
        /// <param name="itemsPerSubFolder">The maximum number of items per subdirectory.</param>
        public static void MoveFilesIntoSubDirectories(string directory, int itemsPerSubFolder)
        {
            var fileNames = Directory.GetFiles(directory);
            var fileCount = fileNames.LongCount();
            var subFolderCount = Convert.ToInt32(Math.Ceiling(decimal.Divide(fileCount, itemsPerSubFolder)));
            var subFolderNameLength = subFolderCount.ToString().LongCount();
            Parallel.For(default(int), subFolderCount, (i) =>
            {
                var subDirectory = $@"{directory}\{FillTextToLength((i + 1).ToString(), subFolderNameLength, default(long).ToString().First())}";
                var directoryInfo = Directory.CreateDirectory(subDirectory);
                if (directoryInfo.Exists)
                {
                    var filesToMove = fileNames.Skip(i * itemsPerSubFolder).Take(itemsPerSubFolder);
                    foreach (var file in filesToMove)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        if (fileInfo.Exists)
                        {
                            var destFileName = $@"{subDirectory}\{fileInfo.Name}";
                            File.Move(file, destFileName);
                        }
                    }
                }
            });
        }

        /// <summary>
        /// Prefixes a text with a filler from which a string with a certain length is returned.
        /// </summary>
        /// <param name="text">The text to prefix.</param>
        /// <param name="desiredLength">The desired length of the returned string.</param>
        /// <param name="filler">The filler to use in prefixing the text.</param>
        /// <returns>The given text prefixed with a filler from which a string with a certain length is returned. Returns the initial text if it is longer than the provided length.</returns>
        private static string FillTextToLength(string text, long desiredLength, char filler)
        {
            var textLength = text.LongCount();
            if (textLength >= desiredLength)
            {
                return text;
            }

            var iterations = desiredLength - textLength;
            var stringBuilder = new StringBuilder();
            for (var i = default(long); i < iterations; i++)
            {
                stringBuilder.Append(filler);
            }

            stringBuilder.Append(text);
            return stringBuilder.ToString();
        }
    }
}
