/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 4
 * References:
 */

namespace MinesweeperGUIApp.Models.Enums
{
    /// <summary>
    /// Used to help determine win and loss conditions
    /// </summary>
    public enum GameState
    {
        InProgress,
        Won,
        Lost,
        RewardFound
    }
}
