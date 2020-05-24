using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.AddedCommands;
using _05.BarracksWars_ReturnOfTheDependencies.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.AddedCommands
{
    public class Retire : Command
    {
        [Injection]
        IRepository repository;

        public Retire(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository
        {
            get => repository;
            set => repository = value;
        }

        public override string Execute()
        {
            string result = string.Empty;
            try
            {
                string name = this.Data[1];
                this.Repository.RemoveUnit(name);
                return $"{name} retired!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
