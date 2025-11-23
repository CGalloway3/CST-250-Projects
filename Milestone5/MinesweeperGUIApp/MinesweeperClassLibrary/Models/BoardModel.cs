/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 5
 * References:
 */

using MinesweeperClassLibrary.Models.DTOs;
using MinesweeperClassLibrary.Models.Enums;

namespace MinesweeperClassLibrary.Models
{
    /// <summary>
    /// Represents the game board for a Minesweeper-like game, including its size, cells, game state, and associated
    /// statistics.
    /// </summary>
    /// <remarks>The <see cref="BoardModel"/> class manages the state of the game board, including the layout
    /// of cells, the number of bombs, rewards, and the game's progress. It provides functionality to track the game's 
    /// duration and manage the start and end times of the game. The board is initialized with a grid of  <see
    /// cref="CellModel"/> instances, and its size is determined by the <paramref name="size"/> parameter passed to the
    /// constructor.</remarks>
    internal class BoardModel
    {
        // Private class level variables for GameDuration calculation
        private DateTime _startTime;
        private DateTime _endTime;

        // Public properties with default get and set that are set in the constructor
        public int Size { get; set; }
        public CellModel[,] Cells { get; set; }

        // Public properties with default set and get that have default values
        public int Difficulty { get; set; } = 1;
        public int NumberOfBombs { get; set; } = 0;
        public int RewardsRemaining { get; set; } = 0;
        public GameState GameState { get; set; } = GameState.Starting;
        public GameStat GameStat { get; set; } = new GameStat();

        // Public properties with custom get / set logic
        public TimeSpan GameDuration
        {
            get
            {
                if (GameState == GameState.Won || GameState == GameState.Lost)
                {
                    return _endTime - _startTime;
                }
                else
                {
                    return TimeSpan.Zero;
                }
            }
        }


        /// <summary>
        /// Public Model constructor
        /// </summary>
        /// <param name="size"></param>
        public BoardModel(int size)
        {
            // Initialize variables
            Size = size;
            Cells = new CellModel[size, size];

            // Initialize the board matrix with CellModel instances
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Cells[row, col] = new CellModel
                    {
                        Row = row,
                        Column = col
                    };
                }
            }
        }

        /// <summary>
        /// Start the game timer
        /// </summary>
        /// <returns> Success bool value </returns>
        public bool StartTimer()
        {
            // Start the game timer if the game is in the Starting state
            if (GameState == GameState.Starting)
            {
                _startTime = DateTime.Now;
                GameStat.DatePlayed = _startTime;
                GameState = GameState.InProgress;
                return true;
            }

            // Timer cannot be started if the game is not in the Starting state because it is already running
            return false;
        }

        /// <summary>
        /// Method to lock in the end time when the game ends
        /// </summary>
        public bool EndTimer()
        {
            // End the game timer if the game is in the Won or Lost state
            if (GameState == GameState.Won || GameState == GameState.Lost)
            {
                _endTime = DateTime.Now;
                return true;
            }

            // Timer cannot be ended if the game is not over
            return false;
        }

        /// <summary>
        /// Returns the time the current game started
        /// </summary>
        /// <returns></returns>
        public DateTime GetStartTime()
        {
            return _startTime;
        }
    }
}
