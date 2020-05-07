using System;

namespace DeconstructionDemo
{
    public static class MyExtensions
    {
        public static void Deconstruct(this DateTime dateTime, out int year, out int month, out int day)
            => (year, month, day) = (dateTime.Year, dateTime.Month, dateTime.Day);

        public static void Deconstruct(this DateTime dateTime, out int year, out int month, out int day,
            out int hour, out int minute)
            => (year, month, day, hour, minute) = (dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute);
    }

    class Program
    {
        static (int x, int y) MyMethod() => (3, 4);

        class MyPoint
        {
            public double X { get; set; }
            public double Y { get; set; }
            public MyPoint(double x, double y) => (X, Y) = (x, y);
            public void Deconstruct(out double x, out double y) => (x, y) = (X, Y);
        }

        static void Main(string[] args)
        {
            var myTuple = (42, "hello");

            // Implicit deconstruction
            var (a, b) = myTuple;
            Console.WriteLine($"a: {a}, b: {b}");

            // Explicit deconstruction
            (int c, string d) = myTuple;
            Console.WriteLine($"c: {c}, d: {d}");

            // Deconstruction to existing variables, i.e. assignment and not declaration
            int e;
            string f;
            (e, f) = myTuple;
            Console.WriteLine($"e: {e}, f: {f}");

            // Deconstruction from method returning tuple
            // with implicitely typed variable
            (int g, var h) = MyMethod();
            Console.WriteLine($"g: {g}, h: {h}");

            // Deconstruction from method returning tuple
            // with discards
            (int i, _) = MyMethod();
            Console.WriteLine($"i: {i}");

            // Instance deconstruction method
            var p = new MyPoint(11, 13);
            (var x, var y) = p;
            Console.WriteLine($"x: {x}, y: {y}");

            // Deconstruction with extension method
            // and overloading
            DateTime now = DateTime.UtcNow;
            var (year, month, day) = now;
            Console.WriteLine($"year: {year}, month: {month}, day: {day}");
            var (year2, month2, day2, hour, minute) = now;
            Console.WriteLine($"year: {year2}, month: {month2}, day: {day2}, hour: {hour}, minute: {minute}");
        }
    }
}
