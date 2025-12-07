/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 5
 * References:
 */

using MinesweeperClassLibrary.Services.BusinessLogicLayer;
using MinesweeperClassLibrary.Models;
using MinesweeperClassLibrary.Models.DTOs;
using MinesweeperClassLibrary.Models.Enums;
using MinesweeperGUIApp.Forms;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using MinesweeperGUIApp.Utilities;

namespace MinesweeperGUIApp.UI.Forms
{
    /// <summary>
    /// Main Form for the Minesweeper Game Application
    /// </summary>
    public partial class MainForm : Form
    {
        // Declare settings and board objects
        private Panel _pauseOverlay;
        private Label _pauseLabel;
        private int _dx = 2, _dy = 2;
        private Random _random = new Random();
        private SoundManager _soundManager;
        private BoardLogic _boardLogic;
        private LeaderboardLogic _leaderboardLogic;
        private GameStat _gameStat;
        private bool _leaderBoardLoaded = false;

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
            // Initialize the game statistics object, the leaderboard, and sounds.
            _gameStat = new GameStat();
            _leaderboardLogic = new LeaderboardLogic();
            _soundManager = new SoundManager();

            // WinForms Init
            InitializeComponent();

            // Initialize the image resources
            InitializeImages();

            // Check to see if we have a previous game waiting to load
            if (File.Exists("Data/save.json"))
            {
                if (MessageBox.Show("Do you want to Load your progress?", "Load Progress?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ContinueSavedGame();
                }
                else
                {
                    StartNewGame();
                }
            }
            else
            {
                StartNewGame();
            }
            _soundManager.StartBackgroundMusic();
        }

        /// <summary>
        /// Wrapper methos for readability that calls the btnRestart click event.
        /// </summary>
        private void StartNewGame()
        {
            // Call the reset button click event handler to open the settings window before main form load.
            BtnRestartClickEH(this, EventArgs.Empty);
        }

        /// <summary>
        /// Method to contain all the start new game UI logic
        /// </summary>
        private void ContinueSavedGame()
        {
            // Initialize the board logic object with the saved board model
            _boardLogic = new BoardLogic("Data/save.json");

            // Size and fill the main panel with the loaded board logic
            FillPanelWithCells();
            // refresh the panel
            RefreshPanels(null);

            // Setup the game state as running but paused
            btnPause.Text = "Resume";
            tmrElapsedTime.Start();
            _pauseOverlay.Visible = true;

            // Reset the game stat object for a new games score tracking
            // and update the settings to match the current board
            _gameStat = new GameStat();
            _gameStat = _boardLogic.GetBoardSettings();
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
            // Play the sound tied to opening the settings form
            _soundManager.PlaySettings();

            // Open the setup form to get new settings
            Form setup = new SetupForm(_gameStat);
            setup.ShowDialog();

            // Reset the gameStat object for a new game
            _gameStat = _gameStat.RestartGame();

            // After setup form is closed initialize the Board logic and set the difficulty
            _boardLogic = new BoardLogic(_gameStat.BoardSize);
            _boardLogic.SetupBoardAtDifficulty(_gameStat.Difficulty);

            // Size and fill the main panel with the new board logic
            FillPanelWithCells();

            // Set the game state as running with paused disabled.
            btnPause.Text = "Pause";
            btnPause.Enabled = false;
            tmrElapsedTime.Start();
        }

