using System;
namespace CSV_LINQ_Demo
{
    public struct Car
    {
        public string Manufacturer { get; set; }
        public int ModelYear { get; set; }
        public string Division { get; set; }
        public string Model { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int CombinedFuelEfficiency { get; set; }
        internal static Car TransformFromString(string line, int arg2)
        {
            var columns = line.Split(';');
            return new Car
            {
                ModelYear = int.Parse(columns[0]),
                Manufacturer = columns[1],
                Division = columns[2],
                Model = columns[3],
                Displacement = double.Parse(columns[4]),
                Cylinders =  int.Parse(columns[5]),
                CombinedFuelEfficiency = int.Parse(columns[8])
            };
        }
    }
}
