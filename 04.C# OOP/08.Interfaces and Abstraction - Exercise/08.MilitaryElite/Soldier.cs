using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public abstract int Id { get; set; }

        public abstract string FirstName { get; set; }

        public abstract string LastName { get; set; }
    }
}
