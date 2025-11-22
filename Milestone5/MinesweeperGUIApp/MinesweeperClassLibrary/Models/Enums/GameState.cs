/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 5
 * References:
 */

namespace MinesweeperClassLibrary.Models.Enums
{
    /// <summary>
    /// Used to track the game state including win and loss conditions
    /// </summary>
    /// <remarks></remarks>
    public enum GameState
    {
        Starting,
        InProgress,
        Won,
        Lost,
        RewardFound
    }
}
