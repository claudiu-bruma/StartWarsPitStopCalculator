using StarWarsPitStopCalculator.Services.Models;
using StarWarsPitStopCalculator.Services.StarshipRepository;
using StarWarsPitStopCalculator.Services.Utilities;
using StarWarsPitStopCalculator.Services.Utilities.StringParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPitStopCalculator.Services.StarshipService
{
    public class SWStarshipService : IStarshipService
    {
        private IStarshipRepository StarshipRepository { get; set; }
        private IStringParser StringParser { get; set; }

        public SWStarshipService(IStarshipRepository repo,IStringParser stringParser)
        {
            StarshipRepository = repo;
            StringParser = stringParser;
        }

        public async Task<IEnumerable<Starship>> GetAllStarships()
        {
            var starshipsFromService = await StarshipRepository.DownloadStarshipList();
            return ExtractStarshipData(starshipsFromService);
        }
        private IEnumerable<Starship> ExtractStarshipData(IEnumerable<StarshipJsonModel> unporcessedShipList)
        {
            return unporcessedShipList.Select(item => new Starship()
            {
                Name = item.Name,
                Model = item.Model,
                NoOfDaysBetweenPitStops = StringParser.ParseConsumablesDuration(item.Consumables),
                MegalightYearsPerHour = StringParser.ExtractNumberFromBeginingOfString(item.MGLT)
            });

        }
        public async Task<IEnumerable<Starship>> GetShipsWithValidDetails()
        {
            var starshipsFromService = await GetAllStarships();
            return starshipsFromService.Where(x=>x.NoOfDaysBetweenPitStops.HasValue && x.MegalightYearsPerHour.HasValue);
        }
    }

}
