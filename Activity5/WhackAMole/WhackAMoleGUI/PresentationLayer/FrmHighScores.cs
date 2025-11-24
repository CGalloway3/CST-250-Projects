/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/23/2025
 * WhackAMole
 * Activity 5
 * References:
 */

namespace WhackAMoleGUI.PresentationLayer
{
    public partial class FrmHighScores : Form
    {
        /// <summary>
        /// Parameterized constructor to load the string representing the scores into the forms label.
        /// </summary>
        /// <param name="scores"></param>
        public FrmHighScores(string scores)
        {
            InitializeComponent();
            lblHighScores.Text = scores;
        }
    }
}
