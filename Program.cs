using System;

namespace Traveling_Salesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCities = 1000000;
            Simulator sim = new Simulator(numberCities);
            var cities = sim.BuildCities();
            sim.PrintCityNeighbours(cities);

            Random rnd = new Random();
            int startCity = rnd.Next(numberCities);
            int targetCity = rnd.Next(numberCities);

            while (targetCity == startCity)
            {
                targetCity = rnd.Next(numberCities);
            }

            Console.WriteLine("");
            Console.WriteLine("start and target: " + startCity + " " + targetCity);
            Console.WriteLine("");

            sim.FindPath(startCity, targetCity, cities);
        
        }
    }
}
