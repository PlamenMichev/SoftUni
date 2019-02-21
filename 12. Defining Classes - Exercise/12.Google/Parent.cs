using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace _12.Google
{
    public class Parent
    {
        public string Name { get; set; }

        public string Birthday { get; set; }

        public Parent(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public Parent()
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
