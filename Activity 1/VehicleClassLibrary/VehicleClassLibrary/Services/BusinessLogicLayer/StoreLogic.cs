/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Vehicle Class Library
 * Activity 1
 * References:
 */
using VehicleClassLibrary.Models;
using VehicleClassLibrary.Services.DataAccessLayer;

namespace VehicleClassLibrary.Services.BusinessLogicLayer
{
    public class StoreLogic
    {
        // Declare class level variables
        private StoreDAO _storeDAO;

        /// <summary>
        /// Default constructor for the StoreLogic class
        /// </summary>
        public StoreLogic() 
        {
            // Initialize the DAO variable
            _storeDAO = new StoreDAO();
        }

        /// <summary>
        /// Add a vehicle to the shopping cart based on the vehicle id
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public int AddVehicleToCart(int vehicleId)
        {
            // Call the AddVehicleToCart method in the DAO
            return _storeDAO.AddVehicleToCart(vehicleId);
        }

        /// <summary>
        /// Add a new vehicle to the inventory
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public int AddVehicleToInventory(VehicleModel vehicle)
        {
            // Call the AddVehicleToInventory method in the DAO
            return _storeDAO.AddVehicleToInventory(vehicle);
        }

        /// <summary>
        /// Get the total of the users shopping cart and clear the cart
        /// </summary>
        /// <returns></returns>
        public decimal Checkout()
        {
            // Call and return the Checkout method in the DAO
            return _storeDAO.Checkout();
        }

        /// <summary>
        /// Get a list of vehicles in the inventory
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> GetInventory()
        {
            // Call and return the GetInventory method in the DAO
            return _storeDAO.GetInventory();
        }

        /// <summary>
        /// Get a list of vehicles in the users shopping cart
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> GetShoppingCart()
        {
            // Call and return the GetShoppingCart method in the DAO
            return _storeDAO.GetShoppingCart();
        }

        /// <summary>
        /// Write the inventory to a text file
        /// </summary>
        public void WriteInventory()
        {
            // Call the WriteInventory method in the DAO
            _storeDAO.WriteInventory();
        }

        /// <summary>
        /// Read the list of vehicles from a text file
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> ReadInventory()
        {
            // Call and return the ReadInventory method in the DAO
            return _storeDAO.ReadInventory();
        }
    }
}
