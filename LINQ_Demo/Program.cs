namespace LINQ_Demo;

static class Program
{
    static void Main()
    {
        var fileQueryDemo = new FileQueryDemo();
        fileQueryDemo.ListFiveLargestFiles(@"./");

        var lambdaDemo = new LambdaDemo();
        lambdaDemo.FilterCollection();

        lambdaDemo.UseCustomFilter();

        lambdaDemo.GetNRandomDoubles(10);
    }
}