/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 4
 * References:
 */

using MinesweeperGUIApp.Models;
using MinesweeperGUIApp.Models.Enums;
using MinesweeperGUIApp.Services.BusinessLogicLayer;
using MinesweeperGUIApp.Utilities;
using System.Windows.Forms;

namespace MinesweeperGUIApp.UI.Forms
{
    public partial class MainForm : Form
    {
        // Declare settings and board objects
        private SettingsHelper _mainFormSettings;
        private BoardLogic _board;

        // Declare the variables for image resources used to paint cells
        private Image _blankCellImage;
        private Image _oneNeighborImage;
        private Image _twoNeighborsImage;
        private Image _threeNeighborsImage;
        private Image _fourNeighborsImage;
        private Image _fiveNeighborsImage;
        private Image _sixNeighborsImage;
        private Image _sevenNeighborsImage;
        private Image _eightNeighborsImage;
        private Image _nineNeighborsIsBombImage;
        private Image _flaggedCellImage;
        private Image _hiddenCellImage;

        /// <summary>
        /// Entry Point
        /// </summary>
        public MainForm()
        {
            // Winforms Init
            InitializeComponent();

            // Initialize the image resources
            InitializeImages();

            // Initialize the settings object
            _mainFormSettings = new SettingsHelper();

            // Call the reset button click event handler to open the settings window before main form load.
            BtnRestartClickEH(this, EventArgs.Empty);
        }

        /// <summary>
        /// Method for initializing all the panel images
        /// </summary>
        private void InitializeImages()
        {
            // Pre-load all the image resources for the cells
            _blankCellImage = Properties.Resources.Minesweeper_Blank_Cell;
            _oneNeighborImage = Properties.Resources.Minesweeper_1;
            _twoNeighborsImage = Properties.Resources.Minesweeper_2;
            _threeNeighborsImage = Properties.Resources.Minesweeper_3;
            _fourNeighborsImage = Properties.Resources.Minesweeper_4;
            _fiveNeighborsImage = Properties.Resources.Minesweeper_5;
            _sixNeighborsImage = Properties.Resources.Minesweeper_6;
            _sevenNeighborsImage = Properties.Resources.Minesweeper_7;
            _eightNeighborsImage = Properties.Resources.Minesweeper_8;
            _nineNeighborsIsBombImage = Properties.Resources.Minesweeper_Bomb_Cell;
            _flaggedCellImage = Properties.Resources.Minesweeper_Flagged_Cell;
            _hiddenCellImage = Properties.Resources.Minesweeper_Hidden_Cell;
        }

        /// <summary>
        /// restart button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRestartClickEH(object sender, EventArgs e)
        {
            Form setup = new UI.Forms.SetupForm(_mainFormSettings);
            setup.ShowDialog();
            FillPanelWithCells();
        }

        /// <summary>
        /// Method to fill the parent panel pnlMain with all the child panels that will represent the cells
        /// </summary>
        private void FillPanelWithCells()
        {
            // Board size = size setting (4, 8, 12, 16, etc...).
            // Number of cell = board size. Each cell is 25,25 in size
            // Board  panel starts at loc 12, 12 and is size 500. Form starts at size 680,560

            // Declare and Initialize
            pnlMain.Controls.Clear();
            _board = new BoardLogic(_mainFormSettings.BoardSize);

            // Setup the board
            _board.SetDifficulty(_mainFormSettings.Difficulty);
            _board.SetupBombs();
            _board.CountBombsNearby();

            // Initialize the values of the labels holding bomb and reward data
            lblBombsValue.Text = _board.GetNumberOfBombs().ToString("00");
            lblRewardsValue.Text = _board.GetNumberOfRewards().ToString("00");

            // Adjust the size of the form depending on the size of the board. if-else to
            // catch super small boards and make them big enough to fit all the other controls
            if (_mainFormSettings.BoardSize > 4)
            {
                this.Size = new Size((_mainFormSettings.BoardSize * 25) + 180, (_mainFormSettings.BoardSize * 25) + 60);
            }
            else // Small board so we will use the minimum size
            {
                this.Size = new Size((_mainFormSettings.BoardSize * 25) + 180, (_mainFormSettings.BoardSize * 25) + 160);
            }

            // Pause pnlMain layout until we add all the children
            pnlMain.SuspendLayout();
            // Iterate over all the cells and add the appropriate panel
            for (int row = 0; row < _board.GetBoardSize(); row++)
            {
                for (int col = 0; col < _board.GetBoardSize(); col++)
                {
                    Panel panel = new Panel();
                    panel.Size = new Size(25, 25);
                    panel.Location = new Point((row) * 25, (col) * 25);
                    panel.BackgroundImage = _hiddenCellImage;
                    panel.BackgroundImageLayout = ImageLayout.Stretch;
                    panel.Tag = new Point(row, col);
                    panel.Click += PanelCellsClickEH;
                    pnlMain.Controls.Add(panel);
                }
            }
            // Resume the layout of the pnlMain
            pnlMain.ResumeLayout();
        }

