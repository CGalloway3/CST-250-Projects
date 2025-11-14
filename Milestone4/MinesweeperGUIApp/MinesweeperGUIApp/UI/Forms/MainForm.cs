/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/16/2025
 * Mine Sweeper Class Library
 * Milestone 4
 * References:
 */

using MinesweeperGUIApp.BusinessLogicLayer;
using MinesweeperGUIApp.Models;
using MinesweeperGUIApp.Models.Enums;
using MinesweeperGUIApp.Utilities;

namespace MinesweeperGUIApp.UI.Forms
{
    public partial class MainForm : Form
    {
        private SettingsHelper _mainFormSettings;
        private BoardLogic _board;
         
        public MainForm()
        {
            InitializeComponent();
            _mainFormSettings = new SettingsHelper();
            btnRestart_Click(this, EventArgs.Empty);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Form setup = new UI.Forms.Setup(_mainFormSettings);
            setup.ShowDialog();
            FillPanelWithCells();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void FillPanelWithCells()
        {
            // Board size = size setting * 10 (100, 200, 300, 400, etc...).
            // Number of cell = board size / 25. Each cell is 25,25 in size
            // Board Starts at loc 12, 12 and is size 500. Form starts at size 680,560

            // Declare and Initialize
            pnlMain.Controls.Clear();
            _board = new BoardLogic((_mainFormSettings.BoardSize * 10) / 25);

            // Setup the board
            _board.SetDifficulty(_mainFormSettings.Difficulty);
            _board.SetupBombs();
            _board.CountBombsNearby();
 
            // Adjust the size of the form depending on the size of the board. if-else to
            // catch super small boards and make them big enough to fit all the other controls
            if (_mainFormSettings.BoardSize > 10)
            {
                this.Size = new Size((_mainFormSettings.BoardSize * 10) + 180, (_mainFormSettings.BoardSize * 10) + 60);
            }
            else
            {
                this.Size = new Size((_mainFormSettings.BoardSize * 10) + 180, (_mainFormSettings.BoardSize * 10) + 160);
            }
                
            for (int row = 0; row < _board.GetBoardSize(); row++)
            {
                for (int col = 0; col < _board.GetBoardSize(); col++)
                {
                    Panel panel = new Panel();
                    panel.Size = new Size(25, 25);
                    panel.Location = new Point((row) * 25, (col) * 25);
                    panel.BackgroundImage = Properties.Resources.Minesweeper_Hidden_Cell;
                    panel.BackgroundImageLayout = ImageLayout.Stretch;
                    panel.Tag = new Point(row, col);
                    panel.Click += PanelCellsClickEH;    
                    pnlMain.Controls.Add(panel);
                }
            }
       }

        private void PanelCellsClickEH(object? sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;
            Panel panel = (Panel)sender;
            Point cell = (Point)panel.Tag;
            if (_board.GetGameState() == GameState.InProgress || _board.GetGameState() == GameState.RewardFound)
            {
                if (args.Button == MouseButtons.Left)
                {
                    _board.DetermineGameState(cell.X, cell.Y, 1);

                    RefreshPanels();
                }
                else if (args.Button == MouseButtons.Right)
                {
                    _board.DetermineGameState(cell.X, cell.Y, 2);
                    RefreshPanels();
                }
                else
                {
                    MessageBox.Show("use reward");
                    _board.DetermineGameState(cell.X, cell.Y, 3);
                    RefreshPanels();
                }
            }
            // State Check
            StateCheck(panel);
        }

        private void StateCheck(Panel panel)
        {
            switch (_board.GetGameState())            
            {
                case GameState.Lost:
                    MessageBox.Show(" You lost try again.");
                    break;

                case GameState.Won:
                    MessageBox.Show(" You Won!! Great Job.");
                    break;

                case GameState.RewardFound:
                    MessageBox.Show(" You found a reward. ");
                    break ;

                default:
                    break;
            }
        }

        private void RefreshPanels()
        {
            foreach (Panel panel in pnlMain.Controls)
            {
                // Get the board cell from the panel tag
                Point cellLoc = (Point)panel.Tag;
                CellModel cell = _board.GetCellAt(cellLoc.X, cellLoc.Y);

                    if (cell.IsFlagged)
                    {
                        panel.BackgroundImage = Properties.Resources.Minesweeper_Flagged_Cell;
                    }
                else if (cell.IsVisited)
                {
                    switch (cell.NumberOfBombNeighbors)
                    {
                        case 0:
                            panel.BackgroundImage = Properties.Resources.Minesweeper_Blank_Cell;
                            break;
                        case 1:
                            panel.BackgroundImage = Properties.Resources.Minesweeper_1;
                            break;
                        case 2:
                            panel.BackgroundImage = Properties.Resources.Minesweeper_2;
                            break;
                        case 3:
                            panel.BackgroundImage = Properties.Resources.Minesweeper_3;
                            break;
                        case 4:
                            panel.BackgroundImage = Properties.Resources.Minesweeper_4;
                            break;
                        case 5:
                            panel.BackgroundImage = Properties.Resources.Minesweeper_5;
                            break;
                        case 6:
                            panel.BackgroundImage = Properties.Resources.Minesweeper_6;
                            break;
                        case 7:
                            panel.BackgroundImage = Properties.Resources.Minesweeper_7;
                            break;
                        case 8:
                            panel.BackgroundImage = Properties.Resources.Minesweeper_8;
                            break;
                        case 9:
                            panel.BackgroundImage = Properties.Resources.Minesweeper_Bomb_Cell;
                            break;
                        default:
                            break;
                    }
                }
                
                    else
                    {
                        panel.BackgroundImage = Properties.Resources.Minesweeper_Hidden_Cell;
                    }
                
            }
        }
    }
}
