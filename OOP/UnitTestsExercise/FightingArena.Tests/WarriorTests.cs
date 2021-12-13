using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        Warrior warrior;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("", 15, 50)]
        [TestCase(null, 15, 50)]
        [TestCase(" ", 15, 50)]
        [TestCase("Zlati", 0, 50)]
        [TestCase("Zlati", -7, 50)]
        [TestCase("Zlati", 15, -20)]
        public void CtorInvalidInitialisationThrowsAnExc(string name, int dmg, int hp)
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(name, dmg, hp));
        }

        [Test]
        public void CtorSuccessfulInitialisation()
        {
            string name = "Zlati";
            int dmg = 20;
            int hp = 50;

            warrior = new Warrior(name, dmg, hp);

            Assert.That(warrior.Name, Is.EqualTo(name));
            Assert.That(warrior.Damage, Is.EqualTo(dmg));
            Assert.That(warrior.HP, Is.EqualTo(hp));
        }

        [Test]
        public void AttackWithHPBelow30ThrowsAnExc()
        {
            warrior = new Warrior("Koko", 30, 29);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Palqk", 20, 40)));
        }

        [Test]
        public void AttackEnemyWithHPBelow30ThrowsAnExc()
        {
            warrior = new Warrior("Koko", 30, 40);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Palqk", 20, 30)));
        }


        [Test]
        public void AttackingStrongerEnemyThrowsAnExc()
        {
            warrior = new Warrior("Koko", 20, 40);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Palqk", 60, 60)));
        }

        [Test]
        public void SuccessfulAttack()
        {
            warrior = new Warrior("Koko", 20, 40);
            var warrior2 = new Warrior("Bobi", 10, 33);
            warrior.Attack(warrior2);

            Assert.That(warrior2.HP, Is.EqualTo(13));
            Assert.That(warrior.HP, Is.EqualTo(30));
        }

        [Test]
        public void KillingAnEnemy()
        {
            warrior = new Warrior("Koko", 50, 40);
            var warrior2 = new Warrior("Bobi", 10, 33);
            warrior.Attack(warrior2);

            Assert.That(warrior2.HP, Is.Zero);
        }
    }
}