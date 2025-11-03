/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Mine Sweeper Class Library
 * Milestone 1
 * References:
 */

using MineSweeperClassLibrary.BusinessLogicLayer;
using MineSweeperClassLibrary.Enums;
using MineSweeperClassLibrary.Models;
using System.Data;

//------------------------------------------------------
// Start of the Main Method
//------------------------------------------------------

//------------------------------------------------------
// Game Setup
//------------------------------------------------------

// Setup new game
Console.WriteLine("=== MINESWEEPER SETUP ===");
// get users selections for game size and difficulty
int boardSize = GetBoardSize();
int difficulty = GetDifficulty();
// Clear the console
Console.Clear();

// Print a welcome message to the user
Console.WriteLine("Welcome to Mine Sweeper Console Application!");
Console.Write($"\nBoard size: {boardSize}x{boardSize},  ");
Console.WriteLine($"Difficulty: {(difficulty == 1 ? "Low" : difficulty == 2 ? "Medium" : "High")}");
Console.WriteLine("Good Luck!!");

// Create the board
BoardLogic board = new BoardLogic(boardSize);
board.SetDifficulty( difficulty );
board.SetupBombs();
board.CountBombsNearby();

// Call the Print functions to start the program running
PrintAnswers(board);
PrintBoard(board);

// Set preliminary win and loss conditions
bool victory = false;
bool death = false;

//------------------------------------------------------
// Game Setup Completed
//------------------------------------------------------

//------------------------------------------------------
// Game Loop
//------------------------------------------------------

// Declare and Initialize
(int row, int col, int choice) inputResult = (0, 0, 0);

// Main Logic loop
while (!victory && !death)
{
    // Prompt user for next move
    Console.WriteLine($"There are still {board.GetNumberOfBombs()} bombs that are unaccounted for.");
    Console.WriteLine("What is your next move.");
    inputResult = ReceiveUsersInputs(board.GetBoardSize());
    
    // Get the result of that move from boardLogic
    board.DetermineGameState(inputResult.row, inputResult.col, inputResult.choice);
  
    // Print the Board Condition
    PrintBoard(board);

    // Dispaly the results of the Win or loss condition test.
    switch(board.GetGameState())
    {
        case GameState.InProgress: 
            Console.WriteLine("Game in Progress:");
            break;

        case GameState.Won:
            Console.WriteLine("Congratulations you have beaten the game. Well Done.");
            victory = true;
            break;

        case GameState.Lost:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("BOOM!!!");
            Console.WriteLine("          BOOM!!!");
            Console.WriteLine("    BOOM!!!");
            Console.WriteLine("  You found a bomb.  ");
            Console.WriteLine("Awe, better luck next time, you almost had it.");
            Console.ResetColor();
            death = true;
            break;

        case GameState.RewardFound:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*!* You found a reward *!*");
            Console.ResetColor();
            break;

        default:
            break;
    }
}

//------------------------------------------------------
// End of Game Loop
//------------------------------------------------------

//------------------------------------------------------
// End of the Main Method
//------------------------------------------------------

//------------------------------------------------------
// Get User input methods
//------------------------------------------------------
// Get input for board size
int GetBoardSize()
{
    int size;
    while (true)
    {
        Console.Write("Enter board size (1–100): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out size) && size > 0 && size <= 100)
            return size;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
        Console.ResetColor();
    }
}
// Get input for difficulty
int GetDifficulty()
{
    int difficulty;
    while (true)
    {
        Console.Write("Select difficulty (1 = Easy, 2 = Medium, 3 = Hard): ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out difficulty) && (difficulty >= 1 && difficulty <= 3))
            return difficulty;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
        Console.ResetColor();
    }
}
// Get cell and actions from user
(int row, int col, int choice) ReceiveUsersInputs(int size)
{
    // Declare and Initialize
    int row = -1, col = -1, choice = -1;

    // Row input
    while (true)
    {
        Console.Write("Enter row (0 - " + (size - 1) + "): ");
        if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < size)
            break;
        Console.WriteLine("Invalid input. Try again.");
    }

    // Column input
    while (true)
    {
        Console.Write("Enter column (0 - " + (size - 1) + "): ");
        if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < size)
            break;
        Console.WriteLine("Invalid input. Try again.");
    }

    // Choice input
    while (true)
    {
        // Determine if we have any rewards and act accordingly
        if (board.GetNumberOfRewards() > 0)
        {
            Console.Write("Enter choice ( 1 = Visit Cell, 2 = Flag Cell, 3 = Use Reward (Bomb Detector) ): ");
            if (int.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 2 || choice == 3))
                break;
            Console.WriteLine("Invalid input. Please enter 1, 2, or 3: ");
        }
        else
        {
            Console.Write("Enter choice ( 1 = Visit Cell, 2 = Flag Cell ): ");
            if (int.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 2))
                break;
            Console.WriteLine("Invalid input. Please enter 1 or 2: ");
        }
    }

    return (row, col, choice);
}

//---------------------------------------------------------------
// Board printing methods
//---------------------------------------------------------------
// Generate board answer key and print to console
static void PrintAnswers(BoardLogic board)
{
    // Store the size for use later
    int size = board.GetBoardSize();

    // 1. Print the header row (column numbers)
    Console.WriteLine("Here is the answer key for the board.");
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
            string cellOutput = " ? "; // Default output for not visited

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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
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
            if (board.GetCellAt(row, col).HasSpecialReward)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                cellOutput = " r ";
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
// Print current board status
static void PrintBoard(BoardLogic board)
{
    // Store the size for use later
    int size = board.GetBoardSize();

    // 1. Print the header row (column numbers)
    Console.WriteLine("Here is the current board.");
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

            // Set all cells to a default state of not visited
            string cellOutput = " ? "; // Default output for not visited
            
            // Is the cell flagged?
            if (board.GetCellAt(row, col).IsFlagged)
            {
                // YES
                cellOutput = " F "; // set the flag
            }
            else// NO
            {
                // Is the cell visited?
                if (board.GetCellAt(row, col).IsVisited)
                {
                    // YES
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
                    // NO The cell will keep the default value of not visited
                }
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
