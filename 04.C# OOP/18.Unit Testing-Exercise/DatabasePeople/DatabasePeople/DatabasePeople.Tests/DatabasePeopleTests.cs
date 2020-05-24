using _02.ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private List<Person> peopleToAdd;
        private _02.ExtendedDatabase.DatabasePeople people;

        [SetUp]
        public void Setup()
        {
            peopleToAdd = new List<Person>
            {
                new Person("Plamen", 12),
                new Person("Ceco", 41),
                new Person("Manqka", 69)
            };

            people = new _02.ExtendedDatabase.DatabasePeople(peopleToAdd);
        }

        [Test]
        public void ConstructorShouldSetTheInitialCollection()
        {
            //Arrange
            _02.ExtendedDatabase.DatabasePeople data = new _02.ExtendedDatabase.DatabasePeople(peopleToAdd);

            //Assert
            Assert.That(data.People, Is.EqualTo(peopleToAdd));
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionForUsername()
        {
            Assert.Throws<InvalidOperationException>
                (() => people.AddPerson(new Person("Plamen", 12)));
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionForId()
        {
            Assert.Throws<InvalidOperationException>
                (() => people.AddPerson(new Person("Cvatq", 12)));
        }

        [Test]
        public void RemoveMethodShouldRemoveAPersonFromCollection()
        {
            //Act
            Person personToRemove = new Person("Plamen", 12);
            people.Remove(personToRemove);

            //Assert
            Assert.AreEqual(2, people.People.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowNoUserException()
        {
            //Act
            Person personToRemove = new Person("Goshko", 12);
            

            //Assert
            Assert.Throws<InvalidOperationException>(() => people.Remove(personToRemove));
        }

        [Test]
        public void FindByUsernameMethodShouldThrowAnInvalidOperationException()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() => people.FindByUsername("Ginka"));
        }

        [Test]
        public void FindByUsernameMethodShouldThrowAnArgumentNullException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(() => people.FindByUsername(null));
        }

        [Test]
        public void FindByIdMethodShouldThrowAnInvalidOperationException()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() => people.FindById(27));
        }

        [Test]
        public void FindByIdMethodShouldThrowAnArgumentOutOfRangeException()
        {
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => people.FindById(-20));
        }
    }
}