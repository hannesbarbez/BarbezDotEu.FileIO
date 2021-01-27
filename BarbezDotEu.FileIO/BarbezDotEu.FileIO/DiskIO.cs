// Copyright (c) Hannes Barbez. All rights reserved.
// Licensed under the GNU General Public License v3.0

using System;
using System.IO;
using System.Threading.Tasks;
using BarbezDotEu.String;

namespace BarbezDotEu.FileIO
{
    public static class DiskIO
    {
        /// <summary>
        /// Appends a line of text to a text file.
        /// </summary>
        /// <param name="path">The full file path (i.e. incl. folder and file name + extension) to append the line to.</param>
        /// <param name="line">The line to append to the text file.</param>
        public static async Task WriteLine(string path, string line)
        {
            if (File.Exists(path))
            {
                using StreamWriter outputFile = File.AppendText(path);
                await outputFile.WriteLineAsync(line);
            }
        }

        /// <summary>
        /// Saves a given text to a given filename.
        /// </summary>
        /// <param name="filename">The name of the file to store.</param>
        /// <param name="text">The textual contents of the file.</param>
        /// <param name="directory">The directory where to store the file on disk.</param>
        /// <param name="timestampPrefix">The <see cref="DateTime"/> to prepend the given filename with, if any.</param>
        /// <returns>The fully-qualified path of where the file was created.</returns>
        public static async Task<string> SaveText(string filename, string text, string directory, DateTime timestampPrefix = default)
        {
            try
            {
                if (timestampPrefix != default)
                {
                    filename = $"{DateTime.UtcNow.ToString(StringConstants.FileNameCompatibleDateTime)}_{filename}";
                }

                var path = Path.Combine(directory, filename);
                using (StreamWriter outputFile = new StreamWriter(path))
                {
                    await outputFile.WriteAsync(text);
                }
                return path;
            }
            catch
            {
                return null;
            }
        }
    }
}
