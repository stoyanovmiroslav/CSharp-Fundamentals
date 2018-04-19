using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace UnitTests
{
    public class BubbleTests
    {
        [TestCase(9, 2, 5, 6, 7, 8, 1, 3, 4)]
        [TestCase(9, 2, 3, 4, 5, 6, 7, 8, 1)]
        [TestCase(9, 8, 7, 6, 5, 4, 3, 2, 1)]
        public void CheckOrder(params int[] numbers)
        {
            Bubble bubble = new Bubble();
            int[] sortedNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bubble.Sort(numbers);

            Assert.That(numbers, Is.EqualTo(sortedNumbers));
        }
    }
}
