/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Pizza Maker
 * Activity 4
 * References:
 */

using PizzaMakerClassLibrary.Models;

namespace PizzaMakerClassLibrary.Services.DataAccessLayer
{
    public class PizzaDAO
    {
        // Class level variables
        private List<PizzaModel> _pizzaOrder;

        // Public Constructor
        /// <summary>
        /// Default constructor for the pizza DAO
        /// </summary>
        public PizzaDAO() 
        {
            // Initialize the _pizzaOrder List
            _pizzaOrder = new List<PizzaModel> ();
        }
        
        // Public Methods
        /// <summary>
        /// Add a pizza to the current order
        /// </summary>
        /// <param name="newPizza"></param>
        /// <returns></returns>
        public int AddPizzaToOrder(PizzaModel newPizza)
        {
            // Add the new pizza to the _pizzaOrder list
            _pizzaOrder.Add (newPizza);
            // Return the number of pizzas in _pizzaOrder
            return _pizzaOrder.Count;
        }

        /// <summary>
        /// Get the list of pizzas in the current order
        /// </summary>
        /// <returns></returns>
        public List<PizzaModel> GetPizzaOrder()
        {
            // Return the pizzaOrder list
            return _pizzaOrder;
        }

        /// <summary>
        /// Write the pizza order to a text file
        /// </summary>
        /// <returns></returns>
        public bool WriteOrderToFile()
        {
            // Declare and initialize
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            string pizzaString = "";

            // Check if the directory exists
            if (!Directory.Exists(filePath))
            {
                // Create the directory
                Directory.CreateDirectory(filePath);
            }

            // Set up a try-catch for the file writer
            try
            {
                // Create a using statement for StreamWriter
                using (StreamWriter streamWriter = new StreamWriter(Path.Combine(filePath, "PizzaOrder.txt")))
                {
                    // Loop through the pizza order list
                    foreach (PizzaModel pizza in _pizzaOrder)
                    {
                        pizzaString =
                        $"Name: {pizza.ClientName}\n" +
                        $"Ingredients: {string.Join(", ", pizza.Ingredients)}\n" +
                        $"Strange Add Ons: {string.Join(", ", pizza.StrangeAddOns)}\n" +
                        $"Crust: {pizza.Crust}\n" +
                        $"Sauce: {pizza.SauceQty}\n" +
                        $"Cheese: {pizza.CheeseQty}\n" +
                        $"Delivery Time: {pizza.DeliveryTime}\n" +
                        $"Pizza Box Color: {pizza.PizzaBoxColor}\n" +
                        $"Price: {pizza.Price}\n\n";
                        streamWriter.WriteLine(pizzaString);
                    }
                }

                // Return true
                return true;
            }
            catch
            {
                // Return false
                return false;
            }
        }
    }
}
