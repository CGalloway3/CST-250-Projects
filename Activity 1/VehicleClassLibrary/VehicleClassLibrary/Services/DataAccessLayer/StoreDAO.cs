/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Vehicle Class Library
 * Activity 1
 * References:
 */

using VehicleClassLibrary.Models;

namespace VehicleClassLibrary.Services.DataAccessLayer
{
    public class StoreDAO
    {
        // CarModel list for the stores inventory
        private List<VehicleModel> _inventory;
        // CarModel list for the users shopping cart
        private List<VehicleModel> _shoppingCart;
        // The directory for the inventory text file
        private string _fileDirectory = "Data";
        // The name of the inventory text file
        private string _textFile = "inventory.txt";
        // The full path to the text file
        private string _filePath;

        /// <summary>
        /// Default constructor for StoreDAO
        /// </summary>
        public StoreDAO()
        {
            // Initialize the vehicle model list
            _inventory = new List<VehicleModel>();
            _shoppingCart = new List<VehicleModel>();
            // Set up the file to the inventory text file
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fileDirectory, _textFile);
        }

        /// <summary>
        /// Get a list of vehicles in the inventory
        /// </summary>
        public List<VehicleModel> GetInventory()
        {
            // Return the inventory list
            return _inventory;
        }

        /// <summary>
        /// Get a list of the vehicles in the users shopping cart
        /// </summary>
        public List<VehicleModel> GetShoppingCart()
        {
            // Return the shopping cart list
            return _shoppingCart;
        }

        /// <summary>
        /// Add a new vehicle to the inventory
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns> The id of the added vehicle or -1 for a duplicate vehicle that was not added.</returns>
        public int AddVehicleToInventory(VehicleModel vehicle)
        {
            // Prohibit duplicate vehicle entry into the inventory
            // Loop through the inventory and compare properties
            for (int i = 0; i < _inventory.Count; i++)
            {
                if (_inventory[i].Make == vehicle.Make && _inventory[1].Model == vehicle.Model && _inventory[i].Color == vehicle.Color
                    && _inventory[i].Year == vehicle.Year && _inventory[i].Price == vehicle.Price && _inventory[i].NumWheels == vehicle.NumWheels
                    && _inventory[i].EngineSize == vehicle.EngineSize)
                {
                    Type vehicleType = vehicle.GetType();
                    switch (vehicleType.Name)
                    {
                        case "CarModel":
                            //Cast the vehicle and current inventory item to a car
                            CarModel newCar = (CarModel)vehicle;
                            CarModel oldCar = (CarModel)_inventory[i];
                            // Check last two properties
                            if (oldCar.IsConvertible == newCar.IsConvertible && oldCar.TrunkSize == newCar.TrunkSize)
                            {
                                return -1;
                            }
                            break;

                        case "MotorcycleModel":
                            //Cast the vehicle and current inventory item to a car
                            MotorcycleModel newMotorcycle = (MotorcycleModel)vehicle;
                            MotorcycleModel oldMotorcycle = (MotorcycleModel)_inventory[i];
                            // Check last two properties
                            if (oldMotorcycle.HasSideCar == newMotorcycle.HasSideCar && oldMotorcycle.SeatHeight == newMotorcycle.SeatHeight)
                            {
                                return -1;
                            }
                            break;

                        case "PickupModel":
                            //Cast the vehicle and current inventory item to a car
                            PickupModel newPickup = (PickupModel)vehicle;
                            PickupModel oldPickup = (PickupModel)_inventory[i];
                            // Check last two properties
                            if (oldPickup.HasBedCover == newPickup.HasBedCover && oldPickup.BedSize == newPickup.BedSize)
                            {
                                return -1;
                            }
                            break;

                        default:
                            return -1;

                    }
                }
            }

            // If the code reaches this point the vehicle is not an exact duplicate and we are going to add it.
            // Set the id for the new vehicle
            vehicle.Id = _inventory.Count + 1;
            // Add the vehicle to the inventory list
            _inventory.Add(vehicle);

            // Return  the id of the new vehicle
            return vehicle.Id;
        }

