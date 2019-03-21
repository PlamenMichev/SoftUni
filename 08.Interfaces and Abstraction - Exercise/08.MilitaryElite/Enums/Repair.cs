using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Enums
{
    public class Repair
    {
        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        public string PartName { get; set; }
        
        public int HoursWorked { get; set; }

        public override string ToString()
        {
            return $"  Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
        }
    }
}
