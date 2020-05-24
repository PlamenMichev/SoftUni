using System;
using System.Collections.Generic;
using System.Text;

namespace _04.OnlineRadionDatabase
{
    public class Song
    {
        private string artistName;
        private string songName;
        private int length;
        private int seconds;
        private int minutes;

        public Song(string artistName, string songName, int length, int minutes, int seconds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.minutes = minutes;
            this.seconds = seconds;
            this.Length = length;
        }

        public string ArtistName
        {
            get => this.artistName;
            protected set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }

                this.artistName = value;
            }
        }

        public string SongName
        {
            get => this.songName;
            protected set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }

                this.songName = value;
            }
        }

        public int Length
        {
            get => this.length;
            set
            {
                if (length < 0 || length > 899)
                {
                    throw new ArgumentException("Invalid song length.");
                }
                else if (this.minutes < 0 || this.minutes > 14)
                {
                    throw new ArgumentException("Song minutes should be between 0 and 14.");
                }
                else if (this.seconds < 0 || this.seconds > 59)
                {
                    throw new ArgumentException("Song seconds should be between 0 and 59.");
                }

                this.length = value;
            }
        }
    }
}
