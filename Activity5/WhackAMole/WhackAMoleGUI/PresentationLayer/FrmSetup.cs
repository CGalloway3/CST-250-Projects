/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/23/2025
 * WhackAMole
 * Activity 5
 * References:
 */

using WhackAMoleClassLibrary.Models;
using WhackAMoleClassLibrary.Models.Enums;

namespace WhackAMoleGUI.PresentationLayer
{
    public partial class FrmSetup : Form
    {
        // Settings holder
        SettingsDTO settingsDTO;

        /// <summary>
        /// Parameterized constructor to store the settings in the settings dto and initialize the forms
        /// track bar and text controls with the values already held in the settings dto object
        /// </summary>
        /// <param name="settings"></param>
        public FrmSetup(SettingsDTO settings)
        {
            InitializeComponent();
            settingsDTO = settings;

            // Initialize the trackbars, labels, and Name Box
            tsbBoardSize.Value = settings.BoardSize;
            TsbBoardSizeScrollEH(this, EventArgs.Empty);
            tsbTargetSize.Value = settings.TargetSize;
            TsbTargetSizeScrollEH(this, EventArgs.Empty);
            txtName.Text = settings.PlayersName;
        }

        /// <summary>
        /// Event handler for the scroll bar of the board size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsbBoardSizeScrollEH(object sender, EventArgs e)
        {
            // Update the label with the selected board size using lambda expression switch
            lblBoardSizeValue.Text = (DifficultyLevel)tsbBoardSize.Value switch
            {
                DifficultyLevel.Easy => "Small",
                DifficultyLevel.Medium => "Medium",
                DifficultyLevel.Hard => "Large",
                _ => lblBoardSizeValue.Text
            };

            // store settings
            settingsDTO.BoardSize = tsbBoardSize.Value;
        }

        /// <summary>
        /// Event handler for the scroll bar ot the target size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsbTargetSizeScrollEH(object sender, EventArgs e)
        {
            // Update the label with the selected target size using lambda expression switch
            lblTargetSizeValue.Text = (DifficultyLevel)tsbTargetSize.Value switch
            {
                DifficultyLevel.Easy => "Large",
                DifficultyLevel.Medium => "Medium",
                DifficultyLevel.Hard => "Small",
                _ => lblTargetSizeValue.Text
            };

            // store settings
            settingsDTO.TargetSize = tsbTargetSize.Value;
        }

        /// <summary>
        /// event handler for the play button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlayClickEH(object sender, EventArgs e)
        {
            settingsDTO.PlayersName = txtName.Text;
            settingsDTO.BoardSize = tsbBoardSize.Value;
            settingsDTO.TargetSize = tsbTargetSize.Value;
            this.DialogResult = DialogResult.OK;

        }

        /// <summary>
        /// Event handler for the From closing event. Used for text box validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSetupFormClosingEH(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter a valid name.");
                txtName.Focus();
                e.Cancel = true;
            }
        }
    }
}
