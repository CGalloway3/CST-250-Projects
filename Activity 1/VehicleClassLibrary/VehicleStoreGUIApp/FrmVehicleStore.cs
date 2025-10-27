/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Vehicle Class Library
 * Activity 1
 * References:
 */

using System.Drawing.Text;
using VehicleClassLibrary.Models;
using VehicleClassLibrary.Services.BusinessLogicLayer;

namespace VehicleStoreGUIApp
{
    public partial class FrmVehicleStore : Form
    {
        // Class level variables
        string currentVehicleType;
        bool isVehicleTypeValid = false, isMakeValid = false, isModelValid = false, isColorValid = false,
            isYearValid = false, isPriceValid = false, isWheelsValid = false, isEngineSizeValid = false,
            isSpecialtyBooleanValid = false, isSpecialtyDecimalValid = false;
        // Create a new vehicel store logic variable
        private StoreLogic _storeLogic;
        // Binding sources for the inventory and shopping cart
        private BindingSource _inventoryBindingSource;
        private BindingSource _shoppingCartBindingSource;

        /// <summary>
        /// Default constructor for FrmVehicleStore
        /// </summary>
        public FrmVehicleStore()
        {
            InitializeComponent();
            // Initialize the current vehicle to create
            currentVehicleType = "";
            // Hide the warning labels
            lblTypeWarning.Visible = false;
            lblMakeWarning.Visible = false;
            lblModelWarning.Visible = false;
            lblColorWarning.Visible = false;
            lblYearWarning.Visible = false;
            lblPriceWarning.Visible = false;
            lblWheelsWarning.Visible = false;
            lblEngineSizeWarning.Visible = false;
            lblBooleanWarning.Visible = false;
            lblSpecialWarning.Visible = false;
            // Initialize the store logic variable
            _storeLogic = new StoreLogic();

            // Initialize the binding source variables
            _inventoryBindingSource = new BindingSource();
            _shoppingCartBindingSource = new BindingSource();
            // Set the data sources of the binding source objects
            _inventoryBindingSource.DataSource = _storeLogic.GetInventory();
            _shoppingCartBindingSource.DataSource = _storeLogic.GetShoppingCart();
            // Set the data source for each list control
            lstInventory.DataSource = _inventoryBindingSource;
            lstShoppingCart.DataSource = _shoppingCartBindingSource;
        }

        /// <summary>
        /// Click event handler to create a car
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoCarClickEH(object sender, EventArgs e)
        {
            // Update the selected vehicle variable
            currentVehicleType = "Car";

            // Change the label for the specialty boolean
            lblSpecialtyBoolean.Text = "Is the car a convertible?";
            // Change the label for the specialty decimal
            lblSpecialtyDecimal.Text = "Trunk Size (cubit feet):";

            // Show the specialty boolean label and radio buttons
            lblSpecialtyBoolean.Visible = true;
            rdoSpecialtyYes.Visible = true;
            rdoSpecialtyNo.Visible = true;
            // Show the specialty decimal label and text box
            lblSpecialtyDecimal.Visible = true;
            txtSpecialtyDecimal.Visible = true;

            // Validate the car type selection
            ValidateVehicleType();
        }

        /// <summary>
        /// Click event handler to create a motorcycle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoMotorcycleClickEH(object sender, EventArgs e)
        {
            // Update the selected vehicle variable
            currentVehicleType = "Motorcycle";

            // Change the label for the specialty boolean
            lblSpecialtyBoolean.Text = "Does the motorcycle have a side car?";
            // Change the label for the specialty decimal
            lblSpecialtyDecimal.Text = "Seat Height (inches):";

            // Show the specialty boolean label and radio buttons
            lblSpecialtyBoolean.Visible = true;
            rdoSpecialtyYes.Visible = true;
            rdoSpecialtyNo.Visible = true;
            // Show the specialty decimal label and text box
            lblSpecialtyDecimal.Visible = true;
            txtSpecialtyDecimal.Visible = true;

            // Validate the motorcycle type selection
            ValidateVehicleType();
        }

        /// <summary>
        /// Click event handler to create a pickup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoPickupClickEH(object sender, EventArgs e)
        {
            // Update the selected vehicle variable
            currentVehicleType = "Pickup";

            // Change the label for the specialty boolean
            lblSpecialtyBoolean.Text = "Does the pickup have a bed cover?";
            // Change the label for the specialty decimal
            lblSpecialtyDecimal.Text = "Bed Size (cubic feet):";

            // Show the specialty boolean label and radio buttons
            lblSpecialtyBoolean.Visible = true;
            rdoSpecialtyYes.Visible = true;
            rdoSpecialtyNo.Visible = true;
            // Show the specialty decimal label and text box
            lblSpecialtyDecimal.Visible = true;
            txtSpecialtyDecimal.Visible = true;

            // Validate the pickup type selection
            ValidateVehicleType();
        }

