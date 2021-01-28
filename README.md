# BarbezDotEu.FileIO
Misc. logic related to files and IO.

## Contents

- [DirectoryDumper](#T-BarbezDotEu-FileIO-DirectoryDumper 'BarbezDotEu.FileIO.DirectoryDumper')
  - [ListFilesInFile(directory,fileName)](#M-BarbezDotEu-FileIO-DirectoryDumper-ListFilesInFile-System-String,System-String- 'BarbezDotEu.FileIO.DirectoryDumper.ListFilesInFile(System.String,System.String)')
- [DirectoryMerger](#T-BarbezDotEu-FileIO-DirectoryMerger 'BarbezDotEu.FileIO.DirectoryMerger')
  - [MergeFilesFromSubDirectoryIntoRootDirectory(rootDirectory,deleteSubDirectoriesOnFinish)](#M-BarbezDotEu-FileIO-DirectoryMerger-MergeFilesFromSubDirectoryIntoRootDirectory-System-String,System-Boolean- 'BarbezDotEu.FileIO.DirectoryMerger.MergeFilesFromSubDirectoryIntoRootDirectory(System.String,System.Boolean)')
- [DirectorySplitter](#T-BarbezDotEu-FileIO-DirectorySplitter 'BarbezDotEu.FileIO.DirectorySplitter')
  - [FillTextToLength(text,desiredLength,filler)](#M-BarbezDotEu-FileIO-DirectorySplitter-FillTextToLength-System-String,System-Int64,System-Char- 'BarbezDotEu.FileIO.DirectorySplitter.FillTextToLength(System.String,System.Int64,System.Char)')
  - [MoveFilesIntoSubDirectories(rootDirectory,itemsPerSubFolder)](#M-BarbezDotEu-FileIO-DirectorySplitter-MoveFilesIntoSubDirectories-System-String,System-Int32- 'BarbezDotEu.FileIO.DirectorySplitter.MoveFilesIntoSubDirectories(System.String,System.Int32)')
- [DiskIO](#T-BarbezDotEu-FileIO-DiskIO 'BarbezDotEu.FileIO.DiskIO')
  - [SaveText(filename,text,directory,timestampPrefix)](#M-BarbezDotEu-FileIO-DiskIO-SaveText-System-String,System-String,System-String,System-DateTime- 'BarbezDotEu.FileIO.DiskIO.SaveText(System.String,System.String,System.String,System.DateTime)')
  - [WriteLine(path,line)](#M-BarbezDotEu-FileIO-DiskIO-WriteLine-System-String,System-String- 'BarbezDotEu.FileIO.DiskIO.WriteLine(System.String,System.String)')

<a name='T-BarbezDotEu-FileIO-DirectoryDumper'></a>
## DirectoryDumper `type`

BarbezDotEu.FileIO

Basic, static class for "dumping"/listing information for a given folder/directory.

<a name='M-BarbezDotEu-FileIO-DirectoryDumper-ListFilesInFile-System-String,System-String-'></a>
### ListFilesInFile(directory,fileName) `method`

Creates or overwrites a text file containing a list of fully qualified file names found inside a given directory.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| directory | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The directory to investigate. |
| fileName | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text file to write the information to. |

<a name='T-BarbezDotEu-FileIO-DirectoryMerger'></a>
## DirectoryMerger `type`

BarbezDotEu.FileIO

Basic class implementing static methods pertaining to merging of folders/directories.

<a name='M-BarbezDotEu-FileIO-DirectoryMerger-MergeFilesFromSubDirectoryIntoRootDirectory-System-String,System-Boolean-'></a>
### MergeFilesFromSubDirectoryIntoRootDirectory(rootDirectory,deleteSubDirectoriesOnFinish) `method`

Moves all files, found in any subdirectories a given root directory, into the root directory.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rootDirectory | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The root directory where all files in its subdirectories should be moved into. |
| deleteSubDirectoriesOnFinish | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Set to true to delete the actual subdirectories after all files have been moved. Set to false to keep the (potentially empty) subdirectories. |

<a name='T-BarbezDotEu-FileIO-DirectorySplitter'></a>
## DirectorySplitter `type`

BarbezDotEu.FileIO

Splits (the contents of) a directory.

<a name='M-BarbezDotEu-FileIO-DirectorySplitter-FillTextToLength-System-String,System-Int64,System-Char-'></a>
### FillTextToLength(text,desiredLength,filler) `method`

Prefixes a text with a filler from which a string with a certain length is returned.

##### Returns

The given text prefixed with a filler from which a string with a certain length is returned. Returns the initial text if it is longer than the provided length.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The text to prefix. |
| desiredLength | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | The desired length of the returned string. |
| filler | [System.Char](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Char 'System.Char') | The filler to use in prefixing the text. |

<a name='M-BarbezDotEu-FileIO-DirectorySplitter-MoveFilesIntoSubDirectories-System-String,System-Int32-'></a>
### MoveFilesIntoSubDirectories(rootDirectory,itemsPerSubFolder) `method`

In a best-effort kind of a way, moves files in a directory into subdirectories created on the fly.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rootDirectory | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The relative or absolute path to the directory to search. This string is not case-sensitive. |
| itemsPerSubFolder | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The maximum number of items per subdirectory. |

<a name='T-BarbezDotEu-FileIO-DiskIO'></a>
## DiskIO `type`

BarbezDotEu.FileIO

Basic class implementing static methods pertaining to file persisting to disk.

<a name='M-BarbezDotEu-FileIO-DiskIO-SaveText-System-String,System-String,System-String,System-DateTime-'></a>
### SaveText(filename,text,directory,timestampPrefix) `method`

Saves a given text to a given filename.

##### Returns

The fully-qualified path of where the file was created.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filename | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name of the file to store. |
| text | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The textual contents of the file. |
| directory | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The directory where to store the file on disk. |
| timestampPrefix | [System.DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') | The [DateTime](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.DateTime 'System.DateTime') to prepend the given filename with, if any. |

<a name='M-BarbezDotEu-FileIO-DiskIO-WriteLine-System-String,System-String-'></a>
### WriteLine(path,line) `method`

Appends a line of text to a text file.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| path | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The full file path (i.e. incl. folder and file name + extension) to append the line to. |
| line | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The line to append to the text file. |
