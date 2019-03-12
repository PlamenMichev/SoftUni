using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender, string type)
            : base(name, age, gender, type)
        {
            base.Gender = "Female";
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