        /// <summary>
        /// Click event handler to add a general vehicle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoVehicleClickEH(object sender, EventArgs e)
        {
            // Update the selected vehicle variable
            currentVehicleType = "Vehicle";

            // Hide the specialty boolean label and radio buttons
            lblSpecialtyBoolean.Visible = false;
            rdoSpecialtyYes.Visible = false;
            rdoSpecialtyNo.Visible = false;
            // Hide the specialty decimal label and text box
            lblSpecialtyDecimal.Visible = false;
            txtSpecialtyDecimal.Visible = false;

            // Validate the vehicle type selection
            ValidateVehicleType();
        }

        /// <summary>
        /// Click event handler for both of the specialty boolean radio buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RdoSpecialtyBooleanClickEH(object sender, EventArgs e)
        {
            // Validate the specialty boolean selection
            ValidateSpecialtyBoolean();
        }

        /// <summary>
        /// Click event handler for the add to cart button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddToCartClickEH(object sender, EventArgs e)
        {
            // Get the selected vehicle from the inventory list
            VehicleModel selectedVehicle = (VehicleModel)lstInventory.SelectedItem;
            if (selectedVehicle != null)
            {
                // Add the selected vehicle to the shopping cart
                _storeLogic.AddVehicleToCart(selectedVehicle.Id);
                // Refresh the shopping cart list control
                _shoppingCartBindingSource.ResetBindings(false);

            }
        }

