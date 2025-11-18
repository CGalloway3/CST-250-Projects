/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 4
 * References:
 */

using MinesweeperGUIApp.Models.Enums;
using MinesweeperGUIApp.Models;
using System.Drawing;
using System.Security.Claims;

namespace MinesweeperGUIApp.Services.BusinessLogicLayer
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
            // Store the users choice in the cell variable
            CellModel cell = _board.Cells[row, col];
            // Set the game as in progress
            _board.GameState = GameState.InProgress;

            switch (choice) // What action did the user choose
            {
                case 1: // User choose Visit
                    VisitCell(cell);
                    break;

                case 2: // User choose Flag
                    FlagCell(cell);
                    break;

                case 3: // User Choose User Reward
                    UseSpecialBonus(cell); // Use Reward
                    break;

                default:
                    break;
            }

            // Was this the very last cell and have we NOT! lost already?
            if (CountRemainingMoves() == 0 && _board.GameState != GameState.Lost)
            {
                _board.GameState = GameState.Won; // If we uncovered everything we just return the win. nothing else matters
            }
        }   

        /// <summary>
        /// Method to handle cell visit cases
        /// </summary>
        /// <param name="cell"></param>
        public void VisitCell(CellModel cell)
        {
            // Check if we have already been here
            if (cell.IsVisited)
            {
                return;
            }

            // Check for bomb
            if (cell.IsBomb)
            {
                // We visited a bomb game lost
                cell.IsVisited = true; // Added in milestone 4 because a bomb was not showing up if clicked by the user
                _board.GameState = GameState.Lost;
                return;
            }

            if (cell.NumberOfBombNeighbors == 0)
            {
                // Fill the empty region
                FloodFill(cell.Row, cell.Column);
                return;
            }
            
            cell.IsVisited = true;

            // Hand out the reward if one is located
            if (_board.Cells[cell.Row, cell.Column].HasSpecialReward == true)
            {
                ClaimReward(cell.Row, cell.Column);
            }
        }

        /// <summary>
        /// Method to handle cell flagging cases
        /// </summary>
        /// <param name="cell"></param>
        public void FlagCell(CellModel cell)
        {
            // Are there bombs still on the board or are we removing a possibly incorrect flag
            if (_board.NumberOfBombs > 0 && !cell.IsVisited || cell.IsFlagged)
            {
                // Flip flop the flag state
                cell.IsFlagged = !cell.IsFlagged;

                // Update bomb count and is visited property based on our displayed flags
                if (cell.IsFlagged && !cell.IsVisited)
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
            else if (cell.IsVisited)
            {
                MessageBox.Show(" You can't flag an revealed cell. ");
            }
            else
            {
                MessageBox.Show(" You are out of flags. ");
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
                MessageBox.Show("That cell does have a bomb");
            }
            else
            {
                MessageBox.Show("That cell does not have a bomb");
            }
            Console.ResetColor();
            _board.RewardsRemaining--;
        }

        /// <summary>
        /// Not yet implemented
        /// </summary>
        public void DetermineFinalScore()
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
        
        /// <summary>
        /// Flood fill algorithm for filling unoccupied squares
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void FloodFill(int row, int col)
        {
            // Bounds Check
            if ( row < 0 || row > _board.Size - 1 || col < 0 || col > _board.Size - 1 )
            {
                return; // Not a valid cell
            }

            // Already visited
            if (_board.Cells[row, col].IsVisited == true )
            {
                return; // Cell has already been probed (visited)
            }

            // Numbers Check, cell has bomb neighbors?
            if (_board.Cells[ row, col ].NumberOfBombNeighbors > 0 )
            {
                // Mark the cell as visited
                _board.Cells[row, col].IsVisited = true;                
                
                // Hand out the reward if one is located
                if (_board.Cells[row, col].HasSpecialReward == true)
                {
                    ClaimReward(row, col);                    
                }

                return; // No more automatic neighbor probing because it could be a bomb.
            }

            // New Valid cell begin recursion logic
            // Mark the cell as visited
            _board.Cells[ row, col ].IsVisited = true;          

            // Hand out the reward if one is located
            if ( _board.Cells[row, col].HasSpecialReward == true )
            {
                ClaimReward(row, col);                
            }

            // Go north west
            FloodFill(row - 1, col - 1);
            // Go north
            FloodFill(row - 1, col);
            // Go north east
            FloodFill(row - 1, col + 1);
            // Go west
            FloodFill(row, col - 1);
            // Go east
            FloodFill(row, col + 1);
            // Go south west
            FloodFill(row + 1, col - 1);
            // Go south
            FloodFill(row + 1, col);
            // Go south east
            FloodFill(row + 1, col + 1);
        }

        /// <summary>
        /// Method for setting all the flags when a reward is found
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void ClaimReward(int row, int col)
        {
            // Set Flags
            _board.RewardsRemaining++;
            _board.GameState = GameState.RewardFound;
            _board.Cells[row,col].HasSpecialReward = false;
        }
    }
}
