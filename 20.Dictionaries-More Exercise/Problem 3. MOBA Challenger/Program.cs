using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Problem_3._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var playersPositionsAndSkills = new Dictionary<string, Dictionary<string, int>>();
            var positionWithSkills = new Dictionary<string, int>();
            List<string> destroyedPlayers = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Season end")
                {
                    break;
                }

                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[1] == "->")
                {
                    string player = tokens[0];
                    string position = tokens[2];
                    int points = int.Parse(tokens[4]);

                    if (!playersPositionsAndSkills.ContainsKey(player))
                    {
                        playersPositionsAndSkills[player] = new Dictionary<string, int>();
                    }

                    if (!playersPositionsAndSkills[player].ContainsKey(position))
                    {
                        playersPositionsAndSkills[player].Add(position, 0);
                    }

                    if (playersPositionsAndSkills[player][position] < points)
                    {
                        playersPositionsAndSkills[player][position] = points;
                    }
                }
                else if(tokens[1] == "vs")
                {
                    string firstPlayer = tokens[0];
                    string secPlayer = tokens[2];

                    if (playersPositionsAndSkills.ContainsKey(firstPlayer) && playersPositionsAndSkills.ContainsKey(secPlayer))
                    {
                        foreach (var kvp in playersPositionsAndSkills[firstPlayer])
                        {
                            
                            if (playersPositionsAndSkills[secPlayer].ContainsKey(kvp.Key))
                            {
                                if (playersPositionsAndSkills[secPlayer][kvp.Key] >
                                    playersPositionsAndSkills[firstPlayer][kvp.Key])
                                {
                                    destroyedPlayers.Add(firstPlayer);
                                }
                                else if (playersPositionsAndSkills[secPlayer][kvp.Key] <
                                         playersPositionsAndSkills[firstPlayer][kvp.Key])
                                     {
                                        destroyedPlayers.Add(secPlayer);
                                     }                               
                            }
                        }
                    }
                }
            }

            foreach (var kvp in playersPositionsAndSkills.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                if (!destroyedPlayers.Contains(kvp.Key))
                {
                    int teamSum = kvp.Value.Values.Sum();
                    Console.WriteLine($"{kvp.Key}: {teamSum} skill");
                    foreach (var secKvp in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                    {
                        Console.WriteLine($"- {secKvp.Key} <::> {secKvp.Value}");
                    }
                }
                
            }
        }
    }
}
