using System;
using NUnit.Framework;
using _01.Database;

namespace UnitTests
{
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            this.database = new Database(1);
        }

        [Test]
        public void AddingNumbersToArray()
        {
            database.Add(1);
            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void TrowingExeptionWhenArrayIsFull()
        {
            for (int i = 0; i < 15; i++)
            {
                database.Add(1);
            }
            
            Assert.That(() => database.Add(1), Throws.InvalidOperationException);
        }

        [Test]
        public void RemovingNumbersToArray()
        {
            database.Remove();
            Assert.That(database.Count , Is.EqualTo(0));
        }

        [Test]
        public void TrowingExeptionWhenArrrayIsEmpty()
        {
            database.Remove();
            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void ReturningTheArray()
        {
            database.Add(2);
            Assert.That(() => database.Fetch(), Is.EquivalentTo(new int[] { 1 , 2 }));
        }
    }
}
