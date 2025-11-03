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
    public class CarModel : VehicleModel
    {
        // class level Properties.
        public bool IsConvertible { get; set; }
        public decimal TrunkSize { get; set; } // In cubic feet

        /// <summary>
        /// Default constructor for the car model
        /// </summary>summary>
        public CarModel() : base()
        {
            IsConvertible = false;
            TrunkSize = 0m;
        }

        /// <summary>
        /// Parameterized constructor for car model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="color"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="numWheels"></param>
        /// <param name="engineSize"></param>
        /// <param name="isConvertible"></param>
        /// <param name="trunkSize"></param>
        public CarModel(int id, string make, string model, string color, int year, decimal price, int numWheels, decimal engineSize, bool isConvertible, decimal trunkSize)
            : base(id, make, model, color, year, price, numWheels, engineSize)
        {
            IsConvertible = isConvertible;
            TrunkSize = trunkSize;
        }

        /// <summary>
        /// ToString method for printing a car
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Use a ternary operator (in-line-if) to get the convertible string
            //                       condition ? if true : if false
            string convertible = IsConvertible ?  "with" : "without";

            // Print the car in the following format
            // 1: 2019 Jeep Wrangler with 4 wheels and a 14.7 cubic foot trunk with(out) a convertible top = $27000.00
            return $"{Id}: {Color} {Year} {Make} {Model} with {NumWheels} wheels, a {EngineSize:F1}ltr engine, and a {TrunkSize} cubic foot trunk {convertible} a convertible top - {Price:C2}";
        }
    }
}
