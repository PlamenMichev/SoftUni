using System;
using System.Linq;
using System.Reflection;
using MuOnline.Core.Factories.Contracts;
using MuOnline.Models.Heroes.HeroContracts;

namespace MuOnline.Core.Factories
{
    public class HeroFactory : IHeroFactory
    {
        //AddHero darkKnight gosho
        public IHero Create(string heroType, string username)
        {
            var heroName = heroType.ToLower();

            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == heroName);

            if (type == null)
            {
                throw new ArgumentNullException("Invalid type of hero!");
            }

            var hero = (IHero)Activator.CreateInstance(type, username);

            return hero;
        }
    }
}
