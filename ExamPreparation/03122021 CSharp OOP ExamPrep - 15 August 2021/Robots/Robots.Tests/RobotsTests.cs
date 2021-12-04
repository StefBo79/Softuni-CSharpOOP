namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void ConstructurShoudSetCapacity()
        {
            var robots = new RobotManager(4);
            Assert.AreEqual(4, robots.Capacity);
        }

        [Test]
        public void ConstructorShoudThrowAnExeptionForNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-3));
        }

        [Test]
        public void EmptyRobotManagerShoudHaveCountOfZero()
        {
            var robots = new RobotManager(100);
            Assert.AreEqual(0, robots.Count);
        }

        [Test]
        public void RobotManagerShoudHaveProperCount()
        {
            var robots = new RobotManager(100);
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 100));
            robots.Add(new Robot("r3", 100));
            Assert.AreEqual(3, robots.Count);
        }

        [Test]
        public void AddShoudThrowAnExeptionForRobotsWithSameName()
        {
            var robots = new RobotManager(100);
            robots.Add(new Robot("r1", 100));
            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("r1", 100)));
        }

        [Test]
        public void AddShoudThrowAnExeptionWhenCapacityIsReached()
        {
            var robots = new RobotManager(2);
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 100));
            Assert.Throws<InvalidOperationException>(() => robots.Add(new Robot("r3", 100)));
        }

        [Test]
        public void RemoveShoudWorkProperly()
        {
            var robots = new RobotManager(100);
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 100));
            robots.Remove("r2");
            Assert.AreEqual(1, robots.Count);
        }

        [Test]
        public void RemoveShoudThrowAnExeptionWhenRobotIsNotFound()
        {
            var robots = new RobotManager(100);
            robots.Add(new Robot("r1", 100));
            robots.Add(new Robot("r2", 100));
            Assert.Throws<InvalidOperationException>(() => robots.Remove("r3"));
        }

        [Test]
        public void WorkShoudWorkProperly()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("r1", 100);
            robots.Add(robot);
            robots.Work("r1", "...", 40);
            Assert.AreEqual(60, robot.Battery);
        }

        [Test]
        public void WorkShoudThrowAnExeptionWhenRobotIsNotFound()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("r1", 100);
            robots.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robots.Work("r2", "...", 40));
        }

        [Test]
        public void WorkShoudThrowAnExeptionWhenRobotIsOutOfPower()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("r1", 100);
            robots.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robots.Work("r1", "...", 110));
        }

        [Test]
        public void ChargeShoudWorkProperly()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("r1", 100);
            robots.Add(robot);
            robots.Work("r1", "...", 60);
            robots.Charge("r1");
            Assert.AreEqual(100, robot.Battery);
        }

        [Test]
        public void ChargeShoudThrowAnExeptionWhenRobotIsNotFound()
        {
            var robots = new RobotManager(2);
            var robot = new Robot("r1", 100);
            robots.Add(robot);
            robots.Work("r1", "...", 60);            
            Assert.Throws<InvalidOperationException>(() => robots.Charge("r2"));
        }
    }
}