        /// <summary>
        /// Add a vehicle to the shopping cart based on the vehicle id
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public int AddVehicleToCart(int vehicleId)
        {
            // Loop through the inventory to find the correct vehicle
            for (int i = 0; i < _inventory.Count; i++)
            {
                // Check if the inventory vehicle id matches the parameters
                if (_inventory[i].Id == vehicleId)
                {
                    // If so, add the vehicle to the shopping cart
                    _shoppingCart.Add(_inventory[i]);
                }
            }
            // Return the number of vehicles in the shopping cart
            return _shoppingCart.Count;
        }

        /// <summary>
        /// Removes a vehicle from the shopping cart based on the specified vehicle ID.
        /// </summary>
        /// <remarks>If multiple vehicles with the same ID exist in the cart, only the first occurrence is
        /// removed.</remarks>
        /// <param name="vehicleId">The unique identifier of the vehicle to be removed from the cart.</param>
        /// <returns>The total number of vehicles remaining in the shopping cart after the removal.</returns>
        public int RemoveVehicleFromCart(int vehicleId)
        {
            // Loop through the shopping cart to find the correct vehicle
            for (int i = 0; i < _shoppingCart.Count; i++)
            {
                // Check if the shopping cart vehicle id matches the parameters
                if (_shoppingCart[i].Id == vehicleId)
                {
                    // If so, remove the vehicle to the shopping cart
                    _shoppingCart.Remove(_shoppingCart[i]);
                    break; // exit for loop so only one vehicle is removed at a time
                }
            }
            // Return the number of vehicles in the shopping cart
            return _shoppingCart.Count;
        }

