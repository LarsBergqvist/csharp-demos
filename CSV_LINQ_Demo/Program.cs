using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSV_LINQ_Demo;

internal static partial class Program
{
    static void Main()
    {
        var cars = ProcessFile("car-data.csv");

        if (cars.Any())
        {
            Console.WriteLine("There are cars in the collection");
        }
        if (cars.Any(c => c.Division == "Ford"))
        {
            Console.WriteLine("Collection has cars manufactured by Ford");
        }

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
        Console.WriteLine();
        Console.WriteLine("50 most fuel efficient cars in collection:");
        foreach(var car in query.Take(50))
        {
            Console.WriteLine($"{car.Division} {car.Model} : {car.CombinedFuelEfficiency}");
        }

        Console.WriteLine("Manufacturer information:");
        //            var groupQuery = from car in cars
        //                             group car by car.Manufacturer into manufacturer
        //                             orderby manufacturer.Key
        //                             select manufacturer;
        var groupQuery = cars.GroupBy(c => c.Manufacturer)
            .OrderBy(g => g.Key);
        Console.WriteLine();
        foreach (var result in groupQuery)
        {
            Console.WriteLine($"{result.Key} has {result.Count()} models");
        }

        // Custom aggregation with method syntax
        var statQuery = cars.GroupBy(c => c.Manufacturer)
            .Select(g =>
            {
                var result = g.Aggregate(new CarStat(),
                    (acc, c) => acc.Accumulate(c),  // for each car
                    acc => acc.Compute());          // final calculation of statistics
                return new
                {
                    Name = g.Key,
                    Avg = result.Average,
                    result.Min,
                    result.Max
                };
            })
            .OrderBy(o => o.Max);
        Console.WriteLine();
        Console.WriteLine("Fuel efficiency stats per manufacturer:");
        foreach (var result in statQuery.OrderBy(m => m.Name))
        {
            Console.WriteLine($"{result.Name}");
            Console.WriteLine($"\tMax: {result.Max}");
            Console.WriteLine($"\tMin: {result.Min}");
            Console.WriteLine($"\tAverage: {result.Avg}");
        }
    }

    private static List<Car> ProcessFile(string path)
    {
        var result = File.ReadAllLines(path)
            .Skip(1)
            .Where(line => line.Length > 1)
            .ToCar();   // Dedicated projection instead of a select
//                .Select(line => Car.TransformFromString(line));

        return result.ToList();
    }
}