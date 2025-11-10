/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 4
 * References:
 */

using MinesweeperGUIApp.Utilities;

namespace MinesweeperGUIApp.UI.Forms
{
    public partial class Setup : Form
    {
        // Class level variable for holding board size and difficulty settings
        private SettingsHelper _setupSettings;

        /// <summary>
        /// Parameterized constructor for the Setup form
        /// </summary>
        /// <param name="settings"></param>
        public Setup(SettingsHelper settings)
        {
            // Declare and Initialize on form creation
            InitializeComponent();
            _setupSettings = settings;
        }

        private void Setup_Load(object sender, EventArgs e)
        {
            lblSizeValue.Text = (trbSize.Value * 10).ToString();
            lblDifficultyValue.Text = trbDifficulty.Value.ToString();
        }

        private void BtnAcceptClickEH(object sender, EventArgs e)
        {
            // Close the form, any settings here are saved in the _setting variable
            this.Close();
        }

        private void TrbSizeScrollEH(object sender, EventArgs e)
        {
            // Convert the 10 size increments into board size
            int size = trbSize.Value * 10;

            // Update labels and the settings object variable
            lblSizeValue.Text = size.ToString();
            _setupSettings.BoardSize = size;
        }

        private void TrbDifficultyScrollEH(object sender, EventArgs e)
        {
            // Update labels and the settings object variable
            lblDifficultyValue.Text = trbDifficulty.Value.ToString();
            _setupSettings.Difficulty = trbDifficulty.Value;
        }
    }
}
