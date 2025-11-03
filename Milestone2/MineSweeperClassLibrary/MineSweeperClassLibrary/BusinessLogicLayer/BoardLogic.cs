/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Mine Sweeper Class Library
 * Milestone 1
 * References:
 */

using MineSweeperClassLibrary.Enums;
using MineSweeperClassLibrary.Models;
using System.Drawing;

namespace MineSweeperClassLibrary.BusinessLogicLayer
{
    public class BoardLogic
    {
        // private class level variables
        private BoardModel _board;

        /// <summary>
        /// Public Constructor that takes one param of size
        /// </summary>
        /// <param name="size"></param>
        public BoardLogic(int size)
        {
            _board = new BoardModel(size);
        }

        /// <summary>
        /// The method for setting up the bombs and rewards on the board.
        /// </summary>
        public void SetupBombs()
        {
            // Initialize Variables
            decimal bombPercentage = 0.10M; // Default to difficulty 1
            Random random = new Random((int)DateTime.Now.Ticks); // Seed random number generator

            // Determine bomb percentage based on difficulty
            switch (_board.Difficulty)
            {
                case 1:
                    bombPercentage = 0.10M;
                    break;
                case 2:
                    bombPercentage = 0.15M;
                    break;
                case 3:
                    bombPercentage = 0.25M;
                    break;
                default:
                    bombPercentage = 0.10M;
                    break;
            }

            // Calculate number of bombs
            int totalCells = _board.Size * _board.Size;
            int numberOfBombs = (int)(totalCells * bombPercentage);
            _board.NumberOfBombs = numberOfBombs;

            // Loop trough and place bombs
            for (int i = 0; i < numberOfBombs; i++)
            {
                // Calculate random position
                int row = random.Next(0, _board.Size);
                int col = random.Next(0, _board.Size);

                // Check for preexisting bomb
                if (_board.Cells[row, col].IsBomb)
                {
                    i--; // Decrement i to retry this iteration because a bomb already exists there
                }
                else
                {
                    _board.Cells[row, col].IsBomb = true; // place bomb
                }
            }

            // Calculate the number of rewards minimum of one reward
            int numberOfRewards = (int)(numberOfBombs * bombPercentage);
            if (numberOfRewards == 0)
            {
                numberOfRewards = 1;    
            }

            // loop through and place rewards
            for (int i = 0; i < numberOfRewards; i++)
            {
                // Calculate random position
                int row = random.Next(0, _board.Size);
                int col = random.Next(0, _board.Size);

                // Check for preexisting bomb we don't want rewards to remove bombs
                if (_board.Cells[row, col].IsBomb)
                {
                    i--; // Decrement i to retry this iteration because a bomb already exists there so we cant place a reward.
                }
                else
                {
                    _board.Cells[row, col].HasSpecialReward = true; // place reward
                }
            }


        }

