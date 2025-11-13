/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Pizza Maker
 * Activity 4
 * References:
 */

using System.Drawing;

namespace PizzaMakerClassLibrary.Models
{
    public class PizzaModel
    {
        // Class properties
        public string ClientName { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> StrangeAddOns { get; set; }
        public string Crust { get; set; }
        public int SauceQty { get; set; }
        public int CheeseQty { get; set; }
        public DateTime DeliveryTime { get; set; }
        public Color PizzaBoxColor { get; set; }
        public decimal Price { get; set; }

        // Public Constructor
        /// <summary>
        /// Default Constructor for Pizza Model
        /// </summary>
        public PizzaModel()
        {
            // Declare the default properties
            ClientName = "Unknown";
            Ingredients = new List<string>();
            StrangeAddOns = new List<string>();
            Crust = "Unknown";
            SauceQty = 0;
            CheeseQty = 0;
            DeliveryTime = DateTime.Now;
            PizzaBoxColor = Color.White;
            Price = 15m;
        }
    }
}
