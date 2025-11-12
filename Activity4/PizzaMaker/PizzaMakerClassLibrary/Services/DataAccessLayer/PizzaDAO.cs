/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Pizza Maker
 * Activity 4
 * References:
 */

namespace PizzaMakerClassLibrary.Services.DataAccessLayer
{
    public class PizzaDAO
    {
        // Class level variables
        private List<PizzaModel> _pizzaOrder;

        /// <summary>
        /// Default constructor for the pizza DAO
        /// </summary>
        public PizzaDAO() 
        {
            // Initialize the _pizzaOrder List
            _pizzaOrder = new List<PizzaModel> ();
        }
    }
}
