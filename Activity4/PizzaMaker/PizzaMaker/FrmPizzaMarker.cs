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

        /// <summary>
        /// Default constructor for FrmPizzaMaker
        /// </summary>
        public FrmPizzaMarker()
        {
            InitializeComponent();
            // Initialize the current order
            _pizza = new PizzaModel();

            // Disable the Create Pizza button
            btnCreatePizza.Enabled = false;
            // Disable the Reset Form button
            btnResetForm.Enabled = false;
            // Update the price of the pizza
            UpdatePrice();

            // Update the maximums for the hsbSauce and hsbCheese
            hsbSauce.Maximum = 100 + hsbSauce.LargeChange - 1;
            hsbCheese.Maximum = 100 + hsbCheese.LargeChange - 1;
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
        /// Checked Changed event handler for all the ingredient check boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChbIngredientsCheckedChangedEH(object sender, EventArgs e)
        {
            // Get the check box from the sender parameter
            CheckBox checkbox = sender as CheckBox;

            // Make sure the checkbox is not null
            if (checkbox != null)
            {
                // If the checkbox is checked, add the ingredient to the pizza
                if (checkbox.Checked)
                {
                    // Add the current ingredient to the pizza
                    _pizza.Ingredients.Add(checkbox.Text);
                }
                // If the checkbox is not checked, remove the ingredient
                else
                {
                    // Remove the current ingredient from the pizza
                    _pizza.Ingredients.Remove(checkbox.Text);
                }
            }

            // Update the price of the pizza
            UpdatePrice();
        }


        /// <summary>
        /// Selected Index Changed event handler for lsbStrangeAddOns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsbStrangeAddOnsSelectedIndexChangedEH(object sender, EventArgs e)
        {
            // Get the list of the selected  ingredients ad set the strange addons property of the pizza
            _pizza.StrangeAddOns = lsbStrangeAddOns.SelectedItems.Cast<string>().ToList();
            // update the price of the pizza    
            UpdatePrice();
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

        /// <summary>
        /// Checked Changed event handler for crust radio buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoCrustCheckedChangedEH(object sender, EventArgs e)
        {
            // Get the  radio button from the sender object
            RadioButton radioButton = sender as RadioButton;
            // Make sure tthe radio button is not null
            if (radioButton != null && radioButton.Checked)
            {
                _pizza.Crust = radioButton.Text;
            }
            // Update the price
            UpdatePrice();
        }

        /// <summary>
        /// Value changed event handler for the horizontal scroll bars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HsbExtraGoodiesValueChangedEH(object sender, EventArgs e)
        {
            // Cast  the sender object to an HScrollBar
            HScrollBar scrollBar = sender as HScrollBar;
            // Make sure the bar is not null
            if (scrollBar != null)
            {
                // Check if the scroll bar is hsbSauce
                if (scrollBar == hsbSauce)
                {
                    // Update the sauce quantity property using the scroll bars value
                    _pizza.SauceQty = scrollBar.Value;
                    // update the label sauce value
                    lblSauceAmount.Text = scrollBar.Value.ToString();
                }
                // Check if the scroll bar is hsbCheese
                else if (scrollBar == hsbCheese)
                {
                    // Update the cheese quantity property using the scroll bars value
                    _pizza.CheeseQty = scrollBar.Value;
                    // update the label cheese value
                    lblCheeseAmount.Text = scrollBar.Value.ToString();
                }
            }
        }

        /// <summary>
        /// Value changed evet handler for the dtpDeliveryTime
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DtpDeliveryTimeValueChangedEH(object sender, EventArgs e)
        {
            // Update the delivery time for the pizza
            _pizza.DeliveryTime = dtpDeliveryTime.Value;
        }

        /// <summary>
        /// Click Event handler for the picPizzaBoxColor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PicPizzaBoxColorClickEH(object sender, EventArgs e)
        {
            // Create a new color dialog object
            ColorDialog pizzaBoxColorPicler = new ColorDialog();
            // Call the show dialog method
            DialogResult result = pizzaBoxColorPicler.ShowDialog();
            // Check if the color picker returned ok
            if (result == DialogResult.OK)
            {
                // Set the Pizza box color
                _pizza.PizzaBoxColor = pizzaBoxColorPicler.Color;
                // Set the color of the picture box
                picPizzaBoxColor.BackColor = pizzaBoxColorPicler.Color;
            }
        }

        /// <summary>
        /// Click event handler for the btnResetForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetFormClickEH(object sender, EventArgs e)
        {
            // Reset the from
            ResetForm();
        }

        /// <summary>
        /// Reset the Pizza maker form
        /// </summary>
        private void ResetForm()
        {
            // set the pizza to a new instance
            _pizza = new PizzaModel();
            // Reset the controls on the new form
            ResetControls(this);
            // Update the price of the of the Pizza
            UpdatePrice();
        }

        /// <summary>
        /// Reset the controls within the parent control
        /// </summary>
        /// <param name="parentControl"></param>
        private void ResetControls(Control parentControl)
        {
            // Loop through the controls within the parent control
            foreach (Control control in parentControl.Controls)
            {
                // Get the type of the control
                Type controlType = control.GetType();
                // Save the type of the control as a string
                string type = controlType.Name.ToString();

                // Use a switch case to handle the resets
                switch (type)
                {
                    case "TextBox":
                        // Cast the control to a textbox
                        TextBox textbox = (TextBox)control;
                        // Clear the textbox
                        textbox.Clear();
                        break;

                    case "CheckBox":
                        // Cast the control to a checkbox
                        CheckBox checkbox = (CheckBox)control;
                        // Make sure the checkbox is not checked
                        checkbox.Checked = false;
                        break;

                    case "ListBox":
                        // Cast the control to a list box
                        ListBox listbox = (ListBox)control;
                        // Clear the selected items in the list box
                        listbox.ClearSelected();
                        break;

                    case "RadioButton":
                        // Cast the control to a radio button
                        RadioButton radioButton = (RadioButton)control;
                        // Make sure the radio button is not checked
                        radioButton.Checked = false;
                        break;

                    case "HScrollBar":
                        // Cast the control to a horizontal scroll bar
                        HScrollBar hScrollBar = (HScrollBar)control;
                        // Set the scroll bars value to 0
                        hScrollBar.Value = 0;
                        break;

                    case "DateTimePicker":
                        // Cast the control to a date time picker
                        DateTimePicker dateTimePicker = (DateTimePicker)control;
                        // Set the date to 1/1/2025 12:00am
                        dateTimePicker.Value = new DateTime(dateTimePicker.MinDate.Ticks);
                        break;

                    case "PictureBox":
                        // Cast the control to a picture box
                        PictureBox pictureBox = (PictureBox)control;
                        // Change the picture box back color to the default
                        pictureBox.BackColor = SystemColors.Control;
                        break;
                }

                // Check if the control has controls (children)
                if (control.HasChildren)
                {
                    // Recursively call the Reset method using the current control
                    ResetControls(control);
                }
            }
        } // End of ResetControls method

    }
}
