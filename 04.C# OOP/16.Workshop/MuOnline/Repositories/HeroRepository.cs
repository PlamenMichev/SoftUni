namespace MuOnline.Repositories
{
    using MuOnline.Models.Heroes.HeroContracts;
    using MuOnline.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;

        public IReadOnlyCollection<IHero> Repository
            => this.heroes.AsReadOnly();
        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public void Add(IHero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            this.heroes.Add(hero);
        }

        public IHero Get(string hero)
        {
            var targetHero = heroes.
                FirstOrDefault(h => ((IIdentifiable)h).Username == hero);

            if (targetHero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            return targetHero;
        }

        public bool Remove(IHero hero)
        {
            if (hero == null)
            {
                throw new ArgumentNullException("Hero cannot be null!");
            }

            bool isRemoved = this.heroes.Remove(hero);

            return isRemoved;
        }
    }
}
