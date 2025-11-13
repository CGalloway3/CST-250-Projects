/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Pizza Maker
 * Activity 4
 * References:
 */

using PizzaMakerClassLibrary.Models;
using PizzaMakerClassLibrary.Services.BusinessLogicLayer;

namespace PizzaMaker
{
    public partial class FrmOrderDetails : Form
    {
        // Declare and Initialize
        private List<PizzaModel> _pizzaOrder;
        private PizzaLogic _pizzaLogic;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FrmOrderDetails()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parameterized constructor for FrmOrderDetails
        /// </summary>
        /// <param name="pizzaOrder"></param>
        public FrmOrderDetails(List<PizzaModel> pizzaOrderList, PizzaLogic pizzaBusinessLogic)
        {
            // Initialize the form
            InitializeComponent();
            // Initialize the class level variables
            _pizzaOrder = pizzaOrderList;
            _pizzaLogic = pizzaBusinessLogic;
        }

        /// <summary>
        /// Display the pizzas on the form
        /// </summary>
        public void DisplayPizzas()
        {
            // Clear the label
            lblOrderDetails.Text = "";

            // Loop through the pizza order list
            foreach (PizzaModel pizza in _pizzaOrder)
            {
                lblOrderDetails.Text +=
                $"Name: {pizza.ClientName}\n" +
                $"Ingredients: {string.Join(", ", pizza.Ingredients)}\n" +
                $"Strange Add Ons: {string.Join(", ", pizza.StrangeAddOns)}\n" +
                $"Crust: {pizza.Crust}\n" +
                $"Sauce: {pizza.SauceQty}\n" +
                $"Cheese: {pizza.CheeseQty}\n" +
                $"Delivery Time: {pizza.DeliveryTime}\n" +
                $"Pizza Box Color: {pizza.PizzaBoxColor}\n" +
                $"Price: {pizza.Price}\n\n";
            }
        }
    }
}
