/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 12/07/2025
 * Mine Sweeper Class Library
 * Milestone 6
 * References:
 */

using MinesweeperClassLibrary.Models.Enums;
using MinesweeperClassLibrary.Models;
using System.Drawing;
using System.Security.Claims;
using MinesweeperClassLibrary.Models.DTOs;

namespace MinesweeperClassLibrary.Services.BusinessLogicLayer
{
    public class BoardLogic
    {
        // private class level variables
        private BoardModel _boardModel;
        private bool _isLeaderboardLoaded = false;
        private string _fileFolder = "Data";
        private string _fileName = "save.json";

        // Public properties
        public string ErrorMessage { get; private set; } = string.Empty;

        /// <summary>
        /// Public Constructor that takes one param of size
        /// </summary>
        /// <param name="size"></param>
        public BoardLogic(int size)
        {
            _boardModel = new BoardModel(size);
            ErrorMessage = string.Empty;
        }

        /// <summary>
        /// Constructor for the board logic that takes a file name as a parameter
        /// and loads that existing board model into this logic.
        /// </summary>
        /// <param name="filePath"></param>
        public BoardLogic(string filePath)
        {
            LoadGame(filePath);
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
            switch (_boardModel.Difficulty)
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
            int totalCells = _boardModel.Size * _boardModel.Size;
            int numberOfBombs = (int)(totalCells * bombPercentage);
            _boardModel.NumberOfBombs = numberOfBombs;

            // Loop trough and place bombs
            for (int i = 0; i < numberOfBombs; i++)
            {
                // Calculate random position
                int row = random.Next(0, _boardModel.Size);
                int col = random.Next(0, _boardModel.Size);

                // Check for preexisting bomb
                if (_boardModel.Cells[row][col].IsBomb)
                {
                    i--; // Decrement i to retry this iteration because a bomb already exists there
                }
                else
                {
                    _boardModel.Cells[row][col].IsBomb = true; // place bomb
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
                int row = random.Next(0, _boardModel.Size);
                int col = random.Next(0, _boardModel.Size);

                // Check for preexisting bomb we don't want rewards to remove bombs
                if (_boardModel.Cells[row][col].IsBomb)
                {
                    i--; // Decrement i to retry this iteration because a bomb already exists there so we cant place a reward.
                }
                else
                {
                    _boardModel.Cells[row][col].HasSpecialReward = true; // place reward
                }
            }


        }

        /// <summary>
        /// Method to count neighbor bombs
        /// </summary>
        public void CountBombsNearby()
        {
            // Define Adjustment values for comparison of a cells neighbors in row and column arrays
            int[] rowAdjustments = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colAdjustments = { -1, 0, 1, -1, 1, -1, 0, 1 };

            // Iterate through the cells matrix with a nested [row, col] loop of board size
            for (int row = 0; row < _boardModel.Size; row++)
            {
                for (int col = 0; col < _boardModel.Size; col++)
                {
                    // set currentCell for easier access
                    CellModel currentCell = _boardModel.Cells[row][col];

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
                        if (neighborRow >= 0 && neighborRow < _boardModel.Size && neighborCol >= 0 && neighborCol < _boardModel.Size)
                        {
                            // If we are here the neighbor position is in the area of play

                            //Check for bomb at neighbor position
                            if (_boardModel.Cells[neighborRow][neighborCol].IsBomb)
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
            return _boardModel.Cells[row][col];
        }

        /// <summary>
        /// Public accessor for acquiring the boards settings
        /// </summary>
        /// <returns></returns>
        public GameStat GetBoardSettings()
        {
            // create a holder for settings
            GameStat settings = new GameStat();

            // Configure the settings holder
            settings.BoardSize = _boardModel.Size;
            settings.Difficulty = _boardModel.Difficulty;

            // return the settings holder
            return settings;
        }

        /// <summary>
        /// Sets the games difficulty
        /// </summary>
        /// <param name="difficulty"></param>
        public void SetupBoardAtDifficulty(int difficulty)
        {
            _boardModel.Difficulty = difficulty;
            SetupBombs();
            CountBombsNearby();
        }

        /// <summary>
        /// Determines the results for the location and action the user picked
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="choice"></param>
        /// <returns>Returns a GameState enum</returns>
        public bool DetermineGameState(int row, int col, int choice)
        {
            // Start timer if not already started
            if (_boardModel.GameState == GameState.Starting)
            {
                StartGame();
            }

            // Clear any previous error messages
            ErrorMessage = string.Empty;
            // Set return value to true by default
            bool returnValue = true;
            // Store the users choice in the cell variable
            CellModel cell = _boardModel.Cells[row][col];
            // Set the game as in progress
            _boardModel.GameState = GameState.InProgress;

            switch (choice) // What action did the user choose
            {
                case 1: // User choose Visit
                    VisitCell(cell);
                    break;

                case 2: // User choose Flag
                    returnValue = FlagCell(cell);
                    break;

                case 3: // User Choose User Reward
                    returnValue = UseSpecialBonus(cell); // Use Reward
                    break;

                default:
                    break;
            }

            // Was this the very last cell and have we NOT! lost already?
            if (CountRemainingMoves() == 0 && _boardModel.GameState != GameState.Lost)
            {
                // If we uncovered everything we just return the win. nothing else matters
                DetermineFinalScore(GameState.Won);
            }

            return returnValue;
        }

        /// <summary>
        /// Method to handle cell visit cases
        /// </summary>
        /// <param name="cell"></param>
        private void VisitCell(CellModel cell)
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
                DetermineFinalScore(GameState.Lost);
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
            if (_boardModel.Cells[cell.Row][cell.Column].HasSpecialReward == true)
            {
                ClaimReward(cell.Row, cell.Column);
            }
        }

        /// <summary>
        /// Method to handle cell flagging cases
        /// </summary>
        /// <param name="cell"></param>
        private bool FlagCell(CellModel cell)
        {
            // Are there bombs still on the board or are we removing a possibly incorrect flag
            if (_boardModel.NumberOfBombs > 0 && !cell.IsVisited || cell.IsFlagged)
            {
                // Flip flop the flag state
                cell.IsFlagged = !cell.IsFlagged;

                // Update bomb count and is visited property based on our displayed flags
                if (cell.IsFlagged && !cell.IsVisited)
                {
                    _boardModel.NumberOfBombs--;
                    cell.IsVisited = true;
                }
                else
                {
                    _boardModel.NumberOfBombs++;
                    cell.IsVisited = false;
                }
            }
            else if (cell.IsVisited)
            {
                ErrorMessage = " You can't flag an revealed cell. ";
                return false;
            }
            else
            {
                ErrorMessage = " You are out of flags. ";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Provides functionality for special reward usage.
        /// Note: The calling class is responsible for checking if rewards are available.
        /// </summary>
        /// <param name="cell"></param>
        private bool UseSpecialBonus(CellModel cell)
        {
            // "Use" a reward. Decrement the reward count.
            _boardModel.RewardsRemaining--;

            // Return true if we hit a bomb otherwise false
            if (cell.IsBomb)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Converts the game state to final score as a text string.
        /// </summary>
        public void DetermineFinalScore(GameState gameState)
        {
            // Set the final game state
            _boardModel.GameState = gameState;
            // Stop the game timer
            StopGame();

            // Calculate the score
            int baseScore = _boardModel.Size * _boardModel.Size * _boardModel.Difficulty * 100;
            int timeDeduction = (int)_boardModel.GameDuration.TotalSeconds;
            int rewardBonus = _boardModel.RewardsRemaining * 100;

            _boardModel.GameStat.Score = Math.Max(baseScore - timeDeduction + rewardBonus, 0);
        }
        
        /// <summary>
        /// Counts the remaining moves when value hits zero player has won
        /// </summary>
        /// <returns></returns>
        private int CountRemainingMoves()
        {
            int count = 0;

            foreach (CellModel[] row in _boardModel.Cells)
            {
                foreach (CellModel cell in row)
                {
                    if (!cell.IsVisited)
                    {
                        count++;
                    }
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
            return _boardModel.NumberOfBombs;
        }

        /// <summary>
        /// Provides access to the number of collected rewards that are stored in the board model
        /// Note: this is unrelated to the number of uncollected rewards hidden on the board.
        /// </summary>
        /// <returns>Number of collected but unused rewards</returns>
        public int GetNumberOfRewards()
        {
            return _boardModel.RewardsRemaining;
        }

        /// <summary>
        /// Flood fill algorithm for filling unoccupied squares
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void FloodFill(int row, int col)
        {
            // Bounds Check
            if (row < 0 || row > _boardModel.Size - 1 || col < 0 || col > _boardModel.Size - 1)
            {
                return; // Not a valid cell
            }

            // Already visited
            if (_boardModel.Cells[row][col].IsVisited == true)
            {
                return; // Cell has already been probed (visited)
            }

            // Numbers Check, cell has bomb neighbors?
            if (_boardModel.Cells[row][col].NumberOfBombNeighbors > 0)
            {
                // Mark the cell as visited
                _boardModel.Cells[row][col].IsVisited = true;

                // Hand out the reward if one is located
                if (_boardModel.Cells[row][col].HasSpecialReward == true)
                {
                    ClaimReward(row, col);
                }

                return; // No more automatic neighbor probing because it could be a bomb.
            }

            // New Valid cell begin recursion logic
            // Mark the cell as visited
            _boardModel.Cells[row][col].IsVisited = true;

            // Hand out the reward if one is located
            if (_boardModel.Cells[row][col].HasSpecialReward == true)
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
            _boardModel.RewardsRemaining++;
            _boardModel.GameState = GameState.RewardFound;
            _boardModel.Cells[row][col].HasSpecialReward = false;
        }

        /// <summary>
        /// Method to access the models start timer method
        /// </summary>
        /// <returns> bool success value </returns>
        private bool StartGame()
        {
            return _boardModel.StartTimer();
        }

        /// <summary>
        /// Method to access the models end timer method
        /// </summary>
        /// <returns> bool success value </returns>
        private bool StopGame()
        {
            return _boardModel.EndTimer();
        }

        /// <summary>
        /// Retrieves the current score of the game.
        /// </summary>
        /// <returns>The current score as an integer.</returns>
        public int GetScore()
        {
            return _boardModel.GameStat.Score;
        }

        /// <summary>
        /// Retrieves the start time of the game.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> representing the start time of the board.</returns>
        public DateTime GetStartTime()
        {
            return _boardModel.GetStartTime();
        }

        /// <summary>
        /// Determines whether the leaderboard data has been successfully loaded.
        /// </summary>
        /// <returns><see langword="true"/> if the leaderboard data is loaded; otherwise, <see langword="false"/>.</returns>
        public bool IsLeaderboardLoaded()
        {
            return _isLeaderboardLoaded;
        }

        /// <summary>
        /// Sets the loaded status of the leaderboard.
        /// </summary>
        /// <param name="v">A value indicating whether the leaderboard is loaded.  Pass <see langword="true"/> to mark the leaderboard
        /// as loaded; otherwise, <see langword="false"/>.</param>
        public void SetLeaderboardLoadedStatus(bool v)
        {
            _isLeaderboardLoaded = v;
        }

        /// <summary>
        /// Accessor for the internal game state of the board
        /// </summary>
        /// <returns></returns>
        public GameState GetGameState()
        {
            return _boardModel.GameState;
        }

        /// <summary>
        /// Resume game method. the model handles its own stat changes and game duration
        /// </summary>
        public void ResumeGame()
        {
            _boardModel.ResumeTimer();
        }

        /// <summary>
        /// Pause game method. the model handles its own stat changes and game duration
        /// </summary>
        public void PauseGame()
        {
            _boardModel.PauseTimer();
        }

        /// <summary>
        /// Method to serialize the current state of the board and save it to a text file
        /// </summary>
        public void SaveGame()
        {
            // Serialized and write the board model
            var serialized = ServiceStack.Text.JsonSerializer.SerializeToString(_boardModel);
    
            // Get the path one directory up from application root
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string dataFolder = Path.Combine(appPath, _fileFolder);

            // Create Data folder if it doesn't exist
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            // Construct the full file path
            string filePath = Path.Combine(dataFolder, _fileName);
            
            // Write the file
            File.WriteAllText(filePath, serialized);
        }

        /// <summary>
        /// Method to deserialize the current state of a game from the saved file location
        /// </summary>
        /// <param name="filePath"></param>
        public void LoadGame(string filePath)
        {
            var serialized = File.ReadAllText(filePath);
            _boardModel = ServiceStack.Text.JsonSerializer.DeserializeFromString<BoardModel>(serialized);

            File.Delete(filePath);
        }
        
        /// <summary>
        /// method to access the board models elapsed time
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetCurrentElapsedTime()
        {  
            return _boardModel.GetCurrentElapsedTime(); 
        }          
    }
}
