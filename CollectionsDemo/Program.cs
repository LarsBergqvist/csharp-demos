using System;
using System.Collections.Generic;

namespace CollectionsDemeo
{
    class Program
    {
        static void Main(string[] args)
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
            var enumerator = items.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
