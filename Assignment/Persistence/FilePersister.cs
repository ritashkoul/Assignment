using Assignment.Interfaces;
using System;
using System.IO;

namespace Assignment.Persistence
{
    public class FilePersister : IPersister
    {
        public void SaveData(int data)
        {
            string directory = @"C:\Assignment\datalogs";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string fullFilePath = $"{directory}/data_{DateTimeOffset.UtcNow:yyyyMMdd}.log";
            string fileData = $"{"[" + DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss+00:00") + "]"} {$"Sum : {data}"}";

            using (var streamWriter = new StreamWriter(fullFilePath, true))
            {
                streamWriter.WriteLine(fileData);
            }
        }
    }
}
