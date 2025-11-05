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

using System.Web;

int choice = 0, result = 0;
string input = "";

// Prompt the user for a number
Console.Write("Enter a positive number: ");
// Get the users input
input = Console.ReadLine();

// See if the user entered valid input
while (!int.TryParse(input, out choice))
{
    // Display error
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Invalid number");
    Console.ResetColor();

    // Re-prompt the user for a number
    Console.Write("Enter a positive number: ");

    // Get the user input
    input = Console.ReadLine();
}
// Call the CountToOne
Utility.ResetCallCount();
result = Utility.CountToOne(choice);
Console.WriteLine($"The end number is {result}");
Console.WriteLine($"The number {choice} took {Utility.GetCount()} calls to reduce to one.");

//==================================================
// End of the Main Method
//==================================================



//==================================================
// Start of the Utility class
//==================================================
static class Utility
{
    // Declare and Initialize
    static int callCount = 0;
    static int OddNumberShiftValue = 0;
    
    /// <summary>
    /// Count to one using recursion
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    internal static int CountToOne(int num)
    {
        // increment call counter
        callCount++;
        // Print out the current number
        Console.WriteLine($"The current number is {num}");
        
        // Toggle odd number modifier (shift value) between plus one and minus one depending on the value of num
        if (num > 0)
        {
            OddNumberShiftValue = -1; 
        }
        else
        {
            OddNumberShiftValue = 1;
        }

        // Check if the number is 0: Base Case
        if (num == 0)
        {
            return 0;
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
                Console.WriteLine("The number is odd. Shifting 1 number closer to zero");
                // Add 1 and call the function (recursion)
                return CountToOne(num + OddNumberShiftValue);
            }
        } 
    }

    internal static int GetCount()
    {
        return callCount;   
    }

    internal static void ResetCallCount()
    {
        callCount = 0;
    }
}
