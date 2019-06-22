using Newtonsoft.Json;
using StarWarsPitStopCalculator.Services.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

       

        public async  IEnumerable<Starship> GetAllStarships()
        {
            var starshipList = new List<Starship>();
            var initialResultSet =  await GetStarships("https://swapi.co/api/starships");
            //convert json models to usable data
            while(initialResultSet != null && !string.IsNullOrWhiteSpace(initialResultSet.Next))
            {
               var resultSet = 
            }
           

             return new Starship();
        }
    }
}
