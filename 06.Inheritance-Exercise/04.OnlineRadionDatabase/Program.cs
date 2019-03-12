using System;

namespace _04.OnlineRadionDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var radio = new Radio();

            for (int i = 0; i < count; i++)
            {
                string[] splitSong = Console.ReadLine()
                    .Split(";");
                string nameOfSong = splitSong[1];
                string artistName = splitSong[0];
                string length = splitSong[2];
                try
                {
                    string[] lengthTokens = length.Split(":");
                    if (lengthTokens.Length != 2)
                    {
                        throw new Exception("Invalid song length.");
                    }

                    if (!int.TryParse(lengthTokens[0], out int minutes))
                    {
                        throw new Exception("Invalid song length.");
                    }

                    if (!int.TryParse(lengthTokens[1], out int seconds))
                    {
                        throw new Exception("Invalid song length.");
                    }

                    int songLength = (minutes * 60) + seconds;

                    try
                    {
                        var song = new Song(artistName, nameOfSong, songLength, minutes, seconds);
                        radio.AddSong(song);
                        Console.WriteLine($"Song added.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            Console.WriteLine($"Songs added: {radio.Count}");
            Console.WriteLine(radio.CalculateTotalLength());
        }
    }
}
