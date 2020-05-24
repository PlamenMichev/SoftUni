using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender, string type) 
            : base(name, age, gender, type)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
