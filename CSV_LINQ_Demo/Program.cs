using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSV_LINQ_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("car-data.csv");

            var query = cars.OrderByDescending(c => c.CombinedFuelEfficiency);

            foreach(var car in query.Take(50))
            {
                Console.WriteLine(car.Division + " " + car.Model + " " + car.CombinedFuelEfficiency);
            }

        }

        private static List<Car> ProcessFile(string path)
        {
            var result = File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Car.TransformFromString);

            return result.ToList<Car>();
        }
    }
}
 