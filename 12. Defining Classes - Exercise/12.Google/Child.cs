using System;
using System.Collections.Generic;
using System.Text;

namespace _12.Google
{
    public class Child
    {
        public string Name { get; set; }

        public string Birthday { get; set; }

        public Child(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public Child()
        {
            
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.Append($"{this.Name} {this.Birthday}");

            return sb.ToString().TrimEnd();
        }
    }
}
