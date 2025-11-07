/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/09/2020
 * Greatest Common Divisor Recursion
 * Activity 3 Part 3
 * References:
 */

using GreatestCommonDivisorRecursion.Services.BusinessLogicLayer;

#region MainMethod()
//-----------------------------------------------
// Start of the Main Method
//-----------------------------------------------

#region Variable Declaration
// Declare and Initialize
int[] numbers;
int usersInput = 0, result = 0;
DivisorLogic _logic = new DivisorLogic();

// Additional Time tracking variables
DateTime blockStart = DateTime.Now;
DateTime blockEnd = DateTime.Now;
TimeSpan blockTime;

// A total time holder for each type of operation whether recursion, iteration, or counting from one
TimeSpan totalIterationIterationTime = TimeSpan.Zero;
TimeSpan totalIterationRecursionTime = TimeSpan.Zero;
TimeSpan totalIterationCountingTime = TimeSpan.Zero;
TimeSpan totalRecursionRecursionTime = TimeSpan.Zero;
TimeSpan totalRecursionIterationTime = TimeSpan.Zero;
TimeSpan totalRecursionCountingTime = TimeSpan.Zero;
#endregion

#region Get Users Input
// Get all the numbers from the user
// How many numbers?
Console.Write("How many numbers do you want to use?: ");
usersInput = Utility.ReadIntOnlyInputFromConsole();

// Catch negative numbers for amount
while (usersInput < 0)
{
    Console.Write("Please enter a positive number for the amount:");
    usersInput = Utility.ReadIntOnlyInputFromConsole();
}

// Initialize numbers array
numbers = new int[usersInput];

// What are all the numbers (allow zero and negatives)
Console.WriteLine("Please enter each number: ");
for (int i = 0; i < usersInput; i++)
{
    Console.Write($"Number {i + 1}: ");
    numbers[i] = Utility.ReadIntOnlyInputFromConsole();
}
#endregion

#region Timing Blocks
#region Preliminary Untimed Execution Block
//----------------------------------------------
// Start Preliminary Untimed Execution Block
//----------------------------------------------

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Starting to process the solution using iteration for depth and recursion for solution");
blockStart = DateTime.Now;
result = _logic.SolveRecursiveGCD(numbers);
blockEnd = DateTime.Now;
blockTime = blockEnd - blockStart;
// Print the result to the user
Console.WriteLine($"Using iteration for depth and recursion for solution is {result}, it took {blockTime.TotalMilliseconds}");

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Starting to process the solution using iteration for depth and iteration for solution");
blockStart = DateTime.Now;
result = _logic.SolveIterativeGCD(numbers);
blockEnd = DateTime.Now;
blockTime = blockEnd - blockStart;
// Print the result to the user
Console.WriteLine($"Using iteration for depth and iteration for solution is {result}, it took {blockTime.TotalMilliseconds}");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Starting to process the solution using iteration for depth and counting for solution");
blockStart = DateTime.Now;
result = _logic.SolveCountingGCD(numbers);
blockEnd = DateTime.Now;
blockTime = blockEnd - blockStart;
// Print the result to the user
Console.WriteLine($"Using iteration for depth and counting for solution is {result}, it took {blockTime.TotalMilliseconds}");

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("Starting to process the solution using recursion for depth and recursion for solution");
blockStart = DateTime.Now;
result = _logic.arrayRecursionSolution(numbers, 0);
blockEnd = DateTime.Now;
blockTime = blockEnd - blockStart;
// Print the result to the user
Console.WriteLine($"Using recursion for depth and recursion for solution is {result}, it took {blockTime.TotalMilliseconds}");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Starting to process the solution using recursion for depth and iteration for solution");
blockStart = DateTime.Now;
result = _logic.arrayIterationSolution(numbers, 0);
blockEnd = DateTime.Now;
blockTime = blockEnd - blockStart;
// Print the result to the user
Console.WriteLine($"Using recursion for depth and iteration for solution is {result}, it took {blockTime.TotalMilliseconds}");

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Starting to process the solution using recursion for depth and counting for solution");
blockStart = DateTime.Now;
result = _logic.arrayCountingSolution(numbers, 0);
blockEnd = DateTime.Now;
blockTime = blockEnd - blockStart;
// Print the result to the user
Console.WriteLine($"Using recursion for depth and counting for solution is {result}, it took {blockTime.TotalMilliseconds}");

Console.ResetColor();

Console.WriteLine("Preliminary method loading completed start tracking times of execution.");

//-----------------------------------------------
// End Preliminary Untimed Execution Block
//-----------------------------------------------  
#endregion

#region Timed Execution Block #1
//----------------------------------------------
// Start Timed Execution Block #1
//----------------------------------------------

RecursionCounting();

IterationCounting();

IterationRecursion();

IterationIteration();

RecursionRecursion();

RecursionIteration();

