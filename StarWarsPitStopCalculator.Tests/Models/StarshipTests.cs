using Moq;
using NUnit.Framework;
using StarWarsPitStopCalculator.Services.Models;
using System;

namespace StarWarsPitStopCalculator.Tests.Models
{
    [TestFixture]
    public class StarshipTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }


        [Test]
        public void NecesaryNumberOfStops_NoJumpsNeeded_Returns0()
        {
            // Arrange
            var unitUnderTest = new Starship() { MegalightYearsPerHour = 100, NoOfDaysBetweenPitStops = 10 };
            long distance = 100;

            // Act
            var result = unitUnderTest.NecesaryNumberOfStops(
                distance);

            // Assert
            Assert.AreEqual(0, result);
        }
        [Test]
        public void NecesaryNumberOfStops_1JumpNeeded_Returns1()
        {
            // Arrange
            var unitUnderTest = new Starship() { MegalightYearsPerHour = 100, NoOfDaysBetweenPitStops = 10 };
            long distance = 25000;

            // Act
            var result = unitUnderTest.NecesaryNumberOfStops(
                distance);

            // Assert
            Assert.AreEqual(1, result);
        }
        [Test]
        public void NecesaryNumberOfStops_2JumpsNeededRightAboveInterval_Returns2()
        {
            // Arrange
            var unitUnderTest = new Starship() { MegalightYearsPerHour = 100, NoOfDaysBetweenPitStops = 10 };
            long distance = 48001;

            // Act
            var result = unitUnderTest.NecesaryNumberOfStops(
                distance);

            // Assert
            Assert.AreEqual(2, result);
        }
        [Test]
        public void NecesaryNumberOfStops_1JumpNeededRightBelow_Returns()
        {
            // Arrange
            var unitUnderTest = new Starship() { MegalightYearsPerHour = 100, NoOfDaysBetweenPitStops = 10 };
            long distance = 48000;

            // Act
            var result = unitUnderTest.NecesaryNumberOfStops(
                distance);

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}
