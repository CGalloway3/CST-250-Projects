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
using System.ComponentModel;
using System.Text;

namespace MinesweeperGUIApp.Forms
{
    /// <summary>
    /// Represents a leaderboard form that displays and manages high scores for a game.
    /// </summary>
    /// <remarks>This form provides functionality to display leaderboard entries. It allows
    /// users to view high scores and sort the entries by various criteria such as name, score, or date. 
    /// The leaderboard entries are displayed in a <see cref="DataGridView"/> control, and the form along with
    /// the associated logic ensures that the leaderboard data is properly managed and persisted.</remarks>
    public partial class FrmLeaderboard : Form
    {
        // Reference to the board logic
        private BoardLogic _board;
        private LeaderboardLogic _leaderboard;
        private BindingSource _bindingSource;
        private bool _wasSaved = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmLeaderboard"/> class, displaying a leaderboard for the
        /// provided game statistics and allowing interaction with leaderboard entries.
        /// </summary>
        /// <remarks>This constructor initializes the leaderboard form by binding the provided leaderboard
        /// entries to a data grid view and setting up the initial state of the form, including the board size selection
        /// and the player's score display.</remarks>
        /// <param name="game">The current game's statistics, including the player's score.</param>
        /// <param name="leaders">A list of game statistics representing the leaderboard entries.</param>
        /// <param name="board">The logic for managing the leaderboard, including board size and related operations.</param>
        public FrmLeaderboard(GameStat game, LeaderboardLogic leaders, BoardLogic board)
        {
            InitializeComponent();

            // Initialize board logic reference and leaderboard reference
            _board = board;
            _leaderboard = leaders;

            // Initialize binding source   
            _bindingSource = new BindingSource
            {
                DataSource = _leaderboard.GetEntries()
            };

            // Bind the DataGridView to the BindingSource
            dgvHighScores.DataSource = _bindingSource;

            // Set initial combo box selection. Calls UpdateLeaderboard when this happens
            cmbBoardSize.SelectedItem = $"{_board.GetBoardSettings().BoardSize} x {_board.GetBoardSettings().BoardSize}";
            lblYourScoreValue.Text = game.Score.ToString();
        }

