using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem_6._Full_Directory_Traversial
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            
            Dictionary<string, List<FileInfo>> extensionFileInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);

                string extension = info.Extension;
                if (!extensionFileInfo.ContainsKey(extension))
                {
                    extensionFileInfo[extension] = new List<FileInfo>();
                }
                extensionFileInfo[extension].Add(info);
            }

            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.txt";

            using (StreamWriter writer = new StreamWriter(pathToDesktop))
            {      
                foreach (var kvp in extensionFileInfo
                    .OrderByDescending(x => x.Value.Count)
                    .ThenBy(x => x.Key))
                {
                    string ext = kvp.Key;
                    var info = kvp.Value;
                    writer.WriteLine($"{ext}"); ;
                    foreach (var fileInfo in info
                        .OrderByDescending(x => x.Length))
                    {
                        string name = fileInfo.Name;
                        double size = fileInfo.Length / 1024;
                        writer.WriteLine($"-- {name} - {size:f3}kb");
                    }
                }
            }
        }
    }
}
