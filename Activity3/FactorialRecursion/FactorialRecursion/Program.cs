/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/09/2020
 * Factorial recursion
 * Activity 3 Part 2
 * References:
 */

//-----------------------------------------------
// Start of the Main Method
//-----------------------------------------------

// Declare and Initialize
using FactorialRecursion.Services.BusinessLogicLayer;
using System.Numerics;

FactorialLogic factorialLogic = new FactorialLogic();
int input = 0;
BigInteger iterativeAns = 0, recursiveAns = 0;

// Prompt the user
Console.Write("Enter a positive number: ");

// Get the users input
input = Utility.ReadIntFromConsole();

// Solve the factorial using iteration
Console.WriteLine("Solving the factorial using iteration...");
iterativeAns = factorialLogic.SolveIterativeFactorial(input);
Console.WriteLine($"Answer: {iterativeAns}");

// Solve the factorial using recursion
Console.WriteLine("Solving the factorial using recursion...");
recursiveAns = factorialLogic.SolveRecursiveFactorial(input);
Console.WriteLine($"Answer: {recursiveAns}");

//-----------------------------------------------
// End of the Main Method
//-----------------------------------------------


//-----------------------------------------------
// Start of the Utility class
//-----------------------------------------------

/// <summary>
/// Read integer input from the console
/// </summary>
/// <returns></returns>
static class Utility
{
    internal static int ReadIntFromConsole()
    {
        // Declare and Initialize
        string input = "";
        int number = -1;

        // Get the current input
        input = Console.ReadLine();

        // Check if the input is valid
        while ( !(int.TryParse(input, out number) && number >0) )
        {
            // Show the user an error message and prompt them again
            Console.WriteLine("Invalid input. Please try again: ");

            // Get the new input
            input = Console.ReadLine();
        }

        // Return the resulting integer from the user
        return number;
    }
}

//-----------------------------------------------
// End of the Utility class
//-----------------------------------------------


