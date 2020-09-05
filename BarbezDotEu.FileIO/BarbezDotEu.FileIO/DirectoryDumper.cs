// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;
using System.IO;

namespace BarbezDotEu.FileIO
{
    public static class DirectoryDumper
    {
        /// <summary>
        /// Creates or overwrites a text file containing a list of fully qualified file names found inside a given directory.
        /// </summary>
        /// <param name="directory"></param>
        public static void ListFilesInFile(string directory, string fileName)
        {
            var files = Directory.EnumerateFiles(directory);
            var text = string.Join(Environment.NewLine, files);
            File.WriteAllText(fileName, text);
        }
    }
}
