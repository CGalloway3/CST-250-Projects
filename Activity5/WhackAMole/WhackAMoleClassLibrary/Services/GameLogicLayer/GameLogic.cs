/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/23/2025
 * WhackAMole
 * Activity 5
 * References: 
 */

using WhackAMoleClassLibrary.Models;
using WhackAMoleClassLibrary.Services.DataAccessLayer;

namespace WhackAMoleClassLibrary.Services.GameLogicLayer
{
    public class GameLogic
    {
        private GameDAO _gameDAO;
        private const int MaxWaves = 3;
        private TimeSpan _waveTimeLimit = TimeSpan.FromSeconds(30);

        public GameScoreModel gameScore { get; set; }
        public int currentWave { get; set; } = 1;
        public TimeSpan timeElapsed { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Default Constructor for GameLogic
        /// </summary>
        public GameLogic()
        {
            _gameDAO = new GameDAO();
        }

        /// <summary>
        /// Determine if the score is high enough
        /// Add if yes via DAO add method
        /// </summary>
        /// <param name="scoreToAdd"></param>
        /// <returns>True if the score was added and False if it was not</returns>
        public bool AddScoreToList(GameScoreModel scoreToAdd)
        {
            // Is the score actually high enough to add to the leader board
            if (_gameDAO.IsNewHighScore(scoreToAdd))
            {
                // Return the result of the add operation from the DAO
                return _gameDAO.AddScoreToList(scoreToAdd);
            }

            // Score was too low to add to the list
            return false;
        }

        /// <summary>
        /// Clears the high score list via the DAO  
        /// </summary>
        public void ClearList()
        {
            _gameDAO.ClearList();
        }

        /// <summary>
        /// Method that calls the DAO to get all high scores formatted for display
        /// </summary>
        /// <returns></returns>
        public string GetAllHighScoresString()
        {
            return _gameDAO.FormatHighScoresForDisplay();
        }

        /// <summary>
        /// Method that calls the DAO to get high scores for a specific difficulty formatted for display
        /// </summary>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        public string GetHighScoresAtDifficultyString((int, int) difficulty)
        {
            return _gameDAO.FormatHighScoresForDisplay(_gameDAO.GetHighScoresForDifficulty(difficulty));
        }

        /// <summary>
        /// method to access the max number of waves
        /// </summary>
        /// <returns> returns the hard coded MaxWaves </returns>
        public int GetMaxWaveCount()
        {
            return MaxWaves;
        }

        /// <summary>
        /// method to access the wave duration
        /// </summary>
        /// <returns> returns the hard coded waveTimeLimit </returns>
        public TimeSpan GetDuration()
        {
            return _waveTimeLimit;
        }

        /// <summary>
        /// Method to process the WaveUp in the board logic
        /// </summary>
        /// <returns></returns>
        public bool WaveUp()
        {
            // Update the game score with the results from the wave
            gameScore.TotalTargets = gameScore.TargetsHit + gameScore.TargetsMissed;
            gameScore.CompletionTime += timeElapsed;

            // Set the waves completed percentage
            gameScore.CompletionPercentage = (decimal)(timeElapsed.TotalSeconds / _waveTimeLimit.TotalSeconds);
            // Catch some rounding errors
            if (gameScore.CompletionPercentage > 1.0M)
            {
                gameScore.CompletionPercentage = 1.0M;
            }

            // Move to the next wave
            currentWave++;
            // Reset the time elapsed for the new wave
            timeElapsed = TimeSpan.Zero;
            return true;
        }

    }
}
