/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/23/2025
 * WhackAMole
 * Activity 5
 * References: ByteHide. (2023, April 1). C# LINQ: Grouping, sorting, and filtering data - ByteHide. ByteHide. https://www.bytehide.com/blog/linq-data-manipulation-csharp
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhackAMoleClassLibrary.Models;
using WhackAMoleClassLibrary.Models.Enums;

namespace WhackAMoleClassLibrary.Services.DataAccessLayer
{
    internal class GameDAO
    {
        // Class level variables
        private List<GameScoreModel> _highScores;
        private int _maxNumScoresPerDifficulty = 3; // Adjust to allow more scores in the list 

        /// <summary>
        /// Default constructor for the Game Data Access Object
        /// </summary>
        public GameDAO()
        {
            // Initialize the high scores list
            _highScores = new List<GameScoreModel>();
            // Read existing high scores from file
            ReadHighScoresFromFile();
        }

        /// <summary>
        /// Adds the score to the _highScores list
        /// </summary>
        /// <returns> true if add was successful and false if not. </returns>
        public bool AddScoreToList(GameScoreModel scoreToAdd)
        {
            try
            {
                // Add the new score to the list
                _highScores.Add(scoreToAdd);

                // Then take only the max number of scores per difficulty
                // See ByteHide (2023) for reference on LINQ grouping and filtering
                _highScores = _highScores
                    .OrderByDescending(s => s.Score)
                    .GroupBy(s => s.Difficulty)
                    .SelectMany(g => g.Take(_maxNumScoresPerDifficulty))
                    .ToList();

                // Write the new list out to file
                WriteHighScoresToFile();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Determines if the score is a new high score
        /// </summary>
        /// <param name="scoreToAdd"> The score we want to try and add to the list. </param>
        /// <returns> true if the score is high enough to add to the list and false if not </returns>
        public bool IsNewHighScore(GameScoreModel scoreToAdd)
        {
            // Placeholder for the lowest score
            GameScoreModel lowestScore = null;
            // How many scores are in the difficulty category
            int scoresInDifficultyCategory = 0;

            // Foreach every score in the list to find the lowest score
            foreach (GameScoreModel score in _highScores)
            {
                // if the score is in the same difficulty category
                if (score.Difficulty == scoreToAdd.Difficulty)
                {
                    // Increment how many scores are in this difficulty category
                    scoresInDifficultyCategory++;
                    // If lowest score is null or the current score is lower than the lowest score
                    if (lowestScore == null || lowestScore.Score > score.Score)
                    {
                        // Set the lowest score to the current score
                        lowestScore = score;
                    }
                }
            }
            // If there are already max number of scores in this difficulty category
            // and the new score is less than or equal to the lowest score
            // and the lowest score is not null.
            // We return false, this score is not good enough to add.
            if (lowestScore != null && lowestScore.Score >= scoreToAdd.Score && scoresInDifficultyCategory >= _maxNumScoresPerDifficulty)
            {
                return false;
            }

            // The score is good enough to add.
            return true;
        }

        /// <summary>
        /// Retrieves a list of high scores for the specified difficulty level.
        /// </summary>
        /// <param name="difficulty"> The difficulty level for which to retrieve high scores. </param>
        /// <returns> A list of <see cref="GameScoreModel"/> objects representing the high scores for the specified difficulty. 
        /// Returns an empty list if no scores exist for the given difficulty. </returns>
        public List<GameScoreModel> GetHighScoresForDifficulty((int, int) difficulty)
        {
            List<GameScoreModel> scoresInDifficulty = new List<GameScoreModel>();
            foreach (GameScoreModel score in _highScores)
            {
                if (score.Difficulty == difficulty)
                {
                    scoresInDifficulty.Add(score);
                }
            }
            return scoresInDifficulty;
        }

        /// <summary>
        /// Write the games high scores to a text file
        /// </summary>
        /// <returns></returns>
        private bool WriteHighScoresToFile()
        {
            // Declare and initialize
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            string highScoreString = "";

            // Check if the directory exists
            if (!Directory.Exists(filePath))
            {
                // Create the directory
                Directory.CreateDirectory(filePath);
            }

            // Set up a try-catch for the file writer
            try
            {
                // Create a using statement for StreamWriter
                using (StreamWriter streamWriter = new StreamWriter(Path.Combine(filePath, "HighScores.txt")))
                {
                    // Loop through the score order list
                    foreach (GameScoreModel score in _highScores)
                    {
                        // Format the score for file output
                        highScoreString = FormatScoresForFileOutput(score);
                        // Write the line to the file
                        streamWriter.WriteLine(highScoreString);
                    }
                }

                // Return true
                return true;
            }
            catch
            {
                // Return false
                return false;
            }
        }

        /// <summary>
        /// Read high scores from file and populate the _highScores list
        /// </summary>
        /// <returns> True if successful, false otherwise. </returns>
        private bool ReadHighScoresFromFile()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "HighScores.txt");

            // Check if file exists
            if (!File.Exists(filePath))
            {
                return false;
            }

            try
            {
                _highScores.Clear();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        GameScoreModel score = ParseScoreFromFile(line);
                        if (score != null)
                        {
                            _highScores.Add(score);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Format high scores for display in a TextBox or Label for all scores
        /// </summary>
        /// <param name="topN">Number of top scores to display (0 for all)</param>
        /// <returns>Formatted string of high scores</returns>
        public string FormatHighScoresForDisplay()
        {
            if (_highScores == null || _highScores.Count == 0)
            {
                return "No high scores available.";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("          ===== High Scores =====");
            sb.AppendLine();

            int rank = 1;

            foreach (var score in _highScores)
            {
                sb.AppendLine($"#{rank} - {score.Name}   Score: {score.Score:N0}");
                sb.AppendLine($"    Accuracy: {score.Accuracy / 100:P1}   Targets: {score.TargetsHit}/{score.TotalTargets}");
                sb.AppendLine($"    Difficulty: {(DifficultyLevel)score.Difficulty.Item1} x {(DifficultyLevel)score.Difficulty.Item2}   Completion: {score.CompletionPercentage:P1}");
                if (score.CompletionTime != TimeSpan.Zero)
                {
                    sb.AppendLine($"   Time: {score.CompletionTime:mm\\:ss}");
                }
                sb.AppendLine();
                rank++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Format high scores for display in a TextBox or Label for only the passed in scores
        /// </summary>
        /// <param name="topN">Number of top scores to display (0 for all)</param>
        /// <returns>Formatted string of high scores</returns>
        public string FormatHighScoresForDisplay(List<GameScoreModel> scoresToDisplay)
        {
            if (scoresToDisplay == null || scoresToDisplay.Count == 0)
            {
                return "No high scores available.";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("          ===== High Scores =====");
            sb.AppendLine();

            int rank = 1;

            foreach (var score in scoresToDisplay)
            {
                sb.AppendLine($"#{rank} - {score.Name}   Score: {score.Score:N0}");
                sb.AppendLine($"    Accuracy: {score.Accuracy / 100:P1}   Targets: {score.TargetsHit}/{score.TotalTargets}");
                sb.AppendLine($"    Difficulty: {(DifficultyLevel)score.Difficulty.Item1} x {(DifficultyLevel)score.Difficulty.Item2}   Completion: {score.CompletionPercentage:P1}");
                if (score.CompletionTime != TimeSpan.Zero)
                {
                    sb.AppendLine($"   Time: {score.CompletionTime:mm\\:ss}");
                }
                sb.AppendLine();
                rank++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Parse a line from the file into a GameScoreModel
        /// </summary>
        private GameScoreModel ParseScoreFromFile(string dataLine)
        {
            try
            {
                // Create a new score object and split the dataLine into key-value pairs
                GameScoreModel score = new GameScoreModel();
                string[] kvPairs = dataLine.Split('|');

                // Iterate over all the key-value pairs and populate the score properties.
                foreach (var kvPair in kvPairs)
                {
                    // Split the pair into key and value
                    string[] key_Value = kvPair.Split(new[] { ':' }, 2);
                    if (key_Value.Length != 2) continue;

                    // Trim whitespace and assign to key and value
                    string key = key_Value[0].Trim();
                    string value = key_Value[1].Trim();

                    // Switch on the key to assign the value to the correct property
                    switch (key)
                    {
                        case "Name":
                            score.Name = value;
                            break;
                        case "Score":
                            score.Score = int.Parse(value);
                            break;
                        case "TargetsHit":
                            score.TargetsHit = int.Parse(value);
                            break;
                        case "TargetsMissed":
                            score.TargetsMissed = int.Parse(value);
                            break;
                        case "Difficulty":
                            var diffParts = value.Split(',');
                            score.Difficulty = (int.Parse(diffParts[0]), int.Parse(diffParts[1]));
                            break;
                        case "TotalTargets":
                            score.TotalTargets = int.Parse(value);
                            break;
                        case "Accuracy":
                            score.Accuracy = decimal.Parse(value);
                            break;
                        case "CompletionPercentage":
                            score.CompletionPercentage = decimal.Parse(value);
                            break;
                        case "CompletionTime":
                            score.CompletionTime = TimeSpan.Parse(value);
                            break;
                    }
                }
                return score;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Format a GameScoreModel into a string for file storage
        /// </summary>
        private string FormatScoresForFileOutput(GameScoreModel score)
        {
            return $"Name:{score.Name}|" +
                   $"Score:{score.Score}|" +
                   $"TargetsHit:{score.TargetsHit}|" +
                   $"TargetsMissed:{score.TargetsMissed}|" +
                   $"Difficulty:{score.Difficulty.Item1},{score.Difficulty.Item2}|" +
                   $"TotalTargets:{score.TotalTargets}|" +
                   $"Accuracy:{score.Accuracy}|" +
                   $"CompletionPercentage:{score.CompletionPercentage}|" +
                   $"CompletionTime:{score.CompletionTime}";
        }

        /// <summary>
        /// Clears the high scores list and updates the file
        /// </summary>
        /// <returns></returns>
        internal bool ClearList()
        {
            try
            {
                _highScores.Clear();
                WriteHighScoresToFile();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
