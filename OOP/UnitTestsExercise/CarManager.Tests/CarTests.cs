using System;
using NUnit.Framework;

namespace CarManager.Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("BMW", "X6", 10, 80);
        }

        [Test]
        public void CtorInitialisesCorrectly()
        {
            string make = "Bmw";
            string model = "X6";
            double fuelConsumption = 10;
            double fuelCapacity = 100;

            car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        [TestCase("", "X6", 10, 100)]
        [TestCase(null, "X6", 10, 100)]
        [TestCase("Bavarec", "", 10, 100)]
        [TestCase("Bavarec", null, 10, 100)]
        [TestCase("Bavarec", "X6", 0, 100)]
        [TestCase("Bavarec", "X6", -34, 100)]
        [TestCase("Bavarec", "X6", -34, 0)]
        [TestCase("Bavarec", "X6", -34, -15)]

        public void CtorThrowsAnExcWhenDataIsIncorrect(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void RefuelWithNegetiveAmountOrZeroThrowsAnExc(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void FuelConsumptionReturnsCorrectValue()
        {
            Assert.That(car.FuelConsumption, Is.EqualTo(10));
        }

        [Test]
        public void FuelCapacityReturnsCorrectValue()
        {
            Assert.That(car.FuelCapacity, Is.EqualTo(80));
        }

        [Test]
        public void FuelAmountReturnsCorrectValue()
        {
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void EmptyMakeThrowsAnExc()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("", "X6", 12.3, 80));
        }

        [Test]
        public void EmptyModelThrowsAnExc()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Bmw", null, 12.3, 80));
        }

        [Test]
        public void ZeroConsumptionThrowsAnException()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Bmw", "X6", 0, 80));
        }

        [Test]
        public void NegativeFuelAmountThrowsAnExc()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("Bmw", "X6", 12.3, -4));
        }

        [Test]
        public void CorrectlyRefuelTheCar()
        {
            car.Refuel(20);

            Assert.That(car.FuelAmount, Is.EqualTo(20));
        }

        [Test]
        public void RefuelWithNegetiveAmountThrowsAnExc()
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(-3));
        }

        [Test]
        public void CannotRefuelOverTheFuelCap()
        {
            car.Refuel(100);

            Assert.That(car.FuelAmount , Is.EqualTo(80));
        }

        [Test]
        public void CorrectDriving()
        {
            car.Refuel(10);
            car.Drive(10);

            Assert.AreEqual(9, car.FuelAmount);
        }

        [Test]
        public void DrivingWithNotEnoughFuelThrowsAnExc()
        {
            Assert.Throws<InvalidOperationException>(() => car.Drive(10));
        }
    }
}