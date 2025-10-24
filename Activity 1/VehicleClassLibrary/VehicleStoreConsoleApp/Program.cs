/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Vehicle Class Library
 * Activity 1
 * References:
 */

//------------------------------------------------------
// Start of the Main Method
//------------------------------------------------------

// Print a welcome message to the user

Console.WriteLine("Welcome to the Vehicle Shop! To begin, please create " +
    "a selection of vehicles and add them the inventory. Once the inventory " +
    "is populated, you can proceed by adding vehicles to your cart. Finally, when " +
    "you are ready to complete your purchase, proceed to the checkout where your " +
    "total bill will be calculated.");

//------------------------------------------------------
// End of the Main Method
//------------------------------------------------------

// Read an integer input from user
static int ReadChoice()
{
    // Declare and Initialize
    // Set input as a nullable reference type
    string? input = "";
    int choice = -1;

    // Loop until the user enters a valid choice
    while (choice == -1)
    {
        // Print the users options
        Console.WriteLine("Chose an action:" +
            "/n0) Quit" +
            "/n1) Print the Inventory" +
            "/n2) Print the Shopping Cart" +
            "/n3) Create a Vehicle" +
            "/n4) Add a Vehicle to the Shopping Cart" +
            "/n5) Checkout." +
            "/n6) Save inventory to a text file." +
            "/n7) Load inventory from a text file." +
            "/nInput: ");
        // Read the user input
        input = Console.ReadLine();
        // Make sure the user entered a value
        if (!string.IsNullOrEmpty(input))
        {
            try
            { 
                // Parse the input from the user to the choice variable
                choice = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please enter a valid number. The number you entered was either too small or too large.");
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was an exception " + exp + ". Please try again.");
            }
        }
    // Return the users input
    return choice;
}