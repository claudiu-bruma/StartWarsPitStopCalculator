using Moq;
using NUnit.Framework;
using StarWarsPitStopCalculator.Services.Utilities;
using StarWarsPitStopCalculator.Services.Utilities.StringParsers;
using System;

namespace StarWarsPitStopCalculator.Tests.Utilities
{
    [TestFixture]
    public class StringParsersTests
    {
        private MockRepository mockRepository;

        private StringParser stringParser;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.stringParser = new StringParser();

        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }

     

        [Test]
        public void ParseConsumablesDuration_FoundYears_CorrectNoOfDays()
        {
            // Arrange
         
            string consumables = "100 years";

            // Act
            var result = this.stringParser.ParseConsumablesDuration(
                consumables);

            // Assert
            Assert.AreEqual(result.Value, 100 * 365);
        }
        [Test]
        public void ParseConsumablesDuration_Found1Year_CorrectNoOfDays()
        {
            // Arrange
         
            string consumables = "1 years";

            // Act
            var result = this.stringParser.ParseConsumablesDuration(
                consumables);

            // Assert
            Assert.AreEqual(result.Value,   365);
        }
        [Test]
        public void ParseConsumablesDuration_FoundMonths_CorrectNoOfDays()
        {
            // Arrange
             
            string consumables = "100 month";

            // Act
            var result = this.stringParser.ParseConsumablesDuration(
                consumables);

            // Assert
            Assert.AreEqual(result.Value, 100 * 30);
        }
        [Test]
        public void ParseConsumablesDuration_Found1Month_CorrectNoOfDays()
        {
            // Arrange
             
            string consumables = "1 month";

            // Act
            var result = this.stringParser.ParseConsumablesDuration(
                consumables);

            // Assert
            Assert.AreEqual(result.Value,   30);
        }
        [Test]
        public void ParseConsumablesDuration_FoundWeeks_CorrectNoOfDays()
        {
            // Arrange
             
            string consumables = "100 weeks";

            // Act
            var result = this.stringParser.ParseConsumablesDuration(
                consumables);

            // Assert
            Assert.AreEqual(result.Value, 100 * 7);
        }
        [Test]
        public void ParseConsumablesDuration_Found1Week_CorrectNoOfDays()
        {
            // Arrange
            
            string consumables = "1 week";

            // Act
            var result = this.stringParser.ParseConsumablesDuration(
                consumables);

            // Assert
            Assert.AreEqual(result.Value,   7);
        }
        [Test]
        public void ParseConsumablesDuration_FoundDays_CorrectNoOfDays()
        {
            // Arrange
            
            string consumables = "100 days";

            // Act
            var result = this.stringParser.ParseConsumablesDuration(
                consumables);

            // Assert
            Assert.AreEqual(result.Value, 100 );
        }
        [Test]
        public void ParseConsumablesDuration_1day_CorrectNoOfDays()
        {
            // Arrange
            
            string consumables = "1 day";

            // Act
            var result = this.stringParser.ParseConsumablesDuration(
                consumables);

            // Assert
            Assert.AreEqual(result.Value, 1);
        }
        [Test]
        public void ParseConsumablesDuration_FoundEmpty_NullReturned()
        {
            // Arrange
            
            string consumables = "";

            // Act
            var result = this.stringParser.ParseConsumablesDuration(
                consumables);

            // Assert
            Assert.IsFalse (result.HasValue );
        }
        [Test]
        public void ParseConsumablesDuration_FoundUnknown_NullReturned()
        {
            // Arrange
            
            string consumables = "Unknown";

            // Act
            var result = this.stringParser.ParseConsumablesDuration(
                consumables);

            // Assert
            Assert.IsFalse(result.HasValue);
        }
 
    }
}
