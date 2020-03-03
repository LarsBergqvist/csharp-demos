using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace LINQ_Demo
{
    public class FileQueryDemo
    {
        public void ListFiveLargestFiles(string path)
        {
            // With query syntax
            var query1 = from file in new DirectoryInfo(path).GetFiles()
                                    orderby file.Length descending
                                    select file;
            var query2 = query1.Take(5);
            WriteFileInfos(query2);

            // With method syntax
            var query3 = new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(f => f.Length)
                        .Take(5);
            WriteFileInfos(query3);
        }

        public void WriteFileInfos(IEnumerable<FileInfo> collection)
        {
            foreach (var file in collection)
            {
                Console.WriteLine($"{file.Name,-50}: {file.Length,10:N0}");
            }
        }
    }
}
