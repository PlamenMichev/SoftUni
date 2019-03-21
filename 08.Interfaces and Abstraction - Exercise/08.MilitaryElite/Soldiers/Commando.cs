using _08.MilitaryElite.Enums;
using _08.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.MilitaryElite.Soldiers
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new HashSet<Mission>();
        }

        public HashSet<Mission> Missions { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine($"Missions:");
            int count = 0;
            foreach (var privates in this.Missions)
            {

                if (count == this.Missions.Count - 1)
                {
                    sb.Append(privates.ToString());
                }
                else
                {
                    sb.AppendLine(privates.ToString());
                }
                count++;
            }

            return sb.ToString().Trim();
        }
    }
}
