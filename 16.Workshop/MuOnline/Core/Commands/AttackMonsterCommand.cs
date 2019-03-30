using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MuOnline.Core.Commands.Contracts;
using MuOnline.Models.Heroes.HeroContracts;
using MuOnline.Models.Monsters.Contracts;
using MuOnline.Repositories.Contracts;

namespace MuOnline.Core.Commands
{
    public class AttackMonsterCommand : ICommand
    {
        private const string outputMessege = "{0} is dead!";

        private readonly IRepository<IHero> heroRepository;
        private readonly IRepository<IMonster> monsterRepository;

        public AttackMonsterCommand(IRepository<IHero> heroRepository, IRepository<IMonster> monsterRepository)
        {
            this.heroRepository = heroRepository;
            this.monsterRepository = monsterRepository;
        }

        public string Execute(string[] inputArgs)
        {
            string heroUsername = inputArgs[0];
            string monsterName = inputArgs[1];

            var hero = heroRepository
                .Get(heroUsername);
            var monster = monsterRepository
                .Get(monsterName);

            var heroAttackPoints = hero.TotalAttackPoints;
            var monsterAttackPoints = monster.AttackPoints;

            while (hero.IsAlive && monster.IsAlive)
            {
                hero.TakeDamage(monsterAttackPoints);
                if (!hero.IsAlive)
                {
                    break;
                }
                var experience = monster.TakeDamage(heroAttackPoints);

                ((IProgress) hero).AddExperience(experience);
            }

            

            return string.Format(outputMessege, hero.IsAlive ? monster.GetType().Name : heroUsername);
        }
    }
}
