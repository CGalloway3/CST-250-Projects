/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/23/2025
 * WhackAMole
 * Activity 5
 * References:
 */

namespace WhackAMole
{
    public partial class FrmStopwatch : Form
    {
        // Class level variable to hold the timers time.
        TimeSpan timeElapsed = new TimeSpan();

        public FrmStopwatch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click event handler for btnStart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClickEH(object sender, EventArgs e)
        {
            // Start the timer
            tmrStopwatch.Start();
        }

        /// <summary>
        /// Click event handler for the btnStop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStopClickEH(object sender, EventArgs e)
        {
            // Stop the Timer
            tmrStopwatch.Stop();
        }

        /// <summary>
        /// Tick even handler for tmrStopwatch
        /// Updates the timeElapsed variable and the label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrStopwatchTickEH(object sender, EventArgs e)
        {
            // Get the tmrStopwatch interval
            int interval = tmrStopwatch.Interval;
            // Add the timers interval to the total timeElapsed variable
            timeElapsed = timeElapsed.Add(TimeSpan.FromMilliseconds(interval));
            // Show the timeElapsed om the label
            lblTimeElapsed.Text = timeElapsed.ToString();
        }

        /// <summary>
        /// Click event handler for the btnReset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetClickEH(object sender, EventArgs e)
        {
            // stop the timer
            tmrStopwatch.Stop();
            // Reset the timeElapsed
            timeElapsed = new TimeSpan();
            // Show the reset time on the label.
            lblTimeElapsed.Text = timeElapsed.ToString();
        }
    }
}
