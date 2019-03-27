using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.AddedCommands;
using _05.BarracksWars_ReturnOfTheDependencies.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.AddedCommands
{
    public class Report : Command
    {
        [Injection]
        IRepository repository;

        public Report(string[] data, IRepository repository) 
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
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
