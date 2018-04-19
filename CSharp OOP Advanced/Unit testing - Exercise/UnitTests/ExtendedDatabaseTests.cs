using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using _02.ExtendedDatabase;

namespace UnitTests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private string personName = "Ivan";
        private long personId = long.MaxValue;

        [SetUp]
        public void SetUp()
        {
            Person person = new Person(personId, personName);
            this.database = new ExtendedDatabase(person);
        }

        [Test]
        public void AddingPersonsInTheArray()
        {
            string name = "Pesho";
            long id = 1;

            Person person = new Person(id, name);
            database.Add(person);

            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddingPersonWithExistingUserName()
        {
            long id = 1;

            Person person = new Person(id, this.personName);
            Assert.That(() => database.Add(person), Throws.InvalidOperationException);
        }

        [Test]
        public void AddingPersonWithExistingId()
        {
            string name = "Misho";

            Person person = new Person(this.personId, name);
            Assert.That(() => database.Add(person), Throws.InvalidOperationException);
        }

        [Test]
        public void RemovingPersonsInTheArray()
        {
            int expectedCount = 0;

            database.Remove();
            Assert.That(database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void FindingPersonsByUserName()
        {
            string name = "Pesho";
            long id = 1;
            Person person = new Person(id, name);
            database.Add(person);
            
            Assert.That(database.FindByUsername(name), Is.EqualTo(person));
        }

        [Test]
        public void TryToFindPersonsByInvalidUserName()
        {
            string name = "Pesho";
            long id = 1;
            string invalidUserName = "Gosho";

            Person person = new Person(id, name);
            database.Add(person);

            Assert.That(() => database.FindByUsername(invalidUserName), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void TryToFindPersonLikeSubmitNullForUserName()
        {
            string name = "Pesho";
            long id = 1;
            string invalidUserName = "";

            Person person = new Person(id, name);
            database.Add(person);

            Assert.That(() => database.FindByUsername(invalidUserName), Throws.ArgumentNullException);
        }

        [Test]
        public void FindingPersonsById()
        {
            string name = "Pesho";
            long id = 1;
            Person person = new Person(id, name);
            database.Add(person);

            Assert.That(database.FindById(id), Is.EqualTo(person));
        }

        [Test]
        public void TryToFindPersonsByInvalidId()
        {
            string name = "Pesho";
            long id = 1;
            long invalidUserName = 2;

            Person person = new Person(id, name);
            database.Add(person);

            Assert.That(() => database.FindById(invalidUserName), Throws.InvalidOperationException);
        }

        [Test]
        public void TryToFindPersonsLikeSubmitNegativeNumber()
        {
            string name = "Pesho";
            long id = 1;
            long invalidUserName = -2;

            Person person = new Person(id, name);
            database.Add(person);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(invalidUserName));
        }
    }
}