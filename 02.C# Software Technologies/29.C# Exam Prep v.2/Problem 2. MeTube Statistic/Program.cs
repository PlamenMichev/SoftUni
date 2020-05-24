using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Problem_2._MeTube_Statistic
{
    class Program
    {
        static void Main(string[] args)
        {
            var videosViewsLikes = new Dictionary<string, int[]>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stats time")
                {
                    break;
                }

                string[] tokens = input.Split(":");
                if (tokens[0] == "like")
                {
                    string video = tokens[1];
                    if (!videosViewsLikes.ContainsKey(video))
                    {
                        continue;
                    }
                    videosViewsLikes[video][1]++;
                }
                else
                {

                    if (tokens[0] == "dislike")
                    {
                        string dislikedVideo = tokens[1];
                        if (!videosViewsLikes.ContainsKey(dislikedVideo))
                        {
                            continue;
                        }
                        videosViewsLikes[dislikedVideo][1]--;
                    }
                    else
                    {
                        tokens = input.Split("-");
                        string video = tokens[0];
                        int views = int.Parse(tokens[1]);
                        if (!videosViewsLikes.ContainsKey(video))
                        {
                            videosViewsLikes[video] = new int[2];
                            videosViewsLikes[video][0] = 0;
                            videosViewsLikes[video][1] = 0;
                        }
                        videosViewsLikes[video][0] += views;
                    }
                }
            }
            string sortBy = Console.ReadLine();
            var result = new Dictionary<string, int[]>();
            if (sortBy == "by likes")
            {
                result = videosViewsLikes
                    .OrderByDescending(x => x.Value[1])
                    .ToDictionary(x => x.Key, x => x.Value);
            }
            else
            {
                result = videosViewsLikes
                    .OrderByDescending(x => x.Value[0])
                    .ToDictionary(x => x.Key, x => x.Value);
            }
            foreach (var kvp in result)
            {
                Console.Write($"{kvp.Key} - {kvp.Value[0]} views - {kvp.Value[1]} likes");


                Console.WriteLine();
            }
        }
    }
}