        /// <summary>
        /// Method to count neighbor bombs
        /// </summary>
        public void CountBombsNearby()
        {
            // Define Adjustment values for comparison of a cells neighbors in row and column arrays
            int[] rowAdjustments = { -1, -1, -1,  0, 0,  1, 1, 1 };
            int[] colAdjustments = { -1,  0,  1, -1, 1, -1, 0, 1 };

            // Iterate through the cells matrix with a nested [row, col] loop of board size
            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    // set currentCell for easier access
                    CellModel currentCell = _board.Cells[row, col];

                    // Is cell a bomb itself?
                    if (currentCell.IsBomb)
                    {
                        currentCell.NumberOfBombNeighbors = 9; // Indicate cell is a bomb with 9 as per milestone instructions
                        continue; // Skip locating neighbors for bomb cells
                    }

                    // Loop 8 iterations to check all possible neighbor positions
                    for (int i = 0; i < 8; i++)
                    {
                        // Calculate neighbor position for the current i iteration using the defined Adjustment arrays
                        int neighborRow = row + rowAdjustments[i];
                        int neighborCol = col + colAdjustments[i];
                        
                        // Check if the calculated neighbor position is within the current area of play
                        if (neighborRow >= 0 && neighborRow < _board.Size && neighborCol >= 0 && neighborCol < _board.Size)
                        {
                            // If we are here the neighbor position is in the area of play

                            //Check for bomb at neighbor position
                            if (_board.Cells[neighborRow, neighborCol].IsBomb)
                            {
                                currentCell.NumberOfBombNeighbors++; // Increment number of bomb neighbors count
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Public accessor for retrieving cells at locations in the grid
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public CellModel GetCellAt(int row, int col)
        {
            return _board.Cells[row, col];
        }

        /// <summary>
        /// Public accessor for acquiring the boards size
        /// </summary>
        /// <returns></returns>
        public int GetBoardSize()
        {
            return _board.Size;
        }

        /// <summary>
        /// Sets the games difficulty
        /// </summary>
        /// <param name="difficulty"></param>
        public void SetDifficulty(int difficulty)
        {
            _board.Difficulty = difficulty;
        }

        /// <summary>
        /// Determines the results for the location and action the user picked
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="choice"></param>
        /// <returns>Returns a GameState enum</returns>
        public void DetermineGameState(int row, int col, int choice)
        {
            CellModel cell = _board.Cells[row, col];
            _board.GameState = GameState.InProgress;

            switch (choice)
            {
                case 1: // Visit
                    // We visited a bomb game lost
                    cell.IsVisited = true;
                    if (cell.IsBomb)
                    {
                        _board.GameState = GameState.Lost;
                        return; // We lost return immediately
                    }
                    if (cell.HasSpecialReward)
                    {
                        _board.RewardsRemaining++;
                        _board.GameState = GameState.RewardFound; // We are not returning cause we could find a reward on our very last move and returning would negate the win.
                    }
                    break;
                case 2: // Flag
                    // Catch too many flags used
                    if (_board.NumberOfBombs > 0 || cell.IsFlagged)
                    {
                        cell.IsFlagged = !cell.IsFlagged;
                        // Update bomb count based on our displayed flags
                        if (cell.IsFlagged)
                        {
                            _board.NumberOfBombs--;
                            cell.IsVisited = true;
                        }
                        else
                        {
                            _board.NumberOfBombs++;
                            cell.IsVisited = false;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You are out of bomb flags remove one and try again.");
                        Console.ResetColor();
                    }

                        break;
                case 3: // reward
                    UseSpecialBonus(cell); // Use Reward
                    break;
                default:
                    break;
            }
            if (CountRemainingMoves() == 0)
            {
                _board.GameState = GameState.Won; // If we uncovered everything we just return the win. nothing else matters
            }
        }   

        /// <summary>
        /// Provides functionality for special reward usage
        /// </summary>
        /// <param name="cell"></param>
        public void UseSpecialBonus(CellModel cell)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            if (cell.IsBomb)
            {
                Console.WriteLine("That cell does have a bomb");
            }
            else
            {
                Console.WriteLine("That cell does not have a bomb");
            }
            Console.ResetColor();
            _board.RewardsRemaining--;
        }

        /// <summary>
        /// Not yet implemented
        /// </summary>
        public void DetermineFinalSocre()
        {
            // Implement final score calculation here
        }

        /// <summary>
        /// Counts the remaining moves when value hits zero player has won
        /// </summary>
        /// <returns></returns>
        private int CountRemainingMoves()
        {
            int count = 0;

            foreach (CellModel cell in _board.Cells)
            {
                if (!cell.IsVisited)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// provides access to the number of bombs in the board model
        /// </summary>
        /// <returns>Number of bombs which is more of an indicator of the number of flags remaining more than anything</returns>
        public int GetNumberOfBombs()
        {
            return _board.NumberOfBombs;
        }

        /// <summary>
        /// Provides access to the number of collected rewards that are stored in the board model
        /// Note: this is unrelated to the number of uncollected rewards hidden on the board.
        /// </summary>
        /// <returns>Number of collected but unused rewards</returns>
        public int GetNumberOfRewards()
        {
            return _board.RewardsRemaining;
        }

        /// <summary>
        /// Accessor for the internal game state of the board
        /// </summary>
        /// <returns></returns>
        public GameState GetGameState()
        {
            return _board.GameState;
        }
    }
}
