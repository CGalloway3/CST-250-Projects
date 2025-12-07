/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 12/07/2025
 * Mine Sweeper Class Library
 * Milestone 6
 * References:
 */

using MinesweeperClassLibrary.Services.BusinessLogicLayer;
using MinesweeperClassLibrary.Models.DTOs;
using MinesweeperGUIApp.Utilities;

namespace MinesweeperGUIApp.Forms
{
    /// <summary>
    /// Form displayed when the player wins the game, showing their score and allowing them to enter their name.
    /// </summary>
    public partial class FrmWinNotification : Form
    {
        // Reference to the current game statistics
        private GameStat _gameStat;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmWinNotification"/> class, displaying the current score.
        /// </summary>
        /// <remarks>This constructor initializes the form and sets the score display based on the
        /// provided <see cref="BoardLogic"/> instance. Ensure that the <paramref name="board"/> parameter is not null
        /// before calling this constructor.</remarks>
        /// <param name="board">The <see cref="BoardLogic"/> instance used to retrieve the current score.</param>
        public FrmWinNotification(GameStat game)
        {
            InitializeComponent();

            // Store the reference to the GameStat instance
            _gameStat = game;
            // Set the score label to display the current score
            lblScoreValue.Text = _gameStat.Score.ToString();
        }

        /// <summary>
        /// Handles the click event for the OK button.
        /// </summary>
        /// <remarks>This method validates the input name to ensure it is not empty or whitespace. If the
        /// validation fails,  a warning message is displayed, and the operation is aborted. If the validation succeeds,
        /// the name is  saved, and the form is closed.</remarks>
        /// <param name="sender">The source of the event, typically the OK button.</param>
        /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnOKClickEH(object sender, EventArgs e)
        {
            // Save the player's name in the GameStat
            _gameStat.Name = txtName.Text;
            // Close the notification form
            this.Close();
        }

        /// <summary>
        /// Form closing event handler to validate the player's name input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmWinNotificationFormClosingEH(object sender, FormClosingEventArgs e)
        {
            // Validate that the name is not empty or whitespace
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                // Display the error message.
                MessageBox.Show("Name cannot be empty or whitespace.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Cancel the closing event
                e.Cancel = true;
                // Set focus back to the text box
                txtName.Focus();
            }

            if (txtName.Text.Contains(','))
            {
                // Display the error message.
                MessageBox.Show("Name cannot contain any commas.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Cancel the closing event
                e.Cancel = true;
                // Set focus back to the text box
                txtName.Focus();
            }
        }

        /// <summary>
        /// Event handlers for the name text box to catch the enter key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtNameKeyDownEH(object sender, KeyEventArgs e)
        {
            // did the user hit enter?
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the 'ding' sound
                e.SuppressKeyPress = true;

                // Call the search button click event handler
                BtnOKClickEH(sender, e);
            }
        }
    }
}
