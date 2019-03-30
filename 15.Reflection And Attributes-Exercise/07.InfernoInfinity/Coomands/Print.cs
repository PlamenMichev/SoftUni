using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _07.InfernoInfinity.Models;

namespace _07.InfernoInfinity.Coomands
{
    public class Print : Command
    {
        public override void Execute(List<Weapon> weapons, string[] args)
        {
            string name = args[1];

            var weapon = weapons.FirstOrDefault(x => x.Name == name);

            Console.WriteLine(weapon);
        }
    }
}
