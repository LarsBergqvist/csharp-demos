using System.Linq;
namespace LINQ_Demo
{
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
            ConsoleEx.WriteCollection<string>(filteredCollectionWithDelegate);

            // With lambda expression
            var filteredCollectionWithLambda = myCollection.Where(s => s.StartsWith("b"));
            ConsoleEx.WriteCollection<string>(filteredCollectionWithLambda);
        }

    }
}
