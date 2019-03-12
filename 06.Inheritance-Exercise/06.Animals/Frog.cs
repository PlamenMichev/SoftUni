using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public class Frog : Animal
    {

        public Frog(string name, int age, string gender, string type) 
            : base(name, age, gender, type)
        {
        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }
    }
}
