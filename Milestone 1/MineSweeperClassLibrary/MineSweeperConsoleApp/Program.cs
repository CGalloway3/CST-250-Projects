/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Mine Sweeper Class Library
 * Milestone 1
 * References:
 */

using MineSweeperClassLibrary.BusinessLogicLayer;
using MineSweeperClassLibrary.Models;

//------------------------------------------------------
// Start of the Main Method
//------------------------------------------------------

// Some variable setup this will be moved to a user input loop later.
BoardLogic board1 = new BoardLogic(10);
board1.SetDifficulty(3);
board1.SetupBombs();
board1.CountBombsNearby();
BoardLogic board2 = new BoardLogic(15);
board2.SetDifficulty(3);
board2.SetupBombs();
board2.CountBombsNearby();

// Print a welcome message to the user
Console.WriteLine("Welcome to Mine Sweeper Console Application!");

// Call the PrintHeaders() function to start the program running
PrintHeaders(board1, board2);

//------------------------------------------------------
// End of the Main Method
//------------------------------------------------------

// Prepare text for printing the headers for each board
static void PrintHeaders(BoardLogic b1, BoardLogic b2)
{
    // Print out the first board key
    Console.WriteLine("Here is the answer key for the first board, size " + b1.GetBoardSize());
    PrintAnswers(b1);

    // Print out the second board key
    Console.WriteLine("Here is the answer key for the second board, size " + b2.GetBoardSize());
    PrintAnswers(b2);
}

// Generate board answer key and print to console
static void PrintAnswers(BoardLogic board)
{
    // Store the size for use later
    int size = board.GetBoardSize();

    // 1. Print the header row (column numbers)
    Console.Write("  "); // Spacer for the row index column
    for (int col = 0; col < size; col++)
    {
        if (col < 11)
            Console.Write($"   {col}");
        else
            Console.Write($"  {col}");
    }
    Console.WriteLine();

    // 2. Print the top border
    Console.Write("   +");
    for (int col = 0; col < size; col++)
    {
        Console.Write("---+");
    }
    Console.WriteLine();

    // 3. Loop through each row to print the board contents
    for (int row = 0; row < size; row++)
    {
        // Print the row index
        if (row < 10)
            Console.Write($" {row} |");
        else
            Console.Write($"{row} |");

        // Loop through each column in the current row
        for (int col = 0; col < size; col++)
        {
            // Get the number of bomb neighbors (or the bomb indicator value 9)
            int bombCount = board.GetCellAt(row, col).NumberOfBombNeighbors;
            string cellOutput = " . "; // Default output for 0 neighbors

            // Set color based on the cell value
            switch (bombCount)
            {
                case 0:
                    // No color change needed for '.' on the dark background
                    Console.ForegroundColor = ConsoleColor.White;
                    cellOutput = " . ";
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    cellOutput = " 1 ";
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    cellOutput = " 2 ";
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    cellOutput = " 3 ";
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    cellOutput = " 4 ";
                    break;
                case 5:
                    // Using magenta to represent a different color
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    cellOutput = " 5 ";
                    break;
                case 6:
                    // Using magenta to represent a different color
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    cellOutput = " 6 ";
                    break;
                case 7:
                    // Using magenta to represent a different color
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    cellOutput = " 7 ";
                    break;
                case 8:
                    // Using magenta to represent a different color
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    cellOutput = " 8 ";
                    break;
                case 9:
                    // Bomb ('B')
                    Console.ForegroundColor = ConsoleColor.Red;
                    cellOutput = " B ";
                    break;
                default:
                    // Handle unknown values (using black as a fallback)
                    Console.ForegroundColor = ConsoleColor.Black;
                    cellOutput = $" {bombCount} ";
                    break;
            }

            // Print the colored cell content
            Console.Write($"{cellOutput}");

            // Reset color to white before printing the vertical bar separator
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
        }

        Console.WriteLine(); // Move to the next line after printing a full row

        // Print the row separator border
        Console.Write("   +");
        for (int col = 0; col < size; col++)
        {
            Console.Write("---+");
        }
        Console.WriteLine();
    }

    // Ensure the color is reset after the board is printed
    Console.ResetColor();
}
