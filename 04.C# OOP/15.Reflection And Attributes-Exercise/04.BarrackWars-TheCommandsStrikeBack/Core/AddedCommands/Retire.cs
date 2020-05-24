using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.AddedCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.AddedCommands
{
    public class Retire : Command
    {
        public Retire(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
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