//-----------------------------------------------
// End Timed Execution Block #1
//-----------------------------------------------
#endregion

#region Timed Execution Block #2
//----------------------------------------------
// Start Timed Execution Block #2
//----------------------------------------------

IterationIteration();

RecursionCounting();

IterationCounting();

RecursionRecursion();

RecursionIteration();

IterationRecursion();

//-----------------------------------------------
// End Timed Execution Block #2
//-----------------------------------------------
#endregion

#region Timed Execution Block #3
//----------------------------------------------
// Start Timed Execution Block #3
//----------------------------------------------

IterationRecursion();

RecursionRecursion();

RecursionCounting();

IterationCounting();

RecursionIteration();

IterationIteration();

//-----------------------------------------------
// End Timed Execution Block #3
//-----------------------------------------------
#endregion

#region Timed Execution Block #4
//----------------------------------------------
// Start Timed Execution Block #4
//----------------------------------------------

IterationRecursion();

IterationIteration();

RecursionIteration();

RecursionCounting();

IterationCounting();

RecursionRecursion();

//-----------------------------------------------
// End Timed Execution Block #4
//----------------------------------------------- 
#endregion

#region Timed Execution Block #5
//----------------------------------------------
// Start Timed Execution Block #5
//----------------------------------------------

IterationCounting();

RecursionCounting();

RecursionIteration();

IterationRecursion();

IterationIteration();

RecursionRecursion();

//-----------------------------------------------
// End Timed Execution Block #5
//----------------------------------------------- 
#endregion

#region Timed Execution Block #6
//----------------------------------------------
// Start Timed Execution Block #6
//----------------------------------------------

RecursionRecursion();

IterationCounting();

IterationRecursion();

RecursionCounting();

IterationIteration();

RecursionIteration();

//-----------------------------------------------
// End Timed Execution Block #6
//----------------------------------------------- 
#endregion

#region Timed Execution Block #7
//----------------------------------------------
// Start Timed Execution Block #7
//----------------------------------------------

IterationIteration();

IterationRecursion();

IterationCounting();

RecursionRecursion();

RecursionCounting();

RecursionIteration();

//-----------------------------------------------
// End Timed Execution Block #7
//----------------------------------------------- 
#endregion

#region Timed Execution Block #8
//----------------------------------------------
// Start Timed Execution Block #8
//----------------------------------------------

RecursionCounting();

IterationRecursion();

RecursionRecursion();

IterationCounting();

IterationIteration();

RecursionIteration();

//-----------------------------------------------
// End Timed Execution Block #8
//----------------------------------------------- 
#endregion

#region Timed Execution Block #9
//----------------------------------------------
// Start Timed Execution Block #9
//----------------------------------------------

RecursionIteration();

RecursionCounting();

IterationIteration();

RecursionRecursion();

IterationCounting();

IterationRecursion();

//-----------------------------------------------
// End Timed Execution Block #9
//----------------------------------------------- 
#endregion

#region Timed Execution Block #10
//----------------------------------------------
// Start Timed Execution Block #10
//----------------------------------------------

RecursionIteration();

RecursionRecursion();

RecursionCounting();

IterationIteration();

IterationRecursion();

IterationCounting();

//-----------------------------------------------
// End Timed Execution Block #10
//----------------------------------------------- 
#endregion 
#endregion

#region Results Output
// Display all the results to the user
Console.WriteLine($"You entered {usersInput} numbers");
Console.Write("They were: ");
// Run through all the numbers the user entered.
for (int i = 0; i < numbers.Length; i++)
{
    Console.Write($"{numbers[i]}, ");
}
Console.WriteLine("");

//==========================================================================================
// Display the Greatest Common Divisor result (arguably the entire reason we are doing this)
Console.WriteLine($"The greatest common divisor for these numbers was {result}");
//==========================================================================================

// Display the timings for each type of execution arrangement (color coded to match the execution)
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"The time taken doing iteration depth and iteration solution was {totalIterationIterationTime.TotalSeconds} seconds or {totalIterationIterationTime.TotalMilliseconds} milliseconds");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"The time taken doing iteration depth and recursion solution was {totalIterationRecursionTime.TotalSeconds} seconds or {totalIterationRecursionTime.TotalMilliseconds} milliseconds");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine($"The time taken doing iteration depth and counting solution was {totalIterationCountingTime.TotalSeconds} seconds or {totalIterationCountingTime.TotalMilliseconds} milliseconds");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"The time taken doing recursion depth and iteration solution was {totalRecursionIterationTime.TotalSeconds} seconds or {totalRecursionIterationTime.TotalMilliseconds} milliseconds");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"The time taken doing recursion depth and recursion solution was {totalRecursionRecursionTime.TotalSeconds} seconds or {totalRecursionRecursionTime.TotalMilliseconds} milliseconds");
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine($"The time taken doing recursion depth and counting solution was {totalRecursionCountingTime.TotalSeconds} seconds or {totalRecursionCountingTime.TotalMilliseconds} milliseconds");
Console.ResetColor();
#endregion

