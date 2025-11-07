/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/09/2020
 * Flood Fill Recursion
 * Activity 3 Part 4
 * References:
 */

using FloodFillRecursion.Models;

//---------------------------------------------
// Start of the Main Method
//---------------------------------------------

// Declare and Initialize
// Create a new BoardModel
BoardModel board = new BoardModel(20, 3);

// Print the board to the console
Utility.PrintBoard(board);

//---------------------------------------------
// End of the Main Method
//---------------------------------------------


//---------------------------------------------
// Start of the Utility class
//---------------------------------------------

static class Utility
{
    internal static void PrintBoard(BoardModel board)
    {
        // Make sure the color of the column numbers is white
        Console.ForegroundColor = ConsoleColor.White;
        // Start the column numbers row with a space to keep the numbers aligned
        Console.Write(" ");
        // Loop to add column numbers for the board
        for (int colNum = 0; colNum < board.Size; colNum++)
        {
            // Print the colNum with a 2-character width
            Console.Write($" {colNum + 1, 2}");
        }
        Console.WriteLine();
        
        // loop through the rows of the board
        for (int row = 0; row < board.Size; row++)
        {
            // Print each row number in white
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write($"{row +1, 2}");

            // loop through the columns of the board
            for (int col = 0; col < board.Size; col++)
            {
                // Check if the current cell is a wall
                if (board.Grid[row, col].Contents == "W")
                {
                    // Change the text color to red
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" W ");
                }
                // Check if the current cell is an end point
                else if (board.Grid[row, col].Contents == "E")
                {
                    // Change the text color to white
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" . ");
                }
                // Otherwise, it's an empty path
                else
                {
                    Console.Write("   ");
                }
            }
            // Use a write line to start a new row
            Console.WriteLine();
        }
    }
}
//---------------------------------------------
// Start of the Utility class
//---------------------------------------------