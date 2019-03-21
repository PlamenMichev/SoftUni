using System;

namespace _06.BirthdayCelebrations
{
    public class Person : IIdable, IBornable
    {
        private string name;
        private string id;
        private int age;

        public Person(string name, string id, int age, DateTime birthday)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
            this.BirthDate = birthday;
        }

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }

        public string Id
        {
            get => this.id;
            set
            {
                this.id = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                this.age = value;
            }
        }

        public DateTime BirthDate { get; set; }

        public bool EndsWith(string end)
        {
            return this.id.EndsWith(end);
        }
    }
}
