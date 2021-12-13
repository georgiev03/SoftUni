using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        Warrior warrior;
        Warrior warrior2;
        Arena arena;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Koko", 20, 40);
            warrior2 = new Warrior("Bobi", 10, 33);

            arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(warrior2);
        }

        [Test]
        public void AlreadyEnrolledWarriorThrowsAnExc()
        {
            var testWarrior = new Warrior("Bobi", 15, 25);
            Assert.Throws<InvalidOperationException>(()=> arena.Enroll(testWarrior));
        }

        [Test]
        public void SuccessfulEnrollingAWarrior()
        {
            var testWarrior = new Warrior("Haralambi", 15, 25);
            arena.Enroll(testWarrior);

            Assert.That(arena.Count, Is.EqualTo(3));
        }

        [Test]
        [TestCase("Dancho", "Koko")]
        [TestCase("Bobi", "")]
        public void FightingWithInvalidWarriorsThrowsAnExc
            (string firstWarrior, string secondWarrior)
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight(firstWarrior, secondWarrior));
        }

        [Test]
        public void SuccessfulFight()
        {
            string firstWarrior = "Bobi";
            string secondWarrior = "Koko";
            arena.Fight(firstWarrior, secondWarrior);

            Assert.That(warrior.HP, Is.EqualTo(30));
            Assert.That(warrior2.HP, Is.EqualTo(13));
        }
    }
}