//-----------------------------------------------
// End of the Main Method
//----------------------------------------------- 
#endregion

#region Functions
//-----------------------------------------------
// Start of the functions
//----------------------------------------------- 

/// <summary>
/// Simple function to handle running recursive array traversal and iterative GCD solving
/// </summary>
void RecursionIteration()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Starting to process the solution using recursion for depth and iteration for solution");
    blockStart = DateTime.Now;
    result = _logic.arrayIterationSolution(numbers, 0);
    blockEnd = DateTime.Now;
    blockTime = blockEnd - blockStart;
    totalRecursionIterationTime = totalRecursionIterationTime + blockTime;
    // Print the result to the user
    Console.WriteLine($"Using recursion for depth and iteration for solution is {result}, it took {blockTime.TotalMilliseconds}");
    Console.ResetColor();
}

/// <summary>
/// Simple function to handle running recursive array traversal and recursive GCD solving
/// </summary>
void RecursionRecursion()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("Starting to process the solution using recursion for depth and recursion for solution");
    blockStart = DateTime.Now;
    result = _logic.arrayRecursionSolution(numbers, 0);
    blockEnd = DateTime.Now;
    blockTime = blockEnd - blockStart;
    totalRecursionRecursionTime = totalRecursionRecursionTime + blockTime;
    // Print the result to the user
    Console.WriteLine($"Using recursion for depth and recursion for solution is {result}, it took {blockTime.TotalMilliseconds}");
    Console.ResetColor();
}

/// <summary>
/// Simple function to handle running recursive array traversal and counting GCD solving
/// </summary>
void RecursionCounting()
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("Starting to process the solution using recursion for depth and counting for solution");
    blockStart = DateTime.Now;
    result = _logic.arrayCountingSolution(numbers, 0);
    blockEnd = DateTime.Now;
    blockTime = blockEnd - blockStart;
    totalRecursionCountingTime = totalRecursionCountingTime + blockTime;
    // Print the result to the user
    Console.WriteLine($"Using recursion for depth and  counting for solution is {result}, it took {blockTime.TotalMilliseconds}");
    Console.ResetColor();
}

/// <summary>
/// Simple function to handle running iterative array traversal and iterative GCD solving
/// </summary>
void IterationIteration()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Starting to process the solution using iteration for depth and iteration for solution");
    blockStart = DateTime.Now;
    result = _logic.SolveIterativeGCD(numbers);
    blockEnd = DateTime.Now;
    blockTime = blockEnd - blockStart;
    totalIterationIterationTime = totalIterationIterationTime + blockTime;
    // Print the result to the user
    Console.WriteLine($"Using iteration for depth and iteration for solution is {result}, it took {blockTime.TotalMilliseconds}");
    Console.ResetColor();
}

/// <summary>
/// Simple function to handle running iterative array traversal and recursive GCD solving
/// </summary>
void IterationRecursion()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Starting to process the solution using iteration for depth and recursion for solution");
    blockStart = DateTime.Now;
    result = _logic.SolveRecursiveGCD(numbers);
    blockEnd = DateTime.Now;
    blockTime = blockEnd - blockStart;
    totalIterationRecursionTime = totalIterationRecursionTime + blockTime;
    // Print the result to the user
    Console.WriteLine($"Using iteration for depth and recursion for solution is {result}, it took {blockTime.TotalMilliseconds}");
    Console.ResetColor();
}

/// <summary>
/// Simple function to handle running iterative array traversal and counting GCD solving
/// </summary>
void IterationCounting()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Starting to process the solution using iteration for depth and counting for solution");
    blockStart = DateTime.Now;
    result = _logic.SolveCountingGCD(numbers);
    blockEnd = DateTime.Now;
    blockTime = blockEnd - blockStart;
    totalIterationCountingTime = totalIterationCountingTime + blockTime;
    // Print the result to the user
    Console.WriteLine($"Using iteration for depth and  counting for solution is {result}, it took {blockTime.TotalMilliseconds}");
    Console.ResetColor();
}

//-----------------------------------------------
// End of the functions
//----------------------------------------------- 

#endregion

#region Utility Class
//-----------------------------------------------
// Start of the Utility Class
//-----------------------------------------------

public class Utility
{

    /// <summary>
    /// Read integer input from the console.
    /// </summary>
    /// <returns></returns>
    internal static int ReadIntOnlyInputFromConsole()
    {
        // Declare and Initialize
        string input = ""; // Temporary storage of the entered text
        int number = 0;    // Storage for the return value

        // Get the current input
        input = Console.ReadLine();

        // Check if the input is a valid int
        while (!int.TryParse(input, out number))
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
// End of the Utility Class
//----------------------------------------------- 
#endregion