        /// <summary>
        /// Click event handler for the remove from cart button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveFromCartClickEH(object sender, EventArgs e)
        {
            // Get the selected vehicle from the shopping cart list
            VehicleModel selectedVehicle = (VehicleModel)lstShoppingCart.SelectedItem;

            if (selectedVehicle != null)
            {
                _storeLogic.RemoveVehicleFromCart(selectedVehicle.Id);
            }
            _shoppingCartBindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Click event handler for the checkout button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCheckoutClickEH(object sender, EventArgs e)
        {
            // Perform the checkout operation
            decimal total = _storeLogic.Checkout();
            // Display the total to lblTotalAmount with the currency format
            lblTotalAmount.Text = total.ToString("C");
            // Reset the bindings for the shopping cart binding source
            _shoppingCartBindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Create Button click event handler
        /// </summary>
        private void BtnCreateClickEH(object sender, EventArgs e)
        {
            // Declare and Initialize variables
            int id = 0;
            string make = "", model = "", color = "";
            int year = -1, wheels = -1;
            decimal price = -1m, engineSize = -1m, specialtyDecimal = -1m;
            bool specialtyBoolean = false;
            VehicleModel vehicle;

            // Test for null/empty textboxes
            ValidateVehicleType();
            make = ValidateTxtMake();
            model = ValidateTxtModel();
            color = ValidateTxtColor();
            year = ValidateTxtYear();
            price = ValidateTxtPrice();
            wheels = ValidateTxtWheels();
            engineSize = ValidateTxtEngineSize();
            specialtyBoolean = ValidateSpecialtyBoolean();
            specialtyDecimal = ValidateSpecialtyDecimal();

            // If all validations pass, create the vehicle
            // Check the state of the flags
            if (isVehicleTypeValid && isMakeValid && isModelValid && isColorValid
                && isYearValid && isPriceValid && isWheelsValid && isEngineSizeValid
                && isSpecialtyBooleanValid && isSpecialtyDecimalValid)
            {
                // Create the appropriate vehicle type
                switch (currentVehicleType)
                {
                    case "Car":
                        // Create a new car
                        vehicle = new CarModel(id, make, model, color, year, price, wheels, engineSize,
                            specialtyBoolean, specialtyDecimal);
                        break;

                    case "Motorcycle":
                        // Create a new motorcycle
                        vehicle = new MotorcycleModel(id, make, model, color, year, price, wheels, engineSize,
                            specialtyBoolean, specialtyDecimal);
                        break;

                    case "Pickup":
                        // Create a new pickup
                        vehicle = new PickupModel(id, make, model, color, year, price, wheels, engineSize,
                            specialtyBoolean, specialtyDecimal);
                        break;

                    default:
                        // Create a new vehicle
                        vehicle = new VehicleModel(id, make, model, color, year, price, wheels, engineSize);
                        break;
                }
                
                // Add the vehicle to the inventory
                _storeLogic.AddVehicleToInventory(vehicle);

                // Clear the fields for the next entry
                rdoCar.Checked = false;
                rdoMotorcycle.Checked = false;
                rdoPickup.Checked = false;
                rdoVehicle.Checked = false;
                txtMake.Clear();
                txtModel.Clear();
                txtColor.Clear();
                txtYear.Clear();
                txtPrice.Clear();
                txtWheels.Clear();
                txtEngineSize.Clear();
                rdoSpecialtyYes.Checked = false;
                rdoSpecialtyNo.Checked = false;
                txtSpecialtyDecimal.Clear();

                //Refresh the list controls
                _inventoryBindingSource.ResetBindings(false);

                // Display first warning label for vehicle type radio buttons
                lblTypeWarning.Visible = true;
            }
        }

        /// <summary>
        /// Click event handler for the load inventory button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLoadClickEH(object sender, EventArgs e)
        {
            // Read in from file
            _storeLogic.ReadInventory();

            //Refresh the list controls
            _inventoryBindingSource.ResetBindings(false);
        }

        /// <summary>
        /// Click event Handler for the save inventory button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveClickEH(object sender, EventArgs e)
        {
            // Write out to file
            _storeLogic.WriteInventory();

            // Refresh the list controls
            _inventoryBindingSource.ResetBindings(false);
        }

        /// <summary>                 ///
        /// Validation Checks region  ///
        /// </summary>                ///  

        #region Leave event handlers for validation

        private void TxtMakeLeaveEH(object sender, EventArgs e)
        {
            // Validate the make textbox
            ValidateTxtMake();
        }

        private void TxtModelLeaveEH(object sender, EventArgs e)
        {
            // Validate the model textbox
            ValidateTxtModel();
        }

        private void TxtColorLeaveEH(object sender, EventArgs e)
        {
            // Validate the color textbox
            ValidateTxtColor();
        }

        private void TxtYearLeaveEH(object sender, EventArgs e)
        {
            // Validate the year textbox
            ValidateTxtYear();
        }

        private void TxtPriceLeaveEH(object sender, EventArgs e)
        {
            // Validate the price textbox
            ValidateTxtPrice();
        }

        private void TxtWheelsLeaveEH(object sender, EventArgs e)
        {
            // Validate the wheels textbox
            ValidateTxtWheels();
        }

        private void TxtEngineSizeLeaveEH(object sender, EventArgs e)
        {
            // Validate the engine size textbox
            ValidateTxtEngineSize();
        }

        private void TxtSpecialLeaveEH(object sender, EventArgs e)
        {
            // Validate the specialty decimal textbox
            ValidateSpecialtyDecimal();
        }


        #endregion

        #region Validation Checks

        /// <summary>
        /// Validate that the user has selected a vehicle type
        /// </summary>
        private void ValidateVehicleType()
        {
            if (rdoCar.Checked || rdoMotorcycle.Checked || rdoPickup.Checked || rdoVehicle.Checked)
            {
                // Hide the error label
                lblTypeWarning.Visible = false;
                // Set the flag
                isVehicleTypeValid = true;
            }
            else
            {
                // Show the error label
                lblTypeWarning.Visible = true;
                // Set the flag
                isVehicleTypeValid = false;
            }
        }

        /// <summary>
        /// Validate the make textbox
        /// </summary>
        private string ValidateTxtMake()
        {
            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtMake.Text))
            {
                lblMakeWarning.Visible = true;
                // Set the flag
                isMakeValid = false;
            }
            else
            {
                lblMakeWarning.Visible = false;
                // Clear the flag
                isMakeValid = true;
            }
            // Return the text from the textbox
            return txtMake.Text;
        }

