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
    public class MotorcycleModel : VehicleModel
    {
        // class level Properties.
        public bool HasSideCar { get; set; }
        public decimal SeatHeight { get; set; } // In inches

        /// <summary>
        /// Default constructor for the motorcycle model
        /// </summary>
        public MotorcycleModel() : base()
        {
            HasSideCar = false;
            SeatHeight = 0m;
        }

        /// <summary>
        /// Parameterized constructor for motorcycle model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="numWheels"></param>
        /// <param name="hasSideCar"></param>
        /// <param name="seatHeight"></param>
        public MotorcycleModel(int id, string make, string model, int year, decimal price, int numWheels, bool hasSideCar, decimal seatHeight)
            : base(id, make, model, year, price, numWheels)
        {
            HasSideCar = hasSideCar;
            SeatHeight = seatHeight;
        }

        public override string ToString()
        {
            // Use a ternary operator (in-line-if) to get the sidecar string
            //                condition ? if true : if false
            string sideCar = HasSideCar ?  "with" : "without";

            // Print the motorcycle in the following format
            // 1: 2015 Yamaha Bolt with 2 wheels and a 44.1 inch seat with(out) a side car - $8000.00
            return $"{Id}: {Year} {Make} {Model} with {NumWheels} wheels and a {SeatHeight} inch seat {sideCar} a side car - {Price:C2}";
        }
    }
}
