/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/06/2020
 * Pizza Maker
 * Activity 4
 * References:
 */

using PizzaMaker.Models;

namespace PizzaMaker
{
    public partial class FrmPizzaMarker : Form
    {
        // Class level variable declarations
        private PizzaModel _pizza;
        public FrmPizzaMarker()
        {
            InitializeComponent();
            // Initialize the current order
            _pizza = new PizzaModel();

            // Disable the Create Pizza button
            btnCreatePizza.Enabled = false;
            // Disable the Reset Form button
            btnResetForm.Enabled = false;
            UpdatePrice();
        }

        /// <summary>
        /// Enables the reset and create buttons
        /// for the order pizza form
        /// </summary>
        public void EnablePizzaCreation()
        {
            // Enable the Create Pizza button
            btnCreatePizza.Enabled = true;
            // Enable the Reset Form button
            btnResetForm.Enabled = true;
        }

        /// <summary>
        /// Leave Event Handler for txtName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtNameLeaveEH(object sender, EventArgs e)
        {
            // Set the Pizza client name to text name
            _pizza.ClientName = txtName.Text;
            // Call enable pizza creation method
            EnablePizzaCreation();
        }

        /// <summary>
        /// Update the price of the pizza
        /// </summary>
        public void UpdatePrice()
        {
            // Declare and initialize
            decimal price = 15;

            // Add 50 cents for each ingredient
            price += (_pizza.Ingredients.Count * .50m);

            // Add 50 cents for each special add on
            price += (_pizza.StrangeAddOns.Count * .50m);

            // Add $1 if the crust if gluten free
            if (_pizza.Crust == "Gluten Free")
            {
                price += 1;
            }

            // Update the price of the pizza
            _pizza.Price = price;
            // Update lblPizzaPrice
            lblPizzaPriceAmount.Text = $"{price:C2}";
        }
    }
}
