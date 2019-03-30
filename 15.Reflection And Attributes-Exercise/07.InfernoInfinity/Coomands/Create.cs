using _07.InfernoInfinity.Enums;
using _07.InfernoInfinity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _07.InfernoInfinity.Coomands
{
    public class Create : Command
    {
        public override void Execute(List<Weapon> weapons, string[] args)
        {
            string type = args[1];
            string[] typeArgs = type.Split();
            string levelOfRearityAsString = typeArgs[0];
            string typeOfWeapon = typeArgs[1];
            string name = args[2];
            LevelOfRearity levelOfRerity = (LevelOfRearity)Enum.Parse(typeof(LevelOfRearity), levelOfRearityAsString);

            var weaponType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == typeOfWeapon);
            var constructor = weaponType
                .GetConstructor(BindingFlags.Instance | BindingFlags.Public,
                null, 
                new Type[] 
                { typeof(string), typeof(Stats), typeof(LevelOfRearity), typeof(List<Gem>) },
                null);

            var weapon = constructor.Invoke(new object[] { name, new Stats(), levelOfRerity, new List<Gem>() });
                
            weapons.Add((Weapon)weapon);
        }
    }
}
