using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender, string type)
            : base(name, age, gender, type)
        {
            this.Gender = "Male";
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
