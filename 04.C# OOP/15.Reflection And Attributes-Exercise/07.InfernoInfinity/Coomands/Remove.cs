using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _07.InfernoInfinity.Models;

namespace _07.InfernoInfinity.Coomands
{
    public class Remove : Command
    {
        public override void Execute(List<Weapon> weapons, string[] args)
        {
            string name = args[1];
            int index = int.Parse(args[2]);
            var weapon = weapons.FirstOrDefault(x => x.Name == name);

            if (index >= 0 && index < weapon.Stats.NumberOfSockets)
            {
                var gem = weapon.GemPlacement.FirstOrDefault(x => x.Key == index);
                weapon.GemPlacement.Remove(index);
            }
        }
    }
}
