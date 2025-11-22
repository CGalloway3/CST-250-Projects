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
    /// identifier.
    /// </summary>
    /// <remarks>This class is typically used as a data transfer object (DTO) to encapsulate information about
    /// a single game session.</remarks>
    public class GameStat
    {
        // Public properties for the GameStat DTO
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Score { get; set; }
        public DateTime DatePlayed { get; set; }
    }
}
