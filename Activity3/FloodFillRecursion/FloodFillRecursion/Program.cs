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
int startRow = -1, startCol = -1;

// Print the board to the console
Utility.PrintBoard(board);

// Prompt the user for the starting row (1 - 20)
Console.Write("Enter the row to start the flood fill at: ");
// Remove 1 from the input to get 0-19 range for row
startRow = Utility.ReadIntFromConsole() - 1;

// Prompt the user for the starting column (1 - 20)
Console.Write("Enter the column to start the flood fill at: ");
// Remove 1 from the input to get 0-19 range for col
startCol = Utility.ReadIntFromConsole() - 1;

// Call the flood fill method using the board
board = Utility.FloodFill(board, startRow, startCol);
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
    /// <summary>
    /// Print the board to the console
    /// </summary>
    /// <param name="board"></param>
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
                else if (board.Grid[row, col].Contents == "F")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(" ~ ");
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
        Console.ResetColor();
    }

    /// <summary>
    /// Perform a flood fill algorithm on the given row and col
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    internal static BoardModel FloodFill(BoardModel board, int row, int col)
    {
        // Declare and Initialize
        int sleepCount = 100; // milliseconds

        // Change text color to white
        Console.ForegroundColor = ConsoleColor.White;
        // Print the current cell to the console
        Console.Write($"location {row+1, 2}, {col+1, 2}: ");
        // Pause the program for sleepCount number of milliseconds
        Thread.Sleep(sleepCount);

        // Check if the cell is on the board
        if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
        {
            // Print a message indicating the cell is out of bounds
            Console.WriteLine("Out of bounds. Stop");
            // Pause the program for sleepCount number of milliseconds
            Thread.Sleep(sleepCount);

            // If the cell is not on the board, end the method
            return board;
        }

        // If the cell is a wall, end the method
        if (board.Grid[row, col].Contents == "W")
        {
            // Print a message indicating the cell is a wall
            Console.WriteLine("Hit a wall. Stop");
            // Pause the program for sleepCount number of milliseconds
            Thread.Sleep(sleepCount);

            return board;
        }

        // If the cell has already been filled, end the method
        else if (board.Grid[row, col].Contents == "F")
        {
            // Print a message indicating the cell already filled
            Console.WriteLine("Already Filled. Stop");
            // Pause the program for sleepCount number of milliseconds
            Thread.Sleep(sleepCount);

            return board;
        }

        // Else, fill the cell
        else
        {
            board.Grid[row, col].Contents = "F";
            // Print a message indicating the cell is filling up
            Console.Write("Filling");
            // Pause the program for sleepCount number of milliseconds
            Thread.Sleep(sleepCount + sleepCount);
            Console.Write(".");
            // Pause the program for sleepCount number of milliseconds
            Thread.Sleep(sleepCount + sleepCount);
            Console.Write(".");
            // Pause the program for sleepCount number of milliseconds
            Thread.Sleep(sleepCount + sleepCount);
            Console.WriteLine(".");
            // Pause the program for sleepCount number of milliseconds
            Thread.Sleep(sleepCount + sleepCount);
        }

        // Improve the visual effect of the flood fill
        // Comment out to have program history
        // Console.Clear();

        // Print the current board
        Console.WriteLine();
        PrintBoard(board);

        // Print a message indicating the next flood fill direction
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("North to: ");
        // Call the flood fill method to the north
        board = FloodFill(board, row - 1, col);

        // Print a message indicating the next flood fill direction
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("East to:  ");
        // Call the flood fill method to the east
        board = FloodFill(board, row, col + 1);

        // Print a message indicating the next flood fill direction
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("South to: ");
        // Call the flood fill method to the south
        board = FloodFill(board, row + 1, col);

        // Print a message indicating the next flood fill direction
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("West to:  ");
        // Call the flood fill method to the west
        board = FloodFill(board, row, col - 1);

        // Return the board
        return board;
    } // End of FloodFill method

    /// <summary>
    /// Read an integer number from the console
    /// </summary>
    /// <returns></returns>
    internal static int ReadIntFromConsole()
    {
        // Declare and initialize
        int num = -1;

        // Check if the current input is valid
        while (!int.TryParse(Console.ReadLine(), out num))
        {
            // Inform the user of invalid input and prompt the user again
            Console.Write("Invalid input. Please enter an integer: ");
        }
        // Return the integer from the user
        return num;
    }
}
//---------------------------------------------
// Start of the Utility class
//---------------------------------------------