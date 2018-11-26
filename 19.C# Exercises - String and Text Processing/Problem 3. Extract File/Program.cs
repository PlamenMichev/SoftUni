using System;
using System.Linq;

namespace Problem_3._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = Console.ReadLine();
            int fileIndex = location.LastIndexOf("\\") + 1;
            string file = location.Substring(fileIndex);
            int nameLength = file.LastIndexOf(".");
            string name = file.Substring(0, nameLength);
            string extension = file.Substring(nameLength + 1);
            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
