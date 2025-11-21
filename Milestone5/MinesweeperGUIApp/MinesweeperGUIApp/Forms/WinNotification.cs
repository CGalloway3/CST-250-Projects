/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 5
 * References:
 */

using MinesweeperClassLibrary.BusinessLogicLayer;

namespace MinesweeperGUIApp.Forms
{
    public partial class FrmWinNotification : Form
    {
        // Reference to the BoardLogic instance that will be passed in
        private BoardLogic _boardLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmWinNotification"/> class, displaying the current score.
        /// </summary>
        /// <remarks>This constructor initializes the form and sets the score display based on the
        /// provided <see cref="BoardLogic"/> instance. Ensure that the <paramref name="board"/> parameter is not null
        /// before calling this constructor.</remarks>
        /// <param name="board">The <see cref="BoardLogic"/> instance used to retrieve the current score.</param>
        public FrmWinNotification(BoardLogic board)
        {
            InitializeComponent();

            // Store the reference to the BoardLogic instance
            _boardLogic = board;
            // Set the score label to display the current score
            lblScoreValue.Text = _boardLogic.GetScore().ToString();
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
            _boardLogic.SetName(txtName.Text);
            // Close the notification form
            this.Close();
        }

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
        }
    }
}
