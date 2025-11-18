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
        // Create a new Random object to generate numbers
        Random random = new Random();

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
        /// Moves btnTarget every three seconds
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
            // Check if it is time to move the target button
            if (timeElapsed.Seconds % 3 == 0)
            {
                // Select a new location for the top of btnTarget
                // Randomly generate a location for the top of the button
                // between 0 and the form height minus the button height
                btnTarget.Top = random.Next(0, (this.Height - btnTarget.Height));
                // Select a new location for the left side of btnTarget
                btnTarget.Left = random.Next(0, this.Width - btnTarget.Width);
                // Get random numbers for the RGB color for the button
                btnTarget.BackColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                // Set the target to be visible
                btnTarget.Visible = true;
            }
        } // End of TmrStopwatchTickEH

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

        /// <summary>
        /// Click event handler for btnTarget to hide the target
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTargetClickEH(object sender, EventArgs e)
        {
            btnTarget.Visible = false;
        }
    }
}
