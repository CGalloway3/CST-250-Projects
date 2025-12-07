/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 12/07/2025
 * Mine Sweeper Class Library
 * Milestone 6
 * References:
 */

using MinesweeperClassLibrary.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperClassLibrary.Services.DataAccessLayer
{
    internal class LeaderboardDAO
    {
        // Class level variables
        private readonly string _filePath = "Data/LeaderBoard.csv";
        private List<GameStat> _entries;

        /// <summary>
        /// Public default constructor for the class
        /// </summary>
        public LeaderboardDAO()
        {
           
        }

        /// <summary>
        /// DAO load method to implement loading of the leaderboard list from a file
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        public (bool, string) Load()
        {
            // Initialize the out parameter
            _entries = new List<GameStat>();

            // Try the file load
            try
            {
                // If no file exists at the location _filePath return the failure and message
                if (!File.Exists(_filePath))
                {
                    return (false, "No saved leaderboard found.");
                }

                // Read the lines from the file
                string[] lines = File.ReadAllLines(_filePath);

                // Loop through all the lines of the file
                for (int i = 1; i < lines.Length; i++)
                {
                    // split the lines into its parts
                    string[] parts = lines[i].Split(',');
                    // Check that the line was the correct length
                    if (parts.Length == 6)
                    {
                        // Add the game stat from the file to the out parameter list
                        _entries.Add(new GameStat
                        {
                            Id = i,
                            Name = parts[1].Trim('"'),
                            Score = int.Parse(parts[2]),
                            BoardSize = int.Parse(parts[3]),
                            Difficulty = int.Parse(parts[4]),
                            DatePlayed = DateTime.Parse(parts[5])
                        });
                    }
                }
                // return the success and message to the caller
                return (true, "Leaderboard file successfully loaded.");
            }
            catch (Exception ex)
            {
                // return failure and message
                return (false, $"Error loading leaderboard: {ex.Message}");
            }
        }

        /// <summary>
        /// Method for saving the DAO
        /// </summary>
        /// <param name="entries"></param>
        /// <returns></returns>
        public (bool, string) Save()
        {
            // TRy file save
            try
            {
                // Initialize path strings
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string dataFolder = Path.Combine(appPath, "Data");

                // Create the directory if it does not exist
                if (!Directory.Exists(dataFolder))
                {
                    Directory.CreateDirectory(dataFolder);
                }

                // Build a string and add a header row the the data
                StringBuilder csv = new StringBuilder();
                csv.AppendLine("Id,Name,Score,Size,Difficulty,DatePlayed");

                // Add all entries to the string
                foreach (var stat in _entries)
                {
                    csv.AppendLine($"{stat.Id},{stat.Name},{stat.Score},{stat.BoardSize},{stat.Difficulty},{stat.DatePlayed:yyyy-MM-dd HH:mm:ss}");
                }

                // Write out the completed string
                File.WriteAllText(_filePath, csv.ToString());
                // Return success and message
                return (true, "Leaderboard saved successfully!");
            }
            catch (Exception ex)
            {
                // return failure and message
                return (false, $"Error saving leaderboard: {ex.Message}");
            }
        }

        /// <summary>
        /// Public method to get the list of entries from the DAO
        /// </summary>
        /// <returns></returns>
        public List<GameStat> GetEntries()
        {
            // Return the entries list
            return _entries;
        }
    }
}