        /// <summary>
        /// Handle the click event for the panel cells
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelCellsClickEH(object? sender, EventArgs e)
        {
            // Capture which button is clicked
            MouseEventArgs args = (MouseEventArgs)e;
            MouseButtons userClicked = args.Button;

            // Pull the cells location out of the panels tag
            Panel panel = (Panel)sender;
            Point cellLoc = (Point)panel.Tag;

            // If the game is still in progress use mouse button to determine the proper next action.
            if (_board.GetGameState() == GameState.InProgress)
            {
                if (userClicked == MouseButtons.Left) // User Left clicked
                {
                    // Left click signifies visit. Call DetermineGameState with a visit command of 1
                    _board.DetermineGameState(cellLoc.X, cellLoc.Y, 1);
                    // Refresh pnlMain layout
                    RefreshPanels(panel);
                    // Remove any border styles applied previously by using rewards
                    panel.BorderStyle = BorderStyle.None;
                }
                else if (userClicked == MouseButtons.Right) // User Right clicked
                {
                    // Right click signifies flag. Call DetermineGameState with a flag command of 2
                    _board.DetermineGameState(cellLoc.X, cellLoc.Y, 2);
                    // Refresh pnlMain layout
                    RefreshPanels(panel);
                    // Remove any border styles applied previously by using rewards
                    panel.BorderStyle = BorderStyle.None;
                }
                else // User clicked any other mouse button (use reward)
                {
                    // Make sure there are rewards left
                    if (_board.GetNumberOfRewards() > 0)
                    {
                        // Other clicks signify use reward. Call DetermineGameState with a reward command of 3
                        _board.DetermineGameState(cellLoc.X, cellLoc.Y, 3);
                        // Refresh pnlMain layout
                        RefreshPanels(panel);
                        // Set the panels border property to fixed single so we can remember what cells had reward used on
                        panel.BorderStyle = BorderStyle.FixedSingle;
                    }
                    else
                    {
                        // Catch no rewards left
                        MessageBox.Show(" You are out of rewards. ");
                        return;
                    }
                }
            }
            // Check state for win loss
            StateCheck();
            // call visit again to clear reward game states
            if (_board.GetGameState() == GameState.RewardFound)
            {
                _board.DetermineGameState(cellLoc.X, cellLoc.Y, 1);
            }
        }

        /// <summary>
        /// Method to catch the different game states and notify the user of what happened.
        /// </summary>
        private void StateCheck()
        {
            switch (_board.GetGameState())
            {
                case GameState.Lost:
                    // Reveal all the bombs on the board for the user after a loss
                    RevealAllBombs();
                    MessageBox.Show(" You lost try again.");
                    break;

                case GameState.Won:
                    MessageBox.Show(" You Won!! Great Job.");
                    break;

                case GameState.RewardFound:
                    MessageBox.Show(" You found a reward. ");
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Show all bomb locations to the user after a loss
        /// </summary>
        private void RevealAllBombs()
        {
            foreach (Panel panel in pnlMain.Controls)
            {
                // Get the board cell from the panel tag
                Point cellLoc = (Point)panel.Tag;
                CellModel cell = _board.GetCellAt(cellLoc.X, cellLoc.Y);

                if (cell.IsBomb)
                {
                    panel.BackgroundImage = _nineNeighborsIsBombImage;
                }
            }
        }

        /// <summary>
        /// Refreshes the image state of all the panels on the board
        /// </summary>
        /// <param name="primaryPanel"></param>
        private void RefreshPanels(Panel primaryPanel)
        {
            // Declare and Initialize
            Point primaryLoc = (Point)primaryPanel.Tag;
            CellModel primaryCell = _board.GetCellAt(primaryLoc.X, primaryLoc.Y);

            // Short cut check for flood fill, if we have neighbors simply paint the panel.
            // Else we found a void and will iterate over all the panels to update them all.
            if (!(primaryCell.NumberOfBombNeighbors == 0))
            {
                PaintPanel(primaryPanel, primaryCell);
            }
            else
            {
                foreach (Panel panel in pnlMain.Controls)
                {
                    // Get the board cell from the panel tag
                    Point cellLoc = (Point)panel.Tag;
                    CellModel cell = _board.GetCellAt(cellLoc.X, cellLoc.Y);

                    PaintPanel(panel, cell);
                }
            }
            // Update the bomb and reward tracking labels
            lblBombsValue.Text = _board.GetNumberOfBombs().ToString("00");
            lblRewardsValue.Text = _board.GetNumberOfRewards().ToString("00");
        }

        /// <summary>
        /// Method to change the image property of each panel based on their cells information
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="cell"></param>
        private void PaintPanel(Panel panel, CellModel cell)
        {
            // If it is a flag flag it else
            if (cell.IsFlagged)
            {
                panel.BackgroundImage = _flaggedCellImage;
            }
            // If it is visited, alter the image based on the case
            else if (cell.IsVisited)
            {
                switch (cell.NumberOfBombNeighbors)
                {
                    case 0:
                        panel.BackgroundImage = _blankCellImage;
                        break;
                    case 1:
                        panel.BackgroundImage = _oneNeighborImage;
                        break;
                    case 2:
                        panel.BackgroundImage = _twoNeighborsImage;
                        break;
                    case 3:
                        panel.BackgroundImage = _threeNeighborsImage;
                        break;
                    case 4:
                        panel.BackgroundImage = _fourNeighborsImage;
                        break;
                    case 5:
                        panel.BackgroundImage = _fiveNeighborsImage;
                        break;
                    case 6:
                        panel.BackgroundImage = _sixNeighborsImage;
                        break;
                    case 7:
                        panel.BackgroundImage = _sevenNeighborsImage;
                        break;
                    case 8:
                        panel.BackgroundImage = _eightNeighborsImage;
                        break;
                    case 9:
                        panel.BackgroundImage = _nineNeighborsIsBombImage;
                        break;
                    default:
                        break;
                }
            }
            // If a cell is not flagged and it is not visited it is hidden.
            // this became necessary because removing a flag was breaking things
            // I was trying to avoid painting hidden cells every move but I ended up needing to
            else
            {
                panel.BackgroundImage = _hiddenCellImage;
            }
        }
    }
}
