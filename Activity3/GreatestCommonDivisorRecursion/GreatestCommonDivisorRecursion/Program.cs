/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/09/2020
 * Greatest Common Divisor Recursion
 * Activity 3 Part 3
 * References:
 */

//-----------------------------------------------
// Start of the Main Method
//-----------------------------------------------



//-----------------------------------------------
// End of the Main Method
//-----------------------------------------------




//-----------------------------------------------
// Start of the Utility Class
//-----------------------------------------------

public class Utility
{
    internal static int GreatestCommonDivisor(int num1, int num2)
    {
        // Declare and Initialize
        int remainder = 0;

        // Base Case: num2 = 0
        if (num1 == 0 || num2 == 0)
        {
            // Return the greatest common divisor
            return num1;
        }
        else
        {
            // Get the remainder of dividing num1 and num2
            remainder = num1 % num2;
            // Print an update to the user
            Console.WriteLine($"Not yet. The remainder of {num1} and {num2} is {remainder}.");
            // Call the recursive function of the second number and the remainder
            return GreatestCommonDivisor(num2, remainder);
        }
    }
}

//-----------------------------------------------
// End of the Utility Class
//-----------------------------------------------