        /// <summary>
        /// Validate the model textbox
        /// </summary>
        private string ValidateTxtModel()
        {
            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtModel.Text))
            {
                lblModelWarning.Visible = true;
                // Set the flag
                isModelValid = false;
            }
            else
            {
                lblModelWarning.Visible = false;
                // Clear the flag
                isModelValid = true;
            }
            // Return the text from the textbox
            return txtModel.Text;
        }

        /// <summary>
        /// Validate the color textbox
        /// </summary>
        private string ValidateTxtColor()
        {
            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtColor.Text))
            {
                lblColorWarning.Visible = true;
                // Set the flag
                isColorValid = false;
            }
            else
            {
                lblColorWarning.Visible = false;
                // Clear the flag
                isColorValid = true;
            }
            // Return the text from the textbox
            return txtColor.Text;
        }

        /// <summary>
        /// Validate the year textbox
        /// </summary>
        private int ValidateTxtYear()
        {
            // Declare and initialize
            int yearValue = -1;

            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtYear.Text))
            {
                lblYearWarning.Visible = true;
                // Set the flag
                isYearValid = false;
            }
            else
            {
                lblYearWarning.Visible = false;
                // Attempt to parse the textbox value
                isYearValid = int.TryParse(txtYear.Text, out yearValue);
                // If the parse failed, show the error message
                if (!isYearValid)
                {
                    lblYearWarning.Visible = true;
                }
            }
            // Return the year
            return yearValue;
        }

        /// <summary>
        /// Validate the price textbox
        /// </summary>
        private decimal ValidateTxtPrice()
        {
            // Declare and initialize
            decimal priceValue = -1;

            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                lblPriceWarning.Visible = true;
                // Set the flag
                isPriceValid = false;
            }
            else
            {
                lblPriceWarning.Visible = false;
                // Attempt to parse the textbox value
                isPriceValid = decimal.TryParse(txtPrice.Text, out priceValue);
                // If the parse failed, show the error message
                if (!isPriceValid)
                {
                    lblPriceWarning.Visible = true;
                }
            }
            // Return the price
            return priceValue;
        }

        /// <summary>
        /// Validate the wheels textbox
        /// </summary>
        private int ValidateTxtWheels()
        {
            // Declare and initialize
            int wheelsValue = -1;

            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtWheels.Text))
            {
                lblWheelsWarning.Visible = true;
                // Set the flag
                isWheelsValid = false;
            }
            else
            {
                lblWheelsWarning.Visible = false;
                // Attempt to parse the textbox value
                isWheelsValid = int.TryParse(txtWheels.Text, out wheelsValue);
                // If the parse failed, show the error message
                if (!isWheelsValid)
                {
                    lblWheelsWarning.Visible = true;
                }
            }
            // Return the year
            return wheelsValue;
        }

        /// <summary>
        /// Validate the engine size textbox
        /// </summary>
        private decimal ValidateTxtEngineSize()
        {
            // Declare and initialize
            decimal engineSizeValue = -1;

            // Test for a null/empty textbox
            if (string.IsNullOrEmpty(txtEngineSize.Text))
            {
                lblEngineSizeWarning.Visible = true;
                // Set the flag
                isEngineSizeValid = false;
            }
            else
            {
                lblEngineSizeWarning.Visible = false;
                // Attempt to parse the textbox value
                isEngineSizeValid = decimal.TryParse(txtEngineSize.Text, out engineSizeValue);
                // If the parse failed, show the error message
                if (!isEngineSizeValid)
                {
                    lblEngineSizeWarning.Visible = true;
                }
            }
            // Return the price
            return engineSizeValue;
        }

        /// <summary>
        /// Validate that the user has selected a specialty boolean
        /// </summary>
        private bool ValidateSpecialtyBoolean()
        {
            if (currentVehicleType != "Vehicle")
            {
                if (rdoSpecialtyYes.Checked || rdoSpecialtyNo.Checked)
                {
                    // Hide the error label
                    lblBooleanWarning.Visible = false;
                    // Set the flag
                    isSpecialtyBooleanValid = true;
                }
                else
                {
                    // Show the error label
                    lblBooleanWarning.Visible = true;
                    // Set the flag
                    isSpecialtyBooleanValid = false;
                }
            }
            else
            {
                // Hide the error label
                lblBooleanWarning.Visible = false;
                // Set the flag
                isSpecialtyBooleanValid = true;
            }
            return rdoSpecialtyYes.Checked;
        }

        /// <summary>
        /// Validate the specialty decimal textbox
        /// </summary>
        private decimal ValidateSpecialtyDecimal()
        {
            // Declare and initialize
            decimal specialtyDecimalValue = -1;

            if (currentVehicleType != "Vehicle")
            {
                // Test for a null/empty textbox
                if (string.IsNullOrEmpty(txtSpecialtyDecimal.Text))
                {
                    lblSpecialWarning.Visible = true;
                    // Set the flag
                    isSpecialtyDecimalValid = false;
                }
                else
                {
                    lblSpecialWarning.Visible = false;
                    // Attempt to parse the textbox value
                    isSpecialtyDecimalValid = decimal.TryParse(txtSpecialtyDecimal.Text, out specialtyDecimalValue);
                    // If the parse failed, show the error message
                    if (!isSpecialtyDecimalValid)
                    {
                        lblSpecialWarning.Visible = true;
                    }
                }
            }
            else
            {
                lblSpecialWarning.Visible = false;
                // Set the flag
                isSpecialtyDecimalValid = true;
            }
            // Return the specialty decimal
            return specialtyDecimalValue;
        }

        #endregion
    }
}
