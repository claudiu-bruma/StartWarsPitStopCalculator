using Moq;
using NUnit.Framework;
using StarWarsPitStopCalculator.Services.StarshipRepository;
using System;
using System.Threading.Tasks;

namespace StarWarsPitStopCalculator.Tests.StarshipRepository
{
    [TestFixture]
    public class StarshipRepositoryTests
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

        //private StarshipRepository CreateStarshipRepository()
        //{
        //    return new StarshipRepository();
        //}

        //[Test]
        //public async Task GetStarships_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var unitUnderTest = this.CreateStarshipRepository();
        //    string url = TODO;

        //    // Act
        //    var result = await unitUnderTest.GetStarships(
        //        url);

        //    // Assert
        //    Assert.Fail();
        //}

        //[Test]
        //public async Task GetAllStarships_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var unitUnderTest = this.CreateStarshipRepository();

        //    // Act
        //    var result = await unitUnderTest.GetAllStarships();

        //    // Assert
        //    Assert.Fail();
        //}
    }
}
