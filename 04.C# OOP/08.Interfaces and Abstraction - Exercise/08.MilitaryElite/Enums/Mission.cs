using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Enums
{
    public class Mission
    {
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; set; }

        public string State
        {
            get => this.state;
            set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException("invalid mission state");
                }

                this.state = value;
            }
        }

        public void CompleteMission()
        {
            this.state = "Finished";
        }

        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.state}";
        }
    }
}
