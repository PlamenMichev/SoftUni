using MuOnline.Core.Factories.Contracts;
using MuOnline.Models.Monsters;
using MuOnline.Models.Monsters.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace MuOnline.Core.Factories
{
    public class MonsterFactory : IMonsterFactory
    {
        public IMonster Create(string monsterTypeName)
        {
            string monsterTypeToCheck = monsterTypeName.ToLower();
            var monsterType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(IMonster).IsAssignableFrom(x))
                .FirstOrDefault(x => x.Name.ToLower() == monsterTypeToCheck);

            //TODO not sure? test it


            if (monsterType == null)
            {
                throw new ArgumentNullException("Invalid type of monster!");
            }

            var monster = (IMonster)Activator.CreateInstance(monsterType);

            return monster;
        }
    }
}
