
using StarWarsPitStopCalculator.Services.SWStarshipRepository;
using System;

namespace StartWarsPitStopCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var starshipRepo = new SWStarshipRepository();
            var starshipList = starshipRepo.GetStarships("https://swapi.co/api/starships").GetAwaiter().GetResult() ;
            Console.Write(starshipRepo);
            Console.WriteLine("Hello World!");
        }
    }
}
