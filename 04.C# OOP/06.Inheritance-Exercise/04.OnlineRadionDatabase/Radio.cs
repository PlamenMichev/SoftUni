using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.OnlineRadionDatabase
{
    public class Radio
    {
        private List<Song> songs;

        public Radio()
        {
            this.songs = new List<Song>();
        }

        public string CalculateTotalLength()
        {
            //Calculate Hours
            string totalLength = string.Empty;
            int sum = this.songs.Select(x => x.Length).Sum();
            int hours = 0;
            while (sum >= 3600)
            {
                hours++;
                sum -= 3600;
            }

            //Calculate Minutes
            int minutes = 0;

            while (sum >= 60)
            {
                minutes++;
                sum -= 60;
            }

            //Calculate Seconds

            int seconds = sum;

            totalLength = $"Playlist length: {hours}h {minutes}m {seconds}s";

            return totalLength;
        }

        public void AddSong(Song song)
        {
            this.songs.Add(song);
        }

        public int Count => this.songs.Count;

    }
}
