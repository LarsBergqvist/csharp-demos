using System.Linq;
namespace LINQ_Demo;

public class LambdaDemo
{
    public void FilterCollection()
    {
        var myCollection = new System.Collections.Generic.List<string>()
        {
            "monkey",
            "ball",
            "bike"
        };

        // With explicit delegate syntax
        var filteredCollectionWithDelegate = myCollection.Where(
            delegate (string s) { return s.StartsWith("b"); });
        System.Console.WriteLine("Filter using explicit delegate syntax");
        ConsoleEx.WriteCollection(filteredCollectionWithDelegate);

        // With lambda expression
        var filteredCollectionWithLambda = myCollection.Where(s => s.StartsWith("b"));
        System.Console.WriteLine("Filter using lambda expression");
        ConsoleEx.WriteCollection(filteredCollectionWithLambda);
    }

    public void UseCustomFilter()
    {
        var myCollection = new System.Collections.Generic.List<string>()
        {
            "monkey",
            "ball",
            "bike"
        };

        // With lambda expression
        var result = myCollection.MyFilter(s => s.StartsWith("b"));
        System.Console.WriteLine("Filter using custom extension method and lambda expression");
        ConsoleEx.WriteCollection(result);
    }

    public void GetNRandomDoubles(int n)
    {
        var collection = RandomCollection.Random().Take(n);
        System.Console.WriteLine($"Get {n} items from an infinite collection");
        ConsoleEx.WriteCollection(collection);
    }
}