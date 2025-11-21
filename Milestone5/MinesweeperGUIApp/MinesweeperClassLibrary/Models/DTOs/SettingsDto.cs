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
    /// Class to hold the values of the settings page
    /// </summary>
    public class SettingsDto
    {
        // Properties
        public int Difficulty { get; set; }
        public int BoardSize { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsDto() 
        { 
            Difficulty = 1;
            BoardSize = 4;
        }
    }
}
