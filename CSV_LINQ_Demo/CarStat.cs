using System;

namespace CSV_LINQ_Demo;

partial class Program
{
    public class CarStat
    {
        public int Max { get; set; }
        public int Min { get; set; }
        public double Average { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }

        public CarStat()
        {
            Max = int.MinValue;
            Min = int.MaxValue;
        }

        public CarStat Accumulate(Car c)
        {
            Count += 1;
            Total += c.CombinedFuelEfficiency;
            Max = Math.Max(Max, c.CombinedFuelEfficiency);
            Min = Math.Min(Min, c.CombinedFuelEfficiency);
            return this;
        }

        public CarStat Compute()
        {
            if (Count > 0)
                Average = (double)Total / Count;
            return this;
        }
    }
}