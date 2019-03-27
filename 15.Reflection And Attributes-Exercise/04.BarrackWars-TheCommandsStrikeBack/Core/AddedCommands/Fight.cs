using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.AddedCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.AddedCommands
{
    public class Fight : Command
    {
        public Fight(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return "";
        }
    }
}
