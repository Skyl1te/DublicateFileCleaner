using System;
using System.Collections.Generic;
using System.IO;

namespace DublicateFileCleaner;

public class FileManager
{
    public static void DeleteDublicateFiles(List<(string file, string hash)> filesHashes)
    {
        var seenHashes = new HashSet<string>();
        var filesToRemove = new List<string>();

        foreach (var (file, hash) in filesHashes)
        {
            if (!seenHashes.Add(hash))
            {
                filesToRemove.Add(file);
            }
        }
        foreach (var file in filesToRemove)
        {
            File.Delete(file);
            Console.WriteLine($"File {file} was eliminated as duplicate");
        }
    }

    public static void MoveDuplicateFiles(List<(string file, string hash)> filesHashes, string backupDirectory)
    {
        if (!Directory.Exists(backupDirectory))
        {
            Directory.CreateDirectory(backupDirectory);
        }

        foreach (var (file, hash) in filesHashes)
        {
            string fileName = Path.GetFileName(file);
            string destinationFile = Path.Combine(backupDirectory, fileName);

            if (!File.Exists(destinationFile))
            {
                File.Move(file, destinationFile);
                Console.WriteLine($"File {file} was moved to {destinationFile} as duplicate");
            }
            else
            {
                Console.WriteLine($"Duplicate file {file} already exists in backup directory");
            }
        }
    }
}
