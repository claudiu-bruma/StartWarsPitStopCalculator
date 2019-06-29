using Newtonsoft.Json;
using StarWarsPitStopCalculator.Services.Models;
using StarWarsPitStopCalculator.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StarWarsPitStopCalculator.Services.StarshipRepository
{
    public class SWStarshipRepository : IStarshipRepository
    {
        public SWStarshipRepository()
        {


        }
        private async Task<StarshipListJsonModel> GetStarships(string url)
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




        public async Task<IEnumerable<StarshipJsonModel>> DownloadStarshipList()
        {
            var initialResultSet = await GetStarships(RepoConstants.SwApiStarshipUrl);
            List<StarshipJsonModel> starshipList = new List<StarshipJsonModel>();
            starshipList.AddRange( initialResultSet.Starships);     
            
            while (initialResultSet != null && !string.IsNullOrWhiteSpace(initialResultSet.Next))
            {
                initialResultSet = await GetStarships(initialResultSet.Next);
                starshipList.AddRange(initialResultSet.Starships);                
            }
            return starshipList  ;
        }


             
    }
}
