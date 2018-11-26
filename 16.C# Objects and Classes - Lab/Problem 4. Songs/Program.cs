using System;
using System.Collections.Generic;

namespace Problem_4._Songs
{
    class Program
    {
        class Song
        {
            public string List { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
        }
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            
            List<Song> songs = new List<Song>();

            for (int i = 0; i < length; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split("_");
                string type = tokens[0];
                string name = tokens[1];
                string time = tokens[2];
                Song song = new Song();
                song.List = type;
                song.Name = name;
                song.Time = time;
                songs.Add(song);
            }

            string typeToOutput = Console.ReadLine();
            if (typeToOutput == "all")
            {
                foreach(Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.List == typeToOutput)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}
