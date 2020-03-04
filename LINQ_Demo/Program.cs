using System;
using System.IO;
using System.Linq;

namespace LINQ_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileQueryDemo = new FileQueryDemo();
            fileQueryDemo.ListFiveLargestFiles(@"./");

            var lambdaDemo = new LambdaDemo();
            lambdaDemo.FilterCollection();

            lambdaDemo.UseCustomFilter();

            lambdaDemo.GetNRandomDoubles(10);
        }
    }

}
