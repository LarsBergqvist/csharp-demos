using System;
using System.Collections.Generic;

namespace LINQ_Demo;

public static class MyExtensions
{
    public static IEnumerable<T> MyFilter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                // deferred execution with yield return
                yield return item;
            }
        }
    }
}