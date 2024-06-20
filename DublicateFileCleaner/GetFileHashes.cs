using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DublicateFileCleaner;

public class GetFileHashes
{
    public string GetFileHash(string filePath)
    {
        using (var sha256 = SHA256.Create())
        {
            using (var stream = File.OpenRead(filePath))
            {
                var hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
    }

    public List<(string file, string hash)> GetAllFilesHashes(string dirPath, SearchOption searchOption)
    {
        var filesList = new List<(string file, string hash)>();

        foreach (var file in Directory.GetFiles(dirPath, "", searchOption))
        {
            string hash = GetFileHash(file);
            filesList.Add((file, hash));
        }

        return filesList;
    }

}
