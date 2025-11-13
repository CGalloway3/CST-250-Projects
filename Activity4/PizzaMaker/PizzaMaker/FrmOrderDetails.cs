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

        // Public Constructor
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

        // Public Methods
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

        // Private Event Handlers
        /// <summary>
        /// Click event handler for the btnSaveOrder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveOrderClickEH(object sender, EventArgs e)
        {
            // Declare and Initialize
            bool isSaveSuccess = false;

            // Write the order to the file
            isSaveSuccess = _pizzaLogic.WriteOrderToFile();

            // Check if the save was successful
            if (isSaveSuccess)
            {
                // Show a success message to the user
                MessageBox.Show("The pizza order was saved.");
            }
            else
            {
                // Show a failure message to the user
                MessageBox.Show("An error occurred while trying to save your order. Please try again later.");
            }
        }
    }
}
