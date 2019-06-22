
using StarWarsPitStopCalculator.Services.SWStarshipRepository;
using System;
using System.Threading.Tasks;

namespace StartWarsPitStopCalculator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var starshipRepo = new SWStarshipRepository();
            var starshipList = await starshipRepo.GetAllStarships();
            foreach(var ship in starshipList)
            {
                Console.WriteLine($"{ship.Name} : {ship.NecesaryNumberOfStops(100000)}");
            }
        
        }
    }
}
