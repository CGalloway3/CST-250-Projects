/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 10/26/2025
 * Mine Sweeper Class Library
 * Milestone 1
 * References:
 */

using MineSweeperClassLibrary.Models;
using System.Drawing;

namespace MineSweeperClassLibrary.BusinessLogicLayer
{
    public class BoardLogic
    {
        private BoardModel _board;
        public BoardLogic(int size)
        {
            _board = new BoardModel(size);
        }

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
        }

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

        public string DetermineGameState()
        {
            // Implement game state determination logic here
            return string.Empty;
        }   

        public void UseSpecialBonus()
        {
            // Implement special bonus logic here
        }

        public void DetermineFinalSocre()
        {
            // Implement final score calculation here
        }
    }
}
