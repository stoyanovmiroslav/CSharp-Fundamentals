using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace UnitTests
{
    public class IteratorTests
    {
        private ListIterator<int> listIterator;
        private int[] initializingCollection;

        [SetUp]
        public void Initializing()
        {
            this.initializingCollection = new int[] {1, 2, 3 };
            this.listIterator = new ListIterator<int>(this.initializingCollection);
        }

        [Test]
        public void CreateListIteratorCorrectly()
        {
            var iterType = typeof(ListIterator<int>);
            FieldInfo field = iterType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).First(f => f.Name == "elements");

            List<int> newList = (List<int>)field.GetValue(listIterator);
            Assert.That(newList, Is.EqualTo(initializingCollection));
        }

        [Test]
        public void MovingSuccessfulToNextElement()
        {
            listIterator.Move();
            Assert.That(listIterator.Move(), Is.EqualTo(true));
        }

        [Test]
        public void MovingUnsuccessfulToNextElement()
        {
            listIterator.Move();
            listIterator.Move();
            Assert.That(listIterator.Move(), Is.EqualTo(false));
        }

        [Test]
        public void SuccessfulCheckikForNextElement()
        {
            listIterator.Move();
            Assert.That(listIterator.HasNext, Is.EqualTo(true));
        }


        [Test]
        public void UnsuccessfulCheckikForNextElement()
        {
            listIterator.Move();
            listIterator.Move();
            Assert.That(listIterator.HasNext, Is.EqualTo(false));
        }

        [Test]
        public void PrintingCurrentElement()
        {
            int currentElement = 3;

            listIterator.Move();
            listIterator.Move();
            Assert.That(listIterator.Print(), Is.EqualTo(currentElement.ToString()));
        }

        [Test]
        public void CallingPrintOnCollectionWithoutElements()
        {
            ListIterator <string> listIterator = new ListIterator<string>(new List<string>());
            Assert.That(() => listIterator.Print(),
                Throws.InvalidOperationException.With.Message.EqualTo("Invalid Operation!"));
        }

        [Test]
        public void PassedNullToTheConstructor()
        {
            Assert.That(() => new ListIterator<string>(null), Throws.ArgumentNullException);
        }
    }
}