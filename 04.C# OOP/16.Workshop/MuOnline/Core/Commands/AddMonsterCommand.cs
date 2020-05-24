namespace MuOnline.Core.Commands
{
    using MuOnline.Core.Commands.Contracts;
    using MuOnline.Core.Factories.Contracts;
    using MuOnline.Models.Monsters.Contracts;
    using MuOnline.Repositories.Contracts;

    public class AddMonsterCommand : ICommand
    {
        private const string addedMonsterMessege = "Successfully crated monster {0}";

        private IRepository<IMonster> repository;
        private IMonsterFactory factory;

        public AddMonsterCommand(IRepository<IMonster> repository, IMonsterFactory factory)
        {
            this.repository = repository;
            this.factory = factory;
        }

        public string Execute(string[] inputArgs)
        {
            string monsterType = inputArgs[0];
            var monster = factory.Create(monsterType);

            this.repository.Add(monster);
            //
            return string.Format(addedMonsterMessege, monster.GetType().Name);
        }
    }
}
