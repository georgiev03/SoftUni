using System;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private Person personOne;
        private Person personTwo;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase();
            personOne = new Person(1230, "Tarikata");
            personTwo = new Person(5540, "Manqka");

            database.Add(personOne);
            database.Add(personTwo);
        }

        [Test]
        public void SuccessfullyAddAPerson()
        {
            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void ThrowAnExcWhenAddedTwoPeopleWithSameUsername()
        {
            Person personThree = new Person(6990, "Tarikata");

            Assert.Throws<InvalidOperationException>(() => database.Add(personThree));
        }

        [Test]
        public void ThrowAnExcWhenAddedTwoPeopleWithSameId()
        {
            Person personThree = new Person(1230, "Asen");

            Assert.Throws<InvalidOperationException>(() => database.Add(personThree));
        }

        [Test]
        public void CtorSuccessfullyAddsAPeronArr()
        {
            Person[] people = new Person[2];

            database = new ExtendedDatabase(new Person(32146, "Kurcho"),
                new Person(8435, "Gospodin"));

            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void RemovingAPersonSuccessFully()
        {
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemovingAPersonFromEmptyDbThrowsAnExc()
        {
            database.Remove();
            database.Remove();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void ThrowAnExcIfThereIsntAUserWithTheGivenName()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Hari"));
        }

        [Test]
        public void ThrowAnExcWhenNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void ThrowAnExcIfThereIsntAUserWithTheGivenId()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(007));
        }

        [Test]
        public void ThrowAnExcWhenIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-3));
        }

        [Test]
        public void OverExceedTheCapThrowsAnExc()
        {
            for (int i = 0; i < 14; i++)
            {
                database.Add(new Person(i, i.ToString()));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(44, "koko")));
        }

        public void OverExceedTheCapThrowsAnExcWithArray()
        {
            Person[] people = new Person[15];

            for (int i = 0; i < 15; i++)
            {
                people[i] = (new Person(i, i.ToString()));
            }

            Assert.Throws<ArgumentException>(
                () => database = new ExtendedDatabase(people));
        }

        [Test]
        public void FindsTheCorrectPersonByUsername()
        {
            Person person = database.FindByUsername("Tarikata");

            Assert.AreEqual(personOne, person);
        }

        [Test]
        public void FindsTheCorrectPersonById()
        {
            Person person = database.FindById(1230);

            Assert.AreEqual(personOne, person);
        }

    }
}