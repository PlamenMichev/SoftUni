using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using _07.InfernoInfinity.Enums;
using _07.InfernoInfinity.Models;

namespace _07.InfernoInfinity.Coomands
{
    public class Add : Command
    {
        public override void Execute(List<Weapon> weapons, string[] args)
        {
            string name = args[1];
            int index = int.Parse(args[2]);
            string[] gemTokens = args[3].Split();
            string gemQualityAsString = gemTokens[0];
            string gemType = gemTokens[1];
            GemsQuality gemQuality = (GemsQuality)Enum.Parse(typeof(GemsQuality), gemQualityAsString);

            Type type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == gemType);
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public,
                null,
                new Type[] { typeof(GemsQuality) },
                null);

            Gem gem = (Gem)constructor.Invoke(new object[] { gemQuality });

            var weapon = weapons.FirstOrDefault(x => x.Name == name);


            if (weapon.GemPlacement.ContainsKey(index))
            {
                weapon.GemPlacement[index] = gem;
            }
            else
            {
                if (index >= 0 && index < weapon.Stats.NumberOfSockets)
                {
                    weapon.GemPlacement[index] = gem;
                }
            }
            
        }
    }
}
