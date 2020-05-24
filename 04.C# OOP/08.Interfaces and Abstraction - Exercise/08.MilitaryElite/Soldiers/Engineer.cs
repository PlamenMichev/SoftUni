using _08.MilitaryElite.Enums;
using _08.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Soldiers
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new HashSet<Repair>();
        }

        public HashSet<Repair> Repairs { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine($"Repairs:");
            int count = 0;
            foreach (var privates in this.Repairs)
            {

                if (count == this.Repairs.Count - 1)
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
