/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 5
 * References:
 */

namespace MinesweeperClassLibrary.Models.DTOs
{
    /// <summary>
    /// Represents game's statistics, including details such as the player's name and score, the date the game was played, and an
    /// identifier. Merged with the settings dto. This object now also handles the board size and difficulty.
    /// </summary>
    /// <remarks>This class is typically used as a data transfer object (DTO) to encapsulate information about
    /// a single game session.</remarks>
    public class GameStat
    {
        // Public properties for the GameStat DTO
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Difficulty { get; set; }
        public int BoardSize { get; set; }
        public int Score { get; set; }
        public DateTime DatePlayed { get; set; }

        /// <summary>
        /// Default public constructor
        /// </summary>
        public GameStat()
        {
            Id = 0;
            Name = string.Empty;
            Difficulty = 1;
            BoardSize = 4;
            Score = 0;
            DatePlayed = DateTime.MinValue;
        }

        /// <summary>
        /// Method to reset the stat object while keeping the board size and difficulty the same for the settings form compatibility.
        /// </summary>
        /// <returns></returns>
        public GameStat RestartGame()
        {
            // Initialize the new game stat
            GameStat returnGameStat = new GameStat();

            returnGameStat.Id = 0;
            returnGameStat.Name = "";
            returnGameStat.Difficulty = Difficulty;
            returnGameStat.BoardSize = BoardSize;
            returnGameStat.Score = 0;
            returnGameStat.DatePlayed = DateTime.MinValue;

            return returnGameStat;
        }
    }
}
