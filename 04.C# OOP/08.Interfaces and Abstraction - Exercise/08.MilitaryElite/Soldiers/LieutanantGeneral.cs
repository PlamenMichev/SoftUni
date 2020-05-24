using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class LieutanantGeneral : Private, ILieutanantGeneral
    {
        public LieutanantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new HashSet<Private>();
        }

        public HashSet<Private> Privates { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Privates:");
            int count = 0;
            foreach (var privates in this.Privates)
            {
                
                if (count == this.Privates.Count - 1)
                {
                    sb.Append("  "+privates.ToString());
                }
                else
                {
                    sb.AppendLine("  "+privates.ToString());
                }
                count++;
            }
            
            return sb.ToString().Trim();
        }
    }
}
