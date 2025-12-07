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
        private List<GameStat> _leaderboardEntries;
        private LeaderboardDAO _dao;

        public LeaderboardLogic()
        {
            _leaderboardEntries = new List<GameStat>();
            _dao = new LeaderboardDAO();
        }

        public LeaderboardLogic(List<GameStat> leaderboardEntries)
        {
            _leaderboardEntries = leaderboardEntries;
            _dao = new LeaderboardDAO();
        }

        public List<GameStat> SortList(string property, ListSortDirection direction)
        {
            return direction == ListSortDirection.Ascending
                ? _leaderboardEntries.OrderBy(x => x.GetType().GetProperty(property).GetValue(x)).ToList()
                : _leaderboardEntries.OrderByDescending(x => x.GetType().GetProperty(property).GetValue(x)).ToList();
        }

        public List<GameStat> ResetIds()
        {
            for (int i = 0; i < _leaderboardEntries.Count; i++)
            {
                _leaderboardEntries[i].Id = i + 1;
            }
            return _leaderboardEntries;
        }

        public List<GameStat> GetEntries()
        {
            return _leaderboardEntries;
        }

        public int Count()
        {
            return _leaderboardEntries.Count;
        }

        public (bool, string) LoadLeaderboard()
        {
            // Store current entries temporarily
            List<GameStat> tempEntries = new List<GameStat>(_leaderboardEntries);

            // Load from file via DAO
            var (success, message) = _dao.Load(out List<GameStat> loadedEntries);

            if (success)
            {
                _leaderboardEntries = loadedEntries;
                _leaderboardEntries.AddRange(tempEntries);
                ResetIds();
            }

            return (success, message);
        }

        public (bool, string) SaveLeaderboard()
        {
            return _dao.Save(_leaderboardEntries);
        }
    }
}
