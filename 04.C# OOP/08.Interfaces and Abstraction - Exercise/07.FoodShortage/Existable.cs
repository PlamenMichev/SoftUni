using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage
{
    public abstract class Existable : IBornable, IIdable, IBuyer
    {
        protected Existable(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        protected Existable(string name, int age, string id, DateTime birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = birthdate;
        }

        public int Age { get; set; }

        public string Group { get; set; }

        public DateTime BirthDate { get; set; }

        public string Name { get; set; }

        public string Id { get; }

        public int Food { get; set; }

        public abstract int BuyFood();
    }
}
