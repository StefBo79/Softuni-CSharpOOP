namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium("Riverworld", 20);
            this.fish = new Fish("Nemo");
            this.aquarium.Add(this.fish);
        }

        [Test]
        public void ValidAquariumName()
        {
            Assert.Throws<ArgumentNullException>(() => this.aquarium = new Aquarium(null, 20));
            Assert.Throws<ArgumentNullException>(() => this.aquarium = new Aquarium(string.Empty, 20));
        }

        [Test]
        public void Constructor_ShouldWorkProperly()
        {
            string expectedName = "Riverworld";
            int expectedCapacity = 20;
            Assert.AreEqual(expectedName, this.aquarium.Name);
            Assert.AreEqual(expectedCapacity, this.aquarium.Capacity);
        }

        [Test]
        public void CapacityShoudNotBeLessThenZero()
        {
            Assert.Throws<ArgumentException>(() => this.aquarium = new Aquarium("Riverworld", -1));       
        }

        [Test]
        public void IfTheCapacityIsNotEnough()
        {
            this.aquarium = new Aquarium("Riverworld", 1);
            this.aquarium.Add(this.fish);
            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(this.fish));
        }

        [Test]
        public void Count_ShoulWorkProperly()
        {
            Assert.AreEqual(1, this.aquarium.Count);
        }

        [Test]
        public void AddShoudWorkProperly()
        {
            this.aquarium.Add(new Fish("Bambi"));
            Assert.AreEqual(2, this.aquarium.Count);
        }

        [Test]
        public void RemoveShoudWorkProperly()
        {
            this.aquarium.Add(new Fish("Bambi"));
            this.aquarium.RemoveFish("Bambi");
            Assert.AreEqual(1, this.aquarium.Count);
        }

        [Test]
        public void ShoudThrowExeptionIfFishToRemoveIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish(null));
        }

        [Test]
        public void ShoudThrowExeptionIfFishToSellisNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish(null));
        }

        [Test]
        public void SellFish_ShouldWorkProperly()
        {
            Fish soldFish = this.aquarium.SellFish("Nemo");
            Assert.IsFalse(soldFish.Available);
        }

        [Test]
        public void Report_ShouldWorkProperly()
        {
            this.aquarium.Add(new Fish("Dori"));
            string expected = $"Fish available at Riverworld: Nemo, Dori";
            Assert.AreEqual(expected, this.aquarium.Report());
        }
    }
}
