using _08.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Soldiers
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get => this.corps;
            set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("invalid corps");
                }

                this.corps = value;
            }
        }
    }
}
