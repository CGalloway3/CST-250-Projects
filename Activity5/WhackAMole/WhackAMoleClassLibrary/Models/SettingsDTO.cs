/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/23/2025
 * WhackAMole
 * Activity 5
 * References:
 */

namespace WhackAMoleClassLibrary.Models
{
    public class SettingsDTO
    {
        public string PlayersName { get; set; }
        public int BoardSize { get; set; } // Small, Medium, Large represented as 0, 1, 2
        public int TargetSize { get; set; } // Large, Medium, Small represented as 0, 1, 2       

        /// <summary>
        /// Default settings constructor
        /// </summary>
        public SettingsDTO()
        {
            // Default settings
            PlayersName = "";
            BoardSize = 0; // Medium
            TargetSize = 0; // Medium
        }
    }
}
