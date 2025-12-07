/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 12/07/2025
 * Mine Sweeper Class Library
 * Milestone 6
 * References:
 */

using MinesweeperClassLibrary.Models.DTOs;
using MinesweeperClassLibrary.Services.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperClassLibrary.Services.BusinessLogicLayer
{
    public class LeaderboardLogic
    {
        // Class level variables
        private List<GameStat> _leaderboardEntries;
        private LeaderboardDAO _leaderboardDAO;

        /// <summary>
        /// Default constructor for the class
        /// </summary>
        public LeaderboardLogic()
        {
            // Initialize
            _leaderboardEntries = new List<GameStat>();
            _leaderboardDAO = new LeaderboardDAO();
        }

        /// <summary>
        /// Parameterized constructor for the class
        /// </summary>
        /// <param name="leaderboardEntries"></param>
        public LeaderboardLogic(List<GameStat> leaderboardEntries)
        {
            // Set and initialize
            _leaderboardEntries = leaderboardEntries;
            _leaderboardDAO = new LeaderboardDAO();
        }

        /// <summary>
        /// Method to sort and return a list of game stats
        /// </summary>
        /// <param name="property"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public List<GameStat> SortList(string property, ListSortDirection direction)
        {
            return direction == ListSortDirection.Ascending
                ? _leaderboardEntries.OrderBy(x => x.GetType().GetProperty(property).GetValue(x)).ToList()
                : _leaderboardEntries.OrderByDescending(x => x.GetType().GetProperty(property).GetValue(x)).ToList();
        }

        /// <summary>
        /// Method for resetting the id numbers of a list
        /// </summary>
        /// <returns></returns>
        public List<GameStat> ResetIds()
        {
            // Loop through the entries in the list and reorder the ids
            for (int i = 0; i < _leaderboardEntries.Count; i++)
            {
                _leaderboardEntries[i].Id = i + 1;
            }
            return _leaderboardEntries;
        }

        /// <summary>
        /// Get the list entries from a leaderboard logic set
        /// </summary>
        /// <returns></returns>
        public List<GameStat> GetEntries()
        {
            return _leaderboardEntries;
        }

        /// <summary>
        /// Get the number of entries in the leaderboard logic list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _leaderboardEntries.Count;
        }

        /// <summary>
        /// Method to combine a loaded list from the DAO with the current list
        /// </summary>
        /// <returns></returns>
        public (bool, string) LoadLeaderboard()
        {
            // Store current entries temporarily
            List<GameStat> tempEntries = new List<GameStat>(_leaderboardEntries);

            // Load from file via DAO
            var (success, message) = _leaderboardDAO.Load();

            // If the load was a success we will add the current entries that were stored in temp
            // back into the newly loaded in list.
            if (success)
            {
                // Store the returned entries from the DAO to the leaderboard logic's list
                _leaderboardEntries = _leaderboardDAO.GetEntries();
                // Add the temporarily stored list entries back into the list
                _leaderboardEntries.AddRange(tempEntries);
                // Reset the ids because some of the temp ids may be the same as the new ones.
                ResetIds();
            }

            // Return the success result and the message
            return (success, message);
        }

        /// <summary>
        /// Method to use the DAO to save the current list
        /// </summary>
        /// <returns></returns>
        public (bool, string) SaveLeaderboard()
        {
            // Return the success result (true, false) and the message from the DAO.
            return _leaderboardDAO.Save();
        }
    }
}