        /// <summary>
        /// Handles the Click event of the "File > Exit" menu item.
        /// </summary>
        /// <remarks>This method closes the current form when the "File > Exit" menu item is
        /// clicked.</remarks>
        /// <param name="sender">The source of the event, typically the menu item that was clicked.</param>
        /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
        private void MnuFileExitClickEH(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Click event handler for the "Save" menu item.
        /// </summary>
        /// <param name="sender">The source of the event, typically the "Save" menu item.</param>
        /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
        private void MnuFileSaveClickEH(object sender, EventArgs e)
        {
            SaveLeaderboard();
        }

        /// <summary>
        /// Click event handler for the "Load Leaderboard" menu item. 
        /// </summary>
        /// <param name="sender">The source of the event, typically the menu item that was clicked.</param>
        /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
        private void MnuFileLoadClickEH(object sender, EventArgs e)
        {
            LoadLeaderboard();
        }

        /// <summary>
        /// Handles the click event for the "Sort by Name" menu item.
        /// </summary>
        /// <remarks>This method simulates a column header click for the "Name" column in the high scores
        /// DataGridView, triggering the corresponding column header click event handler.</remarks>
        /// <param name="sender">The source of the event, typically the menu item that was clicked.</param>
        /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
        private void MnuSortByNameClickEH(object sender, EventArgs e)
        {
            // Simulate a column header click for the Name column (assuming it's at index 1)
            DataGridViewCellMouseEventArgs args = new DataGridViewCellMouseEventArgs(1, 0, 0, 0, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
            // Call the existing event handler
            DgvHighScoresColumnHeaderMouseClickEH(sender, args);
        }

        /// <summary>
        /// Handles the click event for the "Sort by Score" menu item.
        /// </summary>
        /// <remarks>This method simulates a column header click for the "Score" column in the high scores
        /// DataGridView, triggering the corresponding column header click event handler.</remarks>
        /// <param name="sender">The source of the event, typically the menu item that was clicked.</param>
        /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
        private void MnuSortByScoreClickEH(object sender, EventArgs e)
        {
            // Simulate a column header click for the Score column (assuming it's at index 2)
            DataGridViewCellMouseEventArgs args = new DataGridViewCellMouseEventArgs(2, 0, 0, 0, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
            // Call the existing event handler
            DgvHighScoresColumnHeaderMouseClickEH(sender, args);
        }

        /// <summary>
        /// Handles the click event for the "Sort by Date" menu item.
        /// </summary>
        /// <remarks>This method simulates a column header click for the "Date" column in the high scores
        /// DataGridView, triggering the corresponding column header click event handler.</remarks>
        /// <param name="sender">The source of the event, typically the menu item that was clicked.</param>
        /// <param name="e">An <see cref="EventArgs"/> instance containing the event data.</param>
        private void MnuSortByDateClickEH(object sender, EventArgs e)
        {
            // Simulate a column header click for the Date column (assuming it's at index 3)
            DataGridViewCellMouseEventArgs args = new DataGridViewCellMouseEventArgs(3, 0, 0, 0, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
            // Call the existing event handler
            DgvHighScoresColumnHeaderMouseClickEH(sender, args);
        }

        /// <summary>
        /// Column header mouse click event handler for sorting the leaderboard entries based on the clicked column.
        /// All sorting menu items call this method to perform the sort.
        /// </summary>
        /// <param name="sender">The source of the event, typically the column header that was clicked.</param>
        /// <param name="e">An <see cref="DataGridViewCellMouseEventArgs"/> instance containing the event data </param>
        private void DgvHighScoresColumnHeaderMouseClickEH(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get the clicked column from the event args
            DataGridViewColumn clickedColumn = dgvHighScores.Columns[e.ColumnIndex];

            // Determine the new sort direction based on the current glyph direction
            ListSortDirection direction = clickedColumn.HeaderCell.SortGlyphDirection == SortOrder.Ascending
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;

            // Clear sort glyphs from all columns
            foreach (DataGridViewColumn column in dgvHighScores.Columns)
            {
                column.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            // Get the property name to sort by
            string propertyName = clickedColumn.DataPropertyName;

            // Sort using BLL and set data source directly
            _bindingSource.DataSource = _leaderboard.SortList(propertyName, direction);

            // Set the sort glyph for the clicked column
            dgvHighScores.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
        }

        /// <summary>
        /// Form closing event handler to catch any unsaved changes and prompt the user to save the leaderboard.
        /// </summary>
        /// <param name="sender">The source of the event, typically the form that is closing.</param>
        /// <param name="e">An <see cref="FormClosingEventArgs"/> instance to contain the event data. </param>
        private void FrmLeaderboardFormClosingEH(object sender, FormClosingEventArgs e)
        {
            // Prompt user to save the leaderboard before closing
            if (!_wasSaved)
            {
                var result = MessageBox.Show("Do you want to save the leaderboard before exiting?", "Save Leaderboard",
                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    // Call the save leaderboard method and cancel the form closing event if it returns false.
                    if (!SaveLeaderboard())
                    { 
                        e.Cancel = true; 
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    // Cancel the closing event
                    e.Cancel = true;                
                }
            }
        }

        /// <summary>
        /// Handles the UI elements for the "Save" menu item, saving the current leaderboard to a CSV file.
        /// </summary>
        /// <remarks>This method prompts the user for confirmation if the leaderboard is not already
        /// loaded, to prevent accidental overwrites. The leaderboard data is saved in a CSV format to a "Data" folder
        /// located one directory above the application's root directory. If the save operation is successful, the
        /// leaderboard is flagged as loaded, and a success message is displayed. If an error occurs during the save
        /// process, an error message is displayed to the user.</remarks>
        private bool SaveLeaderboard()
        {
            //  Prompt the user to Prevent leaderboard overwrite if not loaded
            if (!_board.IsLeaderboardLoaded())
            {
                var result = MessageBox.Show("Saving now will overwrite any previously saved leaderboard. Do you want to continue?", "Save Leaderboard",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return false; // Exit the save method
                }
            }

            // leaderboard logic save method call
            (bool success, string message) = _leaderboard.SaveLeaderboard();

            // Show the user the message from the leaderboard save call
            MessageBox.Show(message, "Save Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (success)
            {
                // Flag the leaderboard as loaded
                _board.SetLeaderboardLoadedStatus(true);
                _wasSaved = true;
            }

            // Return the leaderboard save results
            return success;
        }
        
        /// <summary>
        /// Handles UI elements for the "Load Leaderboard" menu item. Loads leaderboard data from a CSV file and
        /// updates the leaderboard entries displayed in the application.
        /// </summary>
        /// <remarks>This method prevents multiple leaderboard loads within the same session. If the
        /// leaderboard has already been loaded, a warning message is displayed, and the operation is aborted. The
        /// method reads leaderboard data from a predefined CSV file, parses it, and updates the leaderboard entries. If
        /// the file does not exist or an error occurs during loading, an appropriate error message is
        /// displayed.</remarks>
        private bool LoadLeaderboard()
        {
            // Prevent multiple loads in the same session
            if (_board.IsLeaderboardLoaded())
            {
                MessageBox.Show("Leaderboard has already been loaded this session.", "Load Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Load the leaderboard from a file
            (bool success, string message) = _leaderboard.LoadLeaderboard();

            // Refresh the data source
            _bindingSource.DataSource = _leaderboard.GetEntries();
            _bindingSource.ResetBindings(false);

            // Flag the leaderboard as loaded
            _board.SetLeaderboardLoadedStatus(true);

            // Update the UI binding source and notify user of load result.
            if (success)
            {
                // Refresh the data source
                _bindingSource.DataSource = _leaderboard.GetEntries();
                _bindingSource.ResetBindings(false);


                // Flag the leaderboard as loaded
                _board.SetLeaderboardLoadedStatus(true);

                MessageBox.Show($"Loaded {_leaderboard.Count()} entries successfully!", "Load Complete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(message, "Load Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Return the load success result
            return success;
        }
    }
}
