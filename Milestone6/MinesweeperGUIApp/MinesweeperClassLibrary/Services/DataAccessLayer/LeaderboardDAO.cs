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
        private readonly string _filePath;

        public LeaderboardDAO()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string dataFolder = Path.Combine(appPath, "Data");
            _filePath = Path.Combine(dataFolder, "LeaderBoard.csv");
        }

        public (bool, string) Load(out List<GameStat> entries)
        {
            entries = new List<GameStat>();

            try
            {
                if (!File.Exists(_filePath))
                {
                    return (false, "No saved leaderboard found.");
                }

                string[] lines = File.ReadAllLines(_filePath);

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    if (parts.Length == 6)
                    {
                        entries.Add(new GameStat
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
                return (true, "Leaderboard file successfully loaded.");
            }
            catch (Exception ex)
            {
                return (false, $"Error loading leaderboard: {ex.Message}");
            }
        }

        public (bool, string) Save(List<GameStat> entries)
        {
            try
            {
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                string dataFolder = Path.Combine(appPath, "Data");

                if (!Directory.Exists(dataFolder))
                {
                    Directory.CreateDirectory(dataFolder);
                }

                StringBuilder csv = new StringBuilder();
                csv.AppendLine("Id,Name,Score,Size,Difficulty,DatePlayed");

                foreach (var stat in entries)
                {
                    csv.AppendLine($"{stat.Id},{stat.Name},{stat.Score},{stat.BoardSize},{stat.Difficulty},{stat.DatePlayed:yyyy-MM-dd HH:mm:ss}");
                }

                File.WriteAllText(_filePath, csv.ToString());
                return (true, "Leaderboard saved successfully!");
            }
            catch (Exception ex)
            {
                return (false, $"Error saving leaderboard: {ex.Message}");
            }
        }
    }
}
