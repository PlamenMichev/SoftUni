using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public class Cat : Animal
    {

        public Cat(string name, int age, string gender, string type) 
            : base(name, age, gender, type)
        {
        }

        public override string ProduceSound()
        {
            return "Meow meow";
        }
    }
}
