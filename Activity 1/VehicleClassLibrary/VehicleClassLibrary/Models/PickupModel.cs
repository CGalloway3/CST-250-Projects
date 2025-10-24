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
    public class PickupModel : VehicleModel
    {
        // class level Properties.
        public bool HasBedCover { get; set; }
        public decimal BedSize { get; set; } // In cubit feet
        
        /// <summary>
        /// Default constructor for the pickup model
        /// </summary>
        public PickupModel() : base()
        {
            HasBedCover = false;
            BedSize = 0m;
        }
        
        /// <summary>
        /// Parameterized constructor for pickup model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="numWheels"></param>
        /// <param name="hasBedCover"></param>
        /// <param name="bedSize"></param>
        public PickupModel(int id, string make, string model, int year, decimal price, int numWheels, bool hasBedCover, decimal bedSize)
            : base(id, make, model, year, price, numWheels)
        {
            HasBedCover = hasBedCover;
            BedSize = bedSize;
        }

        public override string ToString()
        {
            // Use a ternary operator (in-line-if) to get the bed cover string
            //                  condition ? if true : if false
            string bedCover = HasBedCover ?  "with" : "without";

            // Print the pickup in the following format
            // 1: 2001 Toyota Tundra with 4 wheels and a 8.3 cubic foot bed with(out) a bed cover - $5000.00
            return $"{Id}: {Year} {Make} {Model} with {NumWheels} wheels and a {BedSize} cubic foot bed {bedCover} a bed cover - {Price:C2}";
        }
    }
}
