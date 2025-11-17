/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Pizza Maker
 * Activity 4
 * References:
 */

using PizzaMakerClassLibrary.Models;
using PizzaMakerClassLibrary.Services.DataAccessLayer;

namespace PizzaMakerClassLibrary.Services.BusinessLogicLayer
{
    public class PizzaLogic
    {
        // Declare class level variables
        private PizzaDAO _pizzaDAO;
        
        // Public Constructor
        /// <summary>
        /// Default constructor for PizzaLogic
        /// </summary>
        public PizzaLogic()
        { 
            // Initialize the pizza DAO object
            _pizzaDAO = new PizzaDAO();
        }

        // Public Methods
        /// <summary>
        /// Add a new pizza to the current order
        /// </summary>
        /// <param name="newPizza"></param>
        /// <returns></returns>
        public (bool isValidPizza, int pizzasInOrder) AddPizzaToOrder(PizzaModel newPizza)
        {
            // Declare and initialize
            int pizzas = -1;
            bool isValidPizza = false;

            // Rules that need to be satisfied for a pizza to be added to the order
            // If the pizza passed in here does not meet all these rules it is not a
            // valid pizza entry. If it is valid set isValidPizza to true and call AddPizzaToOrder
            if (newPizza != null &&
                !string.IsNullOrWhiteSpace(newPizza.ClientName) &&
                newPizza.ClientName != "Unknown" &&
                newPizza.Crust != "Unknown" &&
                (newPizza.Ingredients.Count > 0 || newPizza.StrangeAddOns.Count > 0 ) &&
                newPizza.SauceQty > 0 &&
                newPizza.CheeseQty > 0)
            {
                // Call the DAO AddPizzaToOrder
                pizzas = _pizzaDAO.AddPizzaToOrder(newPizza);
                isValidPizza = true;
            }

            // Return the pizzas variable
            return (isValidPizza, pizzas);
        }

        /// <summary>
        /// Get the list of pizzas in the current order
        /// </summary>
        /// <returns></returns>
        public List<PizzaModel> GetPizzaOrder()
        {
            // Get and return the getPizzaOrder from the DAO
            return _pizzaDAO.GetPizzaOrder();
        }

        /// <summary>
        /// Write the pizza order to a text file
        /// </summary>
        /// <returns></returns>
        public bool WriteOrderToFile()
        {
            // Get and return write order to file from the DAO
            return _pizzaDAO.WriteOrderToFile();
        }

        /// <summary>
        /// Get the order price
        /// </summary>
        /// <returns></returns>
        public decimal GetOrderPrice()
        {
            return _pizzaDAO.GetOrderPrice();
        }

        /// <summary>
        /// Checkout logic for orders
        /// </summary>
        /// <returns></returns>
        public bool Checkout()
        {
            return _pizzaDAO.Checkout();
        }
    }
}
