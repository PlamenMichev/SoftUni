using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.AddedCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.AddedCommands
{
    public class Report : Command
    {
        public Report(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
