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
    public partial class MainForm : Form
    {
        private SettingsHelper _mainFormSettings;
         
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
            MessageBox.Show($"update {_mainFormSettings.BoardSize}");

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillPanelWithCells();
        }

        private void FillPanelWithCells()
        {
            
        }

    }
}
