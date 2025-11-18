/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 4
 * References:
 */

using MinesweeperGUIApp.DTOs;
using System.Drawing;

namespace MinesweeperGUIApp.UI.Forms
{
    public partial class SetupForm : Form
    {
        // Class level variable for holding board size and difficulty settings
        private SettingsDto _setupSettings;

        /// <summary>
        /// Parameterized constructor for the Setup form
        /// </summary>
        /// <param name="settings"></param>
        public SetupForm(SettingsDto settings)
        {
            // Declare and Initialize on form creation
            InitializeComponent();
            _setupSettings = settings;

            // Set initial state of the trackbars
            trbDifficulty.Value = _setupSettings.Difficulty;
            trbSize.Value = _setupSettings.BoardSize / 4;
        }

        /// <summary>
        /// On load event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Setup_Load(object sender, EventArgs e)
        {
            // Update the labels holding the settings values
            lblSizeValue.Text = (trbSize.Value * 4).ToString();
            lblDifficultyValue.Text = trbDifficulty.Value.ToString();
        }

        /// <summary>
        /// Play (accept) button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAcceptClickEH(object sender, EventArgs e)
        {
            // Save the settings
            _setupSettings.BoardSize = trbSize.Value * 4;
            _setupSettings.Difficulty = trbDifficulty.Value;
            // Close the form, any settings here are saved in the _setting variable
            this.Close();
        }

        /// <summary>
        /// Event handler for the size track bar scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrbSizeScrollEH(object sender, EventArgs e)
        {
            // Update labels text
            lblSizeValue.Text = (trbSize.Value * 4).ToString();
        }

        /// <summary>
        /// Event handler for the difficulty track bar scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrbDifficultyScrollEH(object sender, EventArgs e)
        {
            // Update labels text
            lblDifficultyValue.Text = trbDifficulty.Value.ToString();
        }
    }
}
