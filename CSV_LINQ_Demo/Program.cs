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

            if (cars.Any())
            {
                Console.WriteLine("There are cars in the collection");
            }
            if (cars.Any(c => c.Division == "Ford"))
            {
                Console.WriteLine("Collection has cars manufactured by Ford");
            };

            // With secondary ordering
            // Project to anonymous type so we only create the properties that are needed
            var query = cars.Distinct()
                    .OrderByDescending(c => c.CombinedFuelEfficiency)
                    .ThenBy(c => c.Division)
                    .Select(c => new
                    {
                        c.Division,
                        c.Model,
                        c.CombinedFuelEfficiency
                    });

            Console.WriteLine("50 most fuel efficient cars in collection:");
            foreach(var car in query.Take(50))
            {
                Console.WriteLine($"{car.Division} {car.Model} : {car.CombinedFuelEfficiency}");
            }
        }

        private static List<Car> ProcessFile(string path)
        {
            var result = File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .ToCar();   // Dedicated projection instead of a select
//                .Select(line => Car.TransformFromString(line));

            return result.ToList<Car>();
        }
    }

    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach(var line in source)
            {
                var columns = line.Split(';');
                yield return new Car
                {
                    ModelYear = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Division = columns[2],
                    Model = columns[3],
                    Displacement = double.Parse(columns[4]),
                    Cylinders = int.Parse(columns[5]),
                    CombinedFuelEfficiency = int.Parse(columns[8])
                };
            }
        }
    }
}
 