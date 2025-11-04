/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/09/2020
 * Count to one recursion
 * Activity 3
 * References:
 */

//==================================================
// Start of the Main Method
//==================================================

// Declare and Initialize
int choice = 0, result = 0;
string input = "";

// Prompt the user for a number
Console.Write("Enter a positive number: ");
// Get the users input
input = Console.ReadLine();
// See if the user entered valid input
while (!int.TryParse(input, out choice) && choice > 0)
{
    Console.WriteLine("Invalid number");
    // Re-prompt the user for a number
    Console.WriteLine("Enter a positive number: ");
    // Get the user input
    input = Console.ReadLine();
}
// Call the CountToOne
result = Utility.CountToOne(choice);
Console.WriteLine($"The end number is {result}");

//==================================================
// End of the Main Method
//==================================================



//==================================================
// Start of the Utility class
//==================================================
static class Utility
{
    /// <summary>
    /// Count to one using recursion
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    internal static int CountToOne(int num)
    {
        // Print out the current number
        Console.WriteLine($"");
        // Check if the number is 1: Base Case
        if (num == 1)
        {
            return 1;
        }
        else
        {
            // Check if the number is even
            if ((num % 2) == 0)
            {
                Console.WriteLine("The number is even. Divide by 2");
                // Divide the number by 2 and call the function (recursion)
                return CountToOne(num / 2);
            }
            else
            {
                Console.WriteLine("");
                // Add 1 and call the function (recursion)
                return CountToOne(num + 1);
            }
        } 
    }
}
