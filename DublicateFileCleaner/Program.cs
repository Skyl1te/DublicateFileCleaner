using System;
using System.Collections.Generic;
using System.IO;

namespace DublicateFileCleaner;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Usage: DublicateFileCleaner <directoryPath> [<moveDuplicates> [<backupDirectory>]]");
            Console.WriteLine("  directoryPath   : The directory to scan for duplicate files.");
            Console.WriteLine("  moveDuplicates : Optional. Specify 'true' to move duplicates to a backup directory (default is 'false').");
            Console.WriteLine("  backupDirectory: Optional. The directory where duplicates will be moved (required if moveDuplicates is 'true').");
            return;
        }

        string directoryPath = args[0]; // Assuming the first argument is the directory path

        bool moveDuplicates = false;
        string backupDirectory = null;

        if (args.Length > 1 && bool.TryParse(args[1], out moveDuplicates))
        {
            if (moveDuplicates && args.Length > 2)
            {
                backupDirectory = args[2];
            }
            else if (moveDuplicates && args.Length <= 2)
            {
                Console.WriteLine("Backup directory path is required when moving duplicates.");
                return;
            }
        }

        var getFileHashes = new GetFileHashes();
        var filesHashes = getFileHashes.GetAllFilesHashes(directoryPath, SearchOption.AllDirectories);

        if (moveDuplicates && !string.IsNullOrEmpty(backupDirectory))
        {
            FileManager.MoveDuplicateFiles(filesHashes, backupDirectory);
        }
        else
        {
            FileManager.DeleteDublicateFiles(filesHashes);
        }
    }
}
