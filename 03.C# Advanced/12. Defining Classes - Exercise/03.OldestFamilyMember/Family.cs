using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public List<Person> People
        {
            get => this.people;
            set => this.people = value;
        }

        public Family()
        {
            this.People = new List<Person>();
        }

        public void AddMember(Person person)
        {
            People.Add(person);
        }

        public Person GetOldestMember()
        {
            var oldestPerson = People.First();

            foreach (var person in People)
            {
                if (person.Age > oldestPerson.Age)
                {
                    oldestPerson = person;
                }                
            }

            return oldestPerson;
        }
    }
}
