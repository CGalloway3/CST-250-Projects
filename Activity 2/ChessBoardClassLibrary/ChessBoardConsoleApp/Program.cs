/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/02/2020
 * Chess Board Project
 * Activity 2
 * References:
 */

//-----------------------------------
// Start of Main Method
//-----------------------------------

// Print a welcome message for the user
using ChessBoardClassLibrary.Enums;
using ChessBoardClassLibrary.Models;

Console.WriteLine("Hello, Chess Players!");

//-----------------------------------
// End of Main Method
//-----------------------------------

//-----------------------------------
// Define a utility class
//-----------------------------------
public static class Utility
{
    /// <summary>
    /// Print the given board to the console
    /// </summary>
    /// <param name="board"></param>
    internal static void PrintBoard(BoardModel board)
    {
        // Loop over the rows of the board
        for (int row = 0; row < board.Size; row++)
        {
            // Loop over the columns of the board
            for (int col = 0; col < board.Size; col++)
            {
                // Get the current cell from the grid
                CellModel cell = board.Grid[row, col];
                // Check if the current cell is a legal move
                if (cell.IsLegalNextMove)
                {
                    // Print a + for a legal move
                    Console.Write(" +");
                }
                // Check if there is a piece occupying the cell
                else if (cell.PieceOccupyingCell.Type != PieceType.None)
                {
                    // Print the chess piece letter
                    Console.Write($"{cell.PieceOccupyingCell.SignifyingLetter} ");
                }
                else
                {
                    // Print a . for anything else
                    Console.Write(" .");
                }
            }
            // Start a new line after every row
            Console.WriteLine();
        }
    } // End of PrintBoard method
}