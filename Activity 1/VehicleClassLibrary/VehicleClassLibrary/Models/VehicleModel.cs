/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Vehicle Class Library
 * Activity 1
 * References:
 */

namespace VehicleClassLibrary.Models
{
    public class VehicleModel
    {
        // class level properties
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int NumWheels { get; set; }
        public decimal EngineSize { get; set; } // In liters

        /// <summary>
        /// Default constructor for a vehicle model
        /// </summary>
        public VehicleModel()
        {
            Id = 0;
            Make = "Unknown";
            Model = "Unknown";
            Color = "Unknown";
            Year = 0;
            Price = 0m;
            NumWheels = 0;
            EngineSize = 0m;
        }

        /// <summary>
        /// Parameterized constructor for vehicle model class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="numWheels"></param>
        /// <param name="engineSize"></param>
        public VehicleModel(int id, string make, string model, string color, int year, decimal price, int numWheels, decimal engineSize)
        {
            Id = id;
            Make = make;
            Model = model;
            Color = color;
            Year = year;
            Price = price;
            NumWheels = numWheels;
            EngineSize = engineSize;
        }

        public override string ToString()
        {
            return $"{Id}: {Color} {Year} {Make} {Model} with {NumWheels} wheels and a {EngineSize:F1}ltr engine - {Price:C2}";
        }
    }
}
