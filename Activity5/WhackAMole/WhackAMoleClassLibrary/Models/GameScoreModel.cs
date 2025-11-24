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
    public class GameScoreModel
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public (int, int) Difficulty { get; set; } // Board Size, Target Size
        public decimal CompletionPercentage { get; set; }
        public int TotalTargets { get; set; }
        public int TargetsHit { get; set; }
        public int TargetsMissed { get; set; }
        public TimeSpan CompletionTime { get; set; }
        public decimal Accuracy {  get; set; }
        
        /// <summary>
        /// Default constructor for a new game
        /// </summary>
        public GameScoreModel() { }

        /// <summary>
        /// Parameterized constructor for the same player to start a new game at the same difficulty.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="difficulty"></param>
        public GameScoreModel(string name, (int, int) difficulty)
        {
            Name = name;
            Difficulty = difficulty;
            ResetScore();
        }

        /// <summary>
        /// reset all the classes values to default except for name and difficulty.
        /// </summary>
        public void ResetScore()
        {
            Score = 0;
            CompletionPercentage = 0;
            TotalTargets = 0;
            TargetsHit = 0;
            TargetsMissed = 0;
            CompletionTime = TimeSpan.Zero;
            Accuracy = 0;
        }
    }
}
