using System;
using System.Collections.Generic;

namespace LINQ_Demo;

public static class RandomCollection
{
    public static IEnumerable<double> Random()
    {
        var random = new Random();
        while (true)
        {
            yield return random.NextDouble();
        }
    }
}