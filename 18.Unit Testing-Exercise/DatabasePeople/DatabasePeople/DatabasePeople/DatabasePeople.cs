namespace _02.ExtendedDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DatabasePeople
    {
        private List<Person> peopleData;

        public DatabasePeople(List<Person> peopleToAdd)
        {
            this.People = peopleToAdd;
        }

        public List<Person> People
        {
            get
            {
                return this.peopleData;
            }

            private set
            {
                this.peopleData = value;
            }
        }

        public void AddPerson(Person personToAdd)
        {
            if (this.People.Any(x => x.Name == personToAdd.Name))
            {
                throw new InvalidOperationException("A person with same name exists!");
            }
            else if (this.People.Any(x => x.Id == personToAdd.Id))
            {
                throw new InvalidOperationException("A person with same id exists!");
            }

            this.People.Add(personToAdd);
        }

        public void Remove(Person personToRemove)
        {
            if (this.peopleData.Contains(personToRemove))
            {
                this.peopleData.Remove(personToRemove);
            }
            else
            {
                throw new InvalidOperationException("User doesn't exist");
            }
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Empty username!");
            }
            else if (!this.peopleData.Any(x => x.Name == username))
            {
                throw new InvalidOperationException("User with cuurent username doesnt exist");
            }

            return this.peopleData.First(x => x.Name == username);
        }

        public Person FindById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id must be possitive");
            }
            else if (!this.peopleData.Any(x => x.Id == id))
            {
                throw new InvalidOperationException("User with cuurent username doesnt exist");
            }

            return this.peopleData.First(x => x.Id == id);
        }
    }
}
