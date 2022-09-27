using System;
using System.Collections.Generic;

namespace CollectionsDemo;

internal static class Program
{
    private static void Main()
    {
        IEnumerable<string> items = new List<string>()
        {
            "monkey",
            "ball",
            "bike"
        };


        foreach(var item in items)
        {
            Console.WriteLine(item);
        }

        // Manually use enumerator of collection
        using var enumerator = items.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }
    }
}