using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations
{
    public class Pet : IBornable
    {
        public Pet(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
