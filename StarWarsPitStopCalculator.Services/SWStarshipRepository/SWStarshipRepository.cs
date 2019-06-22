using Newtonsoft.Json;
using StarWarsPitStopCalculator.Services.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StarWarsPitStopCalculator.Services.SWStarshipRepository
{
    public class SWStarshipRepository
    {
        public SWStarshipRepository()
        {

        }
        public async Task<StarshipListJsonModel> GetStarships(string url)
        {
         
            using (var client = new HttpClient())
            {              
                var response = await client.GetAsync(new Uri(url));
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                return JsonConvert.DeserializeObject<StarshipListJsonModel>(json);
            }
        }

       internal int? ParseConsumablesDuration (string consumables)
        {            
            if (CheckIntervalType(consumables, "y") )
            {
                return ExtractNumberFromBeginingOfString(consumables) * 365;
            }
            if (CheckIntervalType(consumables, "m"))
            {
                return ExtractNumberFromBeginingOfString(consumables) * 30;
            }
            if (CheckIntervalType(consumables, "w"))
            {
                return ExtractNumberFromBeginingOfString(consumables) * 7;
            }
            if (CheckIntervalType(consumables, "d"))
            {
                return ExtractNumberFromBeginingOfString(consumables) ;
            }           
            return null;
        }

        private static int? ExtractNumberFromBeginingOfString(string consumables)
        {
            var regex = Regex.Match(consumables, @"[0-9]+");
            if(regex.Success)
                return int.Parse(regex.Value);
            return null;
        }

        private static bool CheckIntervalType(string consumables,string intervalType)
        {
            return Regex.Match(consumables,$"[0-9]+ {intervalType}[a-z]+").Success;
        }
        

        public  async  Task<IEnumerable<Starship>> GetAllStarships()
        {
            var starshipList = new List<Starship>();
            var initialResultSet = await GetStarships("https://swapi.co/api/starships");
            var listOfShips = new List<Starship>();
            //convert json models to usable data
            listOfShips.AddRange ( GetShipListFromResponseJson(initialResultSet ));
            while (initialResultSet != null && !string.IsNullOrWhiteSpace(initialResultSet.Next))
            {
                initialResultSet = await GetStarships(initialResultSet.Next);
                foreach (var item in initialResultSet.Starships)
                {
                    listOfShips.Add(new Starship()
                    {
                        Name = item.Name,
                        Model = item.Model,
                        NoOfDaysBetweenPitStops = ParseConsumablesDuration(item.Consumables),
                        MegalightYearsPerHour = ExtractNumberFromBeginingOfString(item.MGLT)
                    });
                }
            }
            return listOfShips;
        }

        private List<Starship> GetShipListFromResponseJson(StarshipListJsonModel initialResultSet )
        {
            var listOfShips = new List<Starship>();
            foreach (var item in initialResultSet.Starships)
            {
                listOfShips.Add(new Starship()
                {
                    Name = item.Name,
                    Model = item.Model,
                    NoOfDaysBetweenPitStops = ParseConsumablesDuration(item.Consumables),
                    MegalightYearsPerHour = ExtractNumberFromBeginingOfString(item.MGLT)
                });
            }
            return listOfShips;

        }
    }
}
