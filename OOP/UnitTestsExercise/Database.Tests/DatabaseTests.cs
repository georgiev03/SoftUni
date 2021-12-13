using System;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        [Test]
        public void DbCanStore16Ints()
        {
            int[] array = new int[16];
            for (int i = 0; i < 16; i++)
            {
                array[i] = i;
            }

            database = new Database(array);

            Assert.That(database.Count, Is.EqualTo(16));
        }

        [Test]
        public void DatabaseThrowsExcIfAddedMoreThan16Ints()
        {
            int[] array = new int[16];
            for (int i = 0; i < 16; i++)
            {
                array[i] = i;
            }

            database = new Database(array);

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void ThrowsAnExcWhenCapIsExceeded()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void AddsAnIntAndIncrementTheCount()
        {
            database = new Database(1, 2, 3, 4, 5);
            database.Add(6);

            Assert.That(database.Count, Is.EqualTo(6));
        }

        [Test]
        public void RemovesTheLastElement()
        {
            database = new Database(1, 2, 3, 4, 5);
            database.Remove();
            var checkArray = new int[] {1, 2, 3, 4};

            Assert.That(database.Count, Is.EqualTo(checkArray.Length));
        }

        [Test]
        public void RemovingFromEmptyDbThrowsAnExc()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchReturnsTheSameElements()
        {
            database = new Database(1, 2, 3, 4, 5);
            var elements = database.Fetch();

            Assert.That(elements.Length , Is.EqualTo(database.Count));
        }
    }
}