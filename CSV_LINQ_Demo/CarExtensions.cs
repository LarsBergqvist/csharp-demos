﻿using System.Collections.Generic;
using System.Linq;

namespace CSV_LINQ_Demo;

public static class CarExtensions
{
    public static IEnumerable<Car> ToCar(this IEnumerable<string> source)
    {
        return source.Select(line => line.Split(';')).Select(columns => new Car
        {
            ModelYear = int.Parse(columns[0]),
            Manufacturer = columns[1],
            Division = columns[2],
            Model = columns[3],
            Displacement = double.Parse(columns[4]),
            Cylinders = int.Parse(columns[5]),
            CombinedFuelEfficiency = int.Parse(columns[8])
        });
    }
}