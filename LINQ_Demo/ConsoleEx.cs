using System;
using System.Collections.Generic;

namespace LINQ_Demo
{
    public static class ConsoleEx
    {
        public static void WriteCollection<T>(IEnumerable<T> collection)
        {
            foreach(var item in collection)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