        /// <summary>
        /// Write the inventory to a text file
        /// </summary>
        /// <returns></returns>
        public bool WriteInventory()
        {
            // Check if the directory exists
            if (!Directory.Exists(_fileDirectory))
            {
                // If the directory does not exist, create it
                Directory.CreateDirectory(_fileDirectory);
            }

            // Try/Catch any exceptions with the stream writer
            try
            {
                // Create the stream writer to write to the file
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    // Loop through each vehicle in the inventory
                    foreach (VehicleModel vehicle in _inventory)
                    {
                        Type vehicleType = vehicle.GetType();
                        switch (vehicleType.Name)
                        {
                            case "CarModel":
                                //Cast the vehicle to a car
                                CarModel car = (CarModel)vehicle;
                                // Write the car to the file
                                writer.WriteLine($"Car, {car.Make}, {car.Model}, {car.Color}, {car.Year}, {car.Price}, {car.NumWheels}, {car.EngineSize}, {car.IsConvertible}, {car.TrunkSize}");
                                break;

                            case "MotorcycleModel":
                                // Cast the vehicle to a motorcycle
                                MotorcycleModel motorcycle = (MotorcycleModel)vehicle;
                                // Write the motorcycle to the file
                                writer.WriteLine($"Motorcycle, {motorcycle.Make}, {motorcycle.Model}, {motorcycle.Color}, {motorcycle.Year}, {motorcycle.Price}, {motorcycle.NumWheels}, {motorcycle.EngineSize},{motorcycle.HasSideCar}, {motorcycle.SeatHeight}");
                                break;

                            case "PickupModel":
                                // Cast the vehicle to a pickup
                                PickupModel pickup = (PickupModel)vehicle;
                                // Write the pickup to the file
                                writer.WriteLine($"Pickup, {pickup.Make}, {pickup.Model}, {pickup.Color}, {pickup.Year}, {pickup.Price}, {pickup.NumWheels}, {pickup.EngineSize}, {pickup.HasBedCover}, {pickup.BedSize}");
                                break;

                            default:
                                // Write the vehicle to the file
                                writer.WriteLine($"Vehicle, {vehicle.Make}, {vehicle.Model}, {vehicle.Color}, {vehicle.Year}, {vehicle.Price}, {vehicle.NumWheels}, {vehicle.EngineSize}");
                                break;
                        }
                    }
                }
                // Return if all the data was saved to the file
                return true;
            }
            catch (Exception)
            {
                // Return false if an exception was thrown
                return false;
            }
        } // End of WriteInventory method

        /// <summary>
        /// Read the inventory from a text file
        /// </summary>  
        /// <returns></returns>
        public List<VehicleModel> ReadInventory()
        {
            // Declare and Initialize
            string? line = "";
            string[] parts = [];
            string make = "", model = "", color = "";
            int year = 0, numWheels = 0;
            decimal price = 0m, engineSize = 0m;
            // specialty vehicle variables
            bool isConvertible = false, hasSideCar = false, hasBedCover = false;
            decimal trunkSize = 0m, seatHeight = 0m, bedSize = 0m;

            // Try/Catch any exceptions with the stream reader
            try
            {
                // check if the file exists
                if (File.Exists(_filePath))
                {
                    // Create the stream reader to read from the file
                    using (StreamReader reader = new StreamReader(_filePath))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Split the line into parts on a comma-space
                            // Create a string array to put all the seperate vehicle parts into
                            parts = line.Split(", ");

                            // Use the parts array to get the common data (make, model, year,price,numWheels)
                            make = parts[1];
                            model = parts[2];
                            color = parts[3];
                            // Parse the year of the vehicle
                            year = ParseInteger(parts[4]);
                            // Parse the price of the vehicle
                            price = ParseDecimal(parts[5]);
                            // Parse the number of wheels
                            numWheels = ParseInteger(parts[6]);
                            // Parse the engine size
                            engineSize = ParseDecimal(parts[7]);

                            // Use the first part of the data to create a switch for the specific model
                            switch (parts[0])
                            {
                                case "Car":
                                    // Parse the convertible status for the car
                                    isConvertible = ParseBoolean(parts[8]);
                                    // Parse the trunk size for the car
                                    trunkSize = ParseDecimal(parts[9]);
                                    // Create a new car model and add it to the inventory
                                    CarModel car = new CarModel(0, make, model, color, year, price, numWheels, engineSize, isConvertible, trunkSize);
                                    // Add the car to the inventory
                                    AddVehicleToInventory(car);
                                    break;

                                case "Motorcycle":
                                    // Parse the side car status for the motorcycle
                                    hasSideCar = ParseBoolean(parts[8]);
                                    // Parse the seat height for the motorcycle
                                    seatHeight = ParseDecimal(parts[9]);
                                    // Create a new motorcycle using the read properties
                                    MotorcycleModel motorcycle = new MotorcycleModel(0, make, model, color, year, price, numWheels, engineSize, hasSideCar, seatHeight);
                                    // Add the motorcycle to the inventory
                                    AddVehicleToInventory(motorcycle);
                                    break;

                                case "Pickup":
                                    // Parse the bed cover status for the pickup
                                    hasBedCover = ParseBoolean(parts[8]);
                                    // Parse the bed size for the pickup
                                    bedSize = ParseDecimal(parts[9]);
                                    // Create a new pickup using the read properties
                                    PickupModel pickup = new PickupModel(0, make, model, color, year, price, numWheels, engineSize, hasBedCover, bedSize);
                                    AddVehicleToInventory(pickup);
                                    break;

                                default:
                                    // Create a new vehicle using the read properties
                                    VehicleModel vehicle = new VehicleModel(0, make, model, color, year, price, numWheels, engineSize);
                                    AddVehicleToInventory(vehicle);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Return the inventory list as is
                return _inventory;
            }
            // Return the inventory list
            return _inventory;
        } // End of ReadInventory method

        /// <summary>
        /// Method to safely parse an integer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int ParseInteger(string input)
        {
            try
            {
                // Parse the input and return
                return int.Parse(input);
            }
            catch (Exception ex)
            {
                // Return 0
                return 0;
            }
        }

        /// <summary>
        /// Method to safely parse a decimal
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private decimal ParseDecimal(string input)
        {
            try
            {
                // Parse the input and return
                return decimal.Parse(input);
            }
            catch (Exception ex)
            {
                // Return 0
                return 0m;
            }
        }

        /// <summary>
        /// Method to safely parse a boolean
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool ParseBoolean(string input)
        {
            try
            {
                // Parse the input and return
                return bool.Parse(input);
            }
            catch (Exception ex)
            {
                // Return false
                return false;
            }
        }

        /// <summary>
        /// Get the total of the users shopping cart and clear the cart
        /// </summary>
        /// <returns></returns>
        public decimal Checkout()
        {
            // Set up a variable to keep track of the carts total
            decimal total = 0m;

            // Loop through each vehicle in the shopping cart
            foreach (VehicleModel vehicle in _shoppingCart)
            {
                // Add the vehicle price to the total variable
                total += vehicle.Price;
            }
            // Clear the cart
            _shoppingCart.Clear();

            // Return the total
            return total;
        }
    }
}

