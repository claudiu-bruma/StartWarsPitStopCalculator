using Moq;
using NUnit.Framework;
using StarWarsPitStopCalculator.Services.StarshipRepository;
using StarWarsPitStopCalculator.Services.StarshipService;
using StarWarsPitStopCalculator.Services.Utilities.StringParsers;
using System.Threading.Tasks;
using StarWarsPitStopCalculator.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace StarWarsPitStopCalculator.Tests.StarshipService
{
    [TestFixture]
    public class SWStarshipServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IStarshipRepository> mockStarshipRepository;
        private Mock<IStringParser> mockStringParser;


        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockStarshipRepository = this.mockRepository.Create<IStarshipRepository>();
            this.mockStringParser = this.mockRepository.Create<IStringParser>();




        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }

        private SWStarshipService CreateService()
        {
            return new SWStarshipService(
                this.mockStarshipRepository.Object,
               new StringParser());
        }

        [Test]
        public async Task GetAllStarships_ListReceived_ReturnsAllElements()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            var listOfShips = SetupShipList();
            this.mockStarshipRepository.Setup(x => x.DownloadStarshipList()).ReturnsAsync(listOfShips);
            // Act
            var result = await unitUnderTest.GetAllStarships();

            // Assert
            Assert.AreEqual(listOfShips.Count(), result.Count());

        }
        [Test]
        public async Task GetAllStarships_ListReceived_ElementsWithUnknownPresent()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            var listOfShips = SetupShipList();
            this.mockStarshipRepository.Setup(x => x.DownloadStarshipList()).ReturnsAsync(listOfShips);
            // Act
            var result = await unitUnderTest.GetAllStarships();

            // Assert
            Assert.AreEqual(listOfShips.Count(x => x.MGLT == "unknown"),
                result.Count(x => !x.MegalightYearsPerHour.HasValue));
            Assert.AreEqual(listOfShips.Count(x => x.Consumables == "unknown"),
                result.Count(x => !x.NoOfDaysBetweenPitStops.HasValue));

        }
        [Test]
        public async Task GetAllStarships_ListReceived_RecordsWithUnknownAreReturned()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            var listOfShips = SetupShipList();
            this.mockStarshipRepository.Setup(x => x.DownloadStarshipList()).ReturnsAsync(listOfShips);
            // Act
            var result = await unitUnderTest.GetAllStarships();

            // Assert
            Assert.IsTrue(result.Any(x => !x.NoOfDaysBetweenPitStops.HasValue || !x.MegalightYearsPerHour.HasValue));
            Assert.AreEqual(result.Count(x => !x.NoOfDaysBetweenPitStops.HasValue || !x.MegalightYearsPerHour.HasValue),3);
        }
        private static List<StarshipJsonModel> SetupShipList()
        {
            var shipList = new List<StarshipJsonModel>();
            shipList.Add(new StarshipJsonModel()
            {
                Consumables = "1 year",
                MGLT = "1",
                Model = "M1",
                Name = "N1"
            });
            shipList.Add(new StarshipJsonModel()
            {
                Consumables = "1 month",
                MGLT = "1",
                Model = "M2",
                Name = "N2"
            });
            shipList.Add(new StarshipJsonModel()
            {
                Consumables = "1 week",
                MGLT = "1",
                Model = "M3",
                Name = "N3"
            });
            shipList.Add(new StarshipJsonModel()
            {
                Consumables = "1 day",
                MGLT = "1",
                Model = "M4",
                Name = "N4"
            });
            shipList.Add(new StarshipJsonModel()
            {
                Consumables = "unknown",
                MGLT = "unknown",
                Model = "MU1",
                Name = "MU1"
            });
            shipList.Add(new StarshipJsonModel()
            {
                Consumables = "1 month",
                MGLT = "unknown",
                Model = "MU1",
                Name = "MU1"
            });
            shipList.Add(new StarshipJsonModel()
            {
                Consumables = "unknown",
                MGLT = "1",
                Model = "MU2",
                Name = "MU2"
            });

            return shipList;
        }


        [Test]
        public async Task GetShipsWithValidDetails_ListReceived_CorrectNumberOfItemsReturned()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            var listOfShips = SetupShipList();
            this.mockStarshipRepository.Setup(x => x.DownloadStarshipList()).ReturnsAsync(listOfShips);
            // Act
            var result = await unitUnderTest.GetShipsWithValidDetails();

            // Assert
            Assert.AreEqual(listOfShips.Count(x => x.Consumables != "unknown" && x.MGLT != "unknown"), result.Count());
        }
        [Test]
        public async Task GetShipsWithValidDetails_ListReceived_RecordsWithUnknownNotReturned()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            var listOfShips = SetupShipList();
            this.mockStarshipRepository.Setup(x => x.DownloadStarshipList()).ReturnsAsync(listOfShips);
            // Act
            var result = await unitUnderTest.GetShipsWithValidDetails();

            // Assert
            Assert.IsTrue(result.All(x => x.NoOfDaysBetweenPitStops.HasValue && x.MegalightYearsPerHour.HasValue));
        }
    }
}

