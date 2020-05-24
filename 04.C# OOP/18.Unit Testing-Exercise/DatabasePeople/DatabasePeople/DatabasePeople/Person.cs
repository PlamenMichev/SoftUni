using System;
using System.Collections.Generic;
using System.Text;

namespace _02.ExtendedDatabase
{
    public class Person : IEquatable<Person>
    {
        private string name;
        private int id;

        public Person(string name, int id)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id
        {
            get => id;
            private set => id = value;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public bool Equals(Person other)
        {
            return this.Id == other.Id
                   && this.Name == other.Name;
        }
    }
}
