/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/02/2020
 * Chess Board Project
 * Activity 2
 * References: Maze, C., & Maze, C. (2023, September 26). Using a discard variable in C#. Code Maze. https://code-maze.com/csharp-how-to-use-discard-variable/
 *                  Used to implement the out discard of out _
 */

using ChessBoardClassLibrary.Enums;
using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;
using System.Drawing;
using System.Xml.XPath;

//-----------------------------------
// Start of Main Method
//-----------------------------------

// Declare and Initialize
string pieceType = "";
string pieceColor = "";
PieceType resultType = PieceType.None;
PieceColor resultColor = PieceColor.None;
Tuple<int, int>? result;
BoardLogic boardLogic = new BoardLogic();

// Print a welcome message for the user
Console.WriteLine("Hello, Chess Players!");

// Create a new chess board
BoardModel board = new BoardModel(8);

// Show the empty board
Utility.PrintBoard(board);

// Place a few preexisting pieces on the board to demonstrate the effectiveness
// of the MarkLegalMoves and the subsequent MarkValid moves functions for the various
// pieces. I played around with this ui for a while making sure all the pieces recorded
// correct legal moves.
board.Grid[2, 5].PieceOccupyingCell = new ChessPiece(PieceType.Rook, PieceColor.Black);
board.Grid[5, 2].PieceOccupyingCell = new ChessPiece(PieceType.King, PieceColor.Black);
board.Grid[6, 3].PieceOccupyingCell = new ChessPiece(PieceType.Bishop, PieceColor.White);
board.Grid[1, 0].PieceOccupyingCell = new ChessPiece(PieceType.Queen, PieceColor.White);
board.Grid[5, 6].PieceOccupyingCell = new ChessPiece(PieceType.Pawn, PieceColor.White);
board.Grid[2, 7].PieceOccupyingCell = new ChessPiece(PieceType.Knight, PieceColor.Black);
// Print pre filled board
Utility.PrintBoard(board);

// Prompt the user for the type of chess piece
Console.Write("Enter the type of piece you want to place (Pawn, Knight, Rook, Bishop, Queen, or King): ");
// Wait for a correct response while storing results in pieceType and resultType. The addition of int try parse is to
// force errors in the entry value when integers are entered because in enums, an int is a valid entry.
// (PieceType.Pawn == 1) will evaluate to true so I need to prevent integers from being entered on these lines.
// out _ simply discards the out value
while (int.TryParse((pieceType = Console.ReadLine()), out _) || (resultType = PieceTypeConverter.ConvertStringToPieceType(pieceType)) == PieceType.None) // While int or non valid entry, loop
{            
    // Display user message if input is invalid                   
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($"Invalid input. {pieceType} is not a valid piece type. \nPlease enter a Valid chess piece type: ");
    Console.ResetColor();
}

// Prompt the user for the color of chess piece
Console.Write("Enter the color (Black or White): ");
// Wait for a correct response while storing results in pieceColor and resultColor. The addition of int try parse is to
// force errors in the entry value when integers are entered because in enums, an int is a valid entry.
// (PieceColor.Black == 1) will evaluate to true so I need to prevent integers from being entered on these lines.
// out _ simply discards the out value
while (int.TryParse((pieceColor = Console.ReadLine()), out _) || (resultColor = PieceColorConverter.ConvertStringToPieceColor(pieceColor)) == PieceColor.None) // While int or non valid entry, loop
{
    // Display user message if input is invalid                   
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($"Invalid input. {pieceColor} is not a valid piece color. \nPlease enter a Valid chess piece color: ");
    Console.ResetColor();
}

// Prompt the user for the location of the chess piece
result = Utility.GetRowAndCol();

// Mark the legal moves based on the input
board = boardLogic.MarkLegalMoves(board, board.Grid[result.Item1, result.Item2], resultType, resultColor);

// Print out the new chess board
Utility.PrintBoard(board);

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
        // Print the header row (column numbers)
        Console.Write("  "); // Spacer for the row index column
        for (int col = 0; col < board.Size; col++)
        {            
            Console.Write($"   {col}");          
        }
        Console.WriteLine();

        // Print the top border
        Console.Write("   +");
        for (int col = 0; col < board.Size; col++)
        {
            Console.Write("---+");
        }
        Console.WriteLine();

        // Loop over the rows of the board
        for (int row = 0; row < board.Size; row++)
        {
            // Print the row index
            Console.Write($" {row} |");

            // Loop over the columns of the board
            for (int col = 0; col < board.Size; col++)
            {
                // Get the current cell from the grid
                CellModel cell = board.Grid[row, col];
                // Check if the current cell is a legal move
                if (cell.IsLegalNextMove)
                {
                    // Print a + for a legal move
                    // if the move is an over take of an enemy piece mark it as red.
                    if (cell.PieceOccupyingCell.Type != PieceType.None)
                    { 
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(" + ");
                    Console.ResetColor();
                }
                // Check if there is a piece occupying the cell
                else if (cell.PieceOccupyingCell.SignifyingLetter != "")
                {
                    // Print the chess piece letter
                    if (cell.PieceOccupyingCell.Color == PieceColor.White)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.Write($" {cell.PieceOccupyingCell.SignifyingLetter} ");
                    Console.ResetColor();
                }
                else
                {
                    // Print a . for anything else
                    Console.Write(" . ");
                }
                Console.Write("|");

            }
            // Start a new line after every row
            Console.WriteLine();

            // Print the row separator border
            Console.Write("   +");
            for (int col = 0; col < board.Size; col++)
            {
                Console.Write("---+");
            }
            Console.WriteLine();
        }
    } // End of PrintBoard method

    /// <summary>
    /// Get the row and column for the piece
    /// </summary>
    /// <returns></returns>
    internal static Tuple<int, int> GetRowAndCol()
    {
        // Declare and initialize
        int row = -1;
        int col = -1;

        // Get the row from the user
        Console.Write("Enter the row number of the piece: ");
        // wait for the correct response
        while (!(int.TryParse(Console.ReadLine(), out row) && row >= 0 && row <= 7))
        {
            // Display user message if input is invalid                   
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Invalid input. Please enter a number between 0 and 7: ");
            Console.ResetColor();
        }

        // Get the column from the user
        Console.Write("Enter the column number of the piece: ");
        //wait for the correct response
        while (!(int.TryParse(Console.ReadLine(), out col) && col >= 0 && col <= 7))
        {
            // Display user message if input is invalid                   
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Invalid input. Please enter a number between 0 and 7: ");
            Console.ResetColor();
        }

        // Return the data
        return Tuple.Create(row, col);
    }
}
