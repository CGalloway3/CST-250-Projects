﻿/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/02/2020
 * Chess Board Project
 * Activity 2
 * References:
 */

using ChessBoardClassLibrary.Enums;
using ChessBoardClassLibrary.Models;

//-----------------------------------
// Start of Main Method
//-----------------------------------

// Declare and Initialize
string piece = "";
Tuple<int, int>? result;

// Print a welcome message for the user
Console.WriteLine("Hello, Chess Players!");

// Create a new chess board
BoardModel board = new BoardModel(8);

// Show the empty board
Utility.PrintBoard(board);

// Prompt the user for the type of chess piece
Console.Write("Enter the type of piece you want to place (Knight, Rook, Bishop, Queen, King): ");
piece = Console.ReadLine();

// Prompt the user for the location of the chess piece
result = Utility.GetRowAndCol();

// Mark the legal moves based on the input

// Print out the new chess board

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
                else if (cell.PieceOccupyingCell.SignifyingLetter != "")
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

    /// <summary>
    /// Get the row and column for the piece
    /// </summary>
    /// <returns></returns>
    internal static Tuple<int, int> GetRowAndCol()
    {
        // Get the row from the user
        Console.Write("Enter the row number of the piece: ");
        int row = int.Parse(Console.ReadLine());

        // Get the column from the user
        Console.Write("Enter the column number of the piece: ");
        int col = int.Parse(Console.ReadLine());

        // Return the data
        return Tuple.Create(row, col);
    }
}