        /// <summary>
        /// Method to fill the parent panel pnlMain with all the child panels that will represent the cells
        /// </summary>
        private void FillPanelWithCells()
        {
            // Board size = size setting (4, 8, 12, 16, etc...).
            // Number of cell = board size. Each cell is 25,25 in size
            // Board  panel starts at loc 12, 12 and is size 500. Form starts at size 680,560

            // Initialize the main Panel
            pnlMain.Controls.Clear();

            // Setup the board logics leaderboard load state
            _boardLogic.SetLeaderboardLoadedStatus(_leaderBoardLoaded);

            // Initialize the values of the labels holding bomb and reward data
            lblBombsValue.Text = _boardLogic.GetNumberOfBombs().ToString("00");
            lblRewardsValue.Text = _boardLogic.GetNumberOfRewards().ToString("00");

            // Adjust the size of the form depending on the size of the board. if-else to
            // catch super small boards and make them big enough to fit all the other controls
            if (_boardLogic.GetBoardSettings().BoardSize > 4)
            {
                this.Size = new Size((_boardLogic.GetBoardSettings().BoardSize * 25) + 180, (_boardLogic.GetBoardSettings().BoardSize * 25) + 60);
            }
            else // Small board so we will use the minimum size
            {
                this.Size = new Size((_boardLogic.GetBoardSettings().BoardSize * 25) + 180, (_boardLogic.GetBoardSettings().BoardSize * 25) + 160);
            }

            // Pause pnlMain layout until we add all the children
            pnlMain.SuspendLayout();
            // Iterate over all the cells and add the appropriate panel
            for (int row = 0; row < _boardLogic.GetBoardSettings().BoardSize; row++)
            {
                for (int col = 0; col < _boardLogic.GetBoardSettings().BoardSize; col++)
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

            // Lastly, we are going to create one large panel to cover the entire grid
            // that we can show and hide while the game is paused.
            // Initialize and format the pause panel
            _pauseOverlay = new Panel
            {
                Name = "pausePanel",
                BackColor = Color.FromArgb(64, 64, 64),
                Dock = DockStyle.Fill,
                Visible = false
            };

            // Initialize and format the pause label
            _pauseLabel = new Label
            {
                Text = "PAUSED",
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            };
            _pauseLabel.Location = new Point(
                (_pauseOverlay.Width - _pauseLabel.Width) / 2,
                (_pauseOverlay.Height - _pauseLabel.Height) / 2
            );
            
            // Add the label to the pause panel
            _pauseOverlay.Controls.Add(_pauseLabel);

            // Add the pause panel to the main panel
            pnlMain.Controls.Add(_pauseOverlay);
            _pauseOverlay.BringToFront();

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
            // If the game is starting initialize a new game stat object
            // and enable the pause button
            if (_boardLogic.GetGameState() == GameState.Starting)
            {
                btnPause.Enabled = true;
            }

            // Capture which button is clicked
            MouseEventArgs args = (MouseEventArgs)e;
            MouseButtons userClicked = args.Button;

            // Pull the cells location out of the panels tag
            Panel panel = (Panel)sender;
            Point cellLoc = (Point)panel.Tag;

            // If the game is still in progress or starting use mouse button to determine the proper next action.
            if (_boardLogic.GetGameState() == GameState.InProgress || _boardLogic.GetGameState() == GameState.Starting)
            {
                if (userClicked == MouseButtons.Left) // User Left clicked
                {
                    // Play the sound tied to revealing a cell
                    _soundManager.PlayReveal();

                    // Left click signifies visit. Call DetermineGameState with a visit command of 1
                    _boardLogic.DetermineGameState(cellLoc.X, cellLoc.Y, 1);
                    // Refresh pnlMain layout
                    RefreshPanels(panel);
                    // Remove any border styles applied previously by using rewards
                    panel.BorderStyle = BorderStyle.None;
                }
                else if (userClicked == MouseButtons.Right) // User Right clicked
                {
                    // Play the sound tied to flagging a cell
                    _soundManager.PlayFlag();

                    // Right click signifies flag. Call DetermineGameState with a flag command of 2
                    if (_boardLogic.DetermineGameState(cellLoc.X, cellLoc.Y, 2))
                    {
                        // Cell is now flagged. Refresh pnlMain layout
                        RefreshPanels(panel);
                        // Remove any border styles applied previously by using rewards
                        panel.BorderStyle = BorderStyle.None;
                    }
                    else
                    {
                        // Cell is not flagged (error occurred)
                        MessageBox.Show(_boardLogic.ErrorMessage);
                    }
                }
                else // User clicked any other mouse button (use reward)
                {
                    // Make sure there are rewards left
                    if (_boardLogic.GetNumberOfRewards() > 0)
                    {
                        // Other clicks signify use reward. Call DetermineGameState with a reward command of 3
                        if (_boardLogic.DetermineGameState(cellLoc.X, cellLoc.Y, 3))
                        {
                            // Play the sound for found bomb
                            _soundManager.PlayFoundBomb();
                            // Bomb exists here
                            MessageBox.Show(" This cell has a bomb! ");
                        }
                        else
                        {
                            // Play the sound for missed bomb
                            _soundManager.PlayMissBomb();
                            // Bomb does not exists in cell
                            MessageBox.Show(" This cell does NOT have a bomb. ");
                        }
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
            // Call visit again to clear reward game states
            if (_boardLogic.GetGameState() == GameState.RewardFound)
            {
                _boardLogic.DetermineGameState(cellLoc.X, cellLoc.Y, 1);
            }
        }

        /// <summary>
        /// Method to catch the different game states and notify the user of what happened.
        /// </summary>
        private void StateCheck()
        {
            switch (_boardLogic.GetGameState())
            {
                case GameState.Lost:
                    // Play the sound tied to revealing a bomb.
                    _soundManager.PlayHitBomb();

                    // Reveal all the bombs on the board for the user after a loss
                    RevealAllBombs();
                    MessageBox.Show(" Sorry, you have hit a bomb. ", " Game Over. ");

                    // Play the sound tied to losing the game.
                    _soundManager.PlayLose();
                    break;

                case GameState.Won:
                    // Play the sound tied to winning the game.
                    _soundManager.PlayWin();

                    // Update the game stat object with final stats
                    _gameStat.Score = _boardLogic.GetScore();
                    // Show win notification form and store the players name.
                    FrmWinNotification winNotification = new FrmWinNotification(_gameStat);
                    winNotification.ShowDialog();

                    // Store the game stat in the leaderboard entries list
                    _gameStat.DatePlayed = _boardLogic.GetStartTime();
                    _gameStat.Id = _leaderboardLogic.Count() + 1;
                    _gameStat.BoardSize = _boardLogic.GetBoardSettings().BoardSize;
                    _leaderboardLogic.GetEntries().Add(_gameStat);

                    // After win notification is closed and stats are stored show the leaderboard.
                    // Play the sound tied to showing the leaderboard
                    _soundManager.PlayLeaders();
                    ShowLeaderboard();
                    break;

                case GameState.RewardFound:
                    // Play the sound tied to finding a reward
                    _soundManager.PlayReward();
                    MessageBox.Show(" You found a reward. ");
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Method to show the leaderboard form
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void ShowLeaderboard()
        {
            // Declare and Initialize
            Form leaderboardForm = new FrmLeaderboard(_gameStat, _leaderboardLogic, _boardLogic);
            leaderboardForm.ShowDialog();

            // Set leaderboard loaded flag on the main form
            _leaderBoardLoaded = _boardLogic.IsLeaderboardLoaded();
        }

        /// <summary>
        /// Show all bomb locations to the user after a loss
        /// </summary>
        private void RevealAllBombs()
        {
            foreach (Panel panel in pnlMain.Controls)
            {
                // catch the pausePanel to prevent errors
                if (panel.Name == "pausePanel")
                {
                    continue;
                }

                // Get the board cell from the panel tag
                Point cellLoc = (Point)panel.Tag;
                CellModel cell = _boardLogic.GetCellAt(cellLoc.X, cellLoc.Y);

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
            if (primaryPanel != null)
            {
                // Declare and Initialize
                Point primaryLoc = (Point)primaryPanel.Tag;
                CellModel primaryCell = _boardLogic.GetCellAt(primaryLoc.X, primaryLoc.Y);

                // Short cut check for flood fill, if we have neighbors simply paint the panel.
                // Else we found a void and will iterate over all the panels to update them all.
                if (!(primaryCell.NumberOfBombNeighbors == 0))
                {
                    PaintSinglePanel(primaryPanel, primaryCell);
                }
                else
                {
                    PaintAllPanels();
                }
            }
            else
            {
                PaintAllPanels();
            }

            // Update the bomb and reward tracking labels
            lblBombsValue.Text = _boardLogic.GetNumberOfBombs().ToString("00");
            lblRewardsValue.Text = _boardLogic.GetNumberOfRewards().ToString("00");

        }

        /// <summary>
        /// Paint all the child panels in the main panel
        /// </summary>
        private void PaintAllPanels()
        {
            foreach (Panel panel in pnlMain.Controls)
            {
                // catch the pausePanel to prevent errors
                if (panel.Name == "pausePanel")
                {
                    continue;
                }

                // Get the board cell from the panel tag
                Point cellLoc = (Point)panel.Tag;
                CellModel cell = _boardLogic.GetCellAt(cellLoc.X, cellLoc.Y);

                PaintSinglePanel(panel, cell);
            }
        }

        /// <summary>
        /// Method to change the image property of each panel based on their cells information
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="cell"></param>
        private void PaintSinglePanel(Panel panel, CellModel cell)
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

        /// <summary>
        /// Form Closing event handler to deal with game saving on close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFormClosingEH(object sender, FormClosingEventArgs e)
        {
            // Get the games current state
            GameState gameState = _boardLogic.GetGameState();

            // If the game is in progress or paused ask the user if they want to save
            if (gameState == GameState.InProgress || gameState == GameState.Paused)
            {
                if (MessageBox.Show("Do you want to Save your progress?", "Save Progress?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (gameState != GameState.Paused)
                    { 
                        _boardLogic.PauseGame(); 
                    }
                    _boardLogic.SaveGame();
                }
            }

        }

        /// <summary>
        /// Pause button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPauseClickEH(object sender, EventArgs e)
        {
            _soundManager.PlayPause();

            if (_boardLogic.GetGameState() != GameState.Paused)
            {
                _boardLogic.PauseGame();
                _soundManager.PauseBackgroundMusic();
                btnPause.Text = "Resume";
                _pauseOverlay.Visible = true;
            }
            else
            {
                _boardLogic.ResumeGame();
                _soundManager.ResumeBackgroundMusic();
                btnPause.Text = "Pause";
                _pauseOverlay.Visible = false;
            }
        }

        /// <summary>
        /// Tick event handler for the timer to update the time counter and the pause overlay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrElapsedTimeTickEH(object sender, EventArgs e)
        {
            lblTimeValue.Text = _boardLogic.GetCurrentElapsedTime().ToString(@"h\:mm\:ss");

            int ticks = (int)tmrElapsedTime.Tag;
            ticks++;
            tmrElapsedTime.Tag = ticks;

            if (_pauseOverlay.Visible)
            {
                BounceLabel();
            }

        }

        /// <summary>
        /// Method to bounce the pause label and change colors
        /// </summary>
        private void BounceLabel()
        {
            _pauseLabel.Left += _dx;
            _pauseLabel.Top += _dy;

            if (_pauseLabel.Left <= 0 || _pauseLabel.Right >= _pauseOverlay.Width)
                _dx = -_dx;

            if (_pauseLabel.Top <= 0 || _pauseLabel.Bottom >= _pauseOverlay.Height)
                _dy = -_dy;
            
            _pauseLabel.BackColor = Color.FromArgb(100, _random.Next(256), _random.Next(256), _random.Next(256));
            if ((int)tmrElapsedTime.Tag >= 10)
            {
                _pauseOverlay.BackColor = Color.FromArgb(200, _random.Next(256), _random.Next(256), _random.Next(256));
                tmrElapsedTime.Tag = 0;
            }
        }
    }
}
