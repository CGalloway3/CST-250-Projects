/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/23/2025
 * WhackAMole
 * Activity 5
 * References:
 */

using System.Drawing.Drawing2D;
using WhackAMoleGUI.PresentationLayer;
using WhackAMoleClassLibrary.Models;
using WhackAMoleClassLibrary.Services.GameLogicLayer;

namespace WhackAMoleGUI.PresentationLayer
{
    public partial class FrmStopwatch : Form
    {
        // Create a new Random object to generate numbers
        Random random = new Random();
        // Create a SettingsDTO object to hold the game settings
        SettingsDTO settingsDTO = new SettingsDTO();
        // Create the game logic object to score the game
        GameLogic gameLogic = new GameLogic();
        // flag for player not clicking at all
        private bool _missedClick = false;
        // Initialize the max amount for the random target interval
        private int _waveInterval = 1500;
        // Initialize the number of times we miss per wave
        private int _waveMisses = 0;

        /// <summary>
        /// Default constructor for the form
        /// </summary>
        public FrmStopwatch()
        {
            InitializeComponent();

            pnlGameArea.Cursor = new Cursor("Resources/Sniper.cur");

            // Initialize the score model
            gameLogic.gameScore = new GameScoreModel();

            // Call the reset click event handler to initialize the game settings
            BtnResetClickEH(this, EventArgs.Empty);
        }

        /// <summary>
        /// Click event handler for btnStart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartClickEH(object sender, EventArgs e)
        {
            // Send the wave label to the back and set it to fade out
            lblWave.SendToBack();
            lblHint.Visible = false;
            ShowWaveNumberWithDelay(gameLogic.currentWave);

            // This is not my callback this is an actual click event by the user
            if (e != EventArgs.Empty)
            {
                // If the game is currently running or paused catch these two cases when the user tries to start a new game
                if (tmrStopwatch.Enabled || btnPause.Text == "Resume")
                {
                    // Timer is already running so pause the game first if it in not already paused
                    if (btnPause.Text == "Pause")
                    {
                        BtnPauseClickEH(this, EventArgs.Empty);
                    }
                    // Else the btnPause.text is "Resume" so the game is already paused we can continue processing the start click event

                    // Timer was already running ask the user to restart or not?
                    if (DialogResult.Yes == MessageBox.Show("The game is already in progress.\nAre you sure you want to restart?", "Game In Progress", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    {
                        // Hide the target and reset missed click flag
                        btnTarget.Visible = false;
                        _missedClick = false;

                        // Stop the timer and call the click event handler again to restart
                        tmrStopwatch.Stop();
                        BtnStartClickEH(sender, EventArgs.Empty);
                        // Kill the current event with return to avoid infinite loops
                        return;
                    }
                    else
                    {
                        // DialogResult was No so return to the game with it paused
                        return;
                    }
                }
            }

            // Start the game over fresh with the current settings
            // Clear any paused state
            btnPause.Text = "Pause";
            // Reset the timeElapsed
            gameLogic.timeElapsed = new TimeSpan();
            // Show the reset time on the label.
            lblTimeElapsed.Text = gameLogic.timeElapsed.ToString();

            // Update the UI with the reset score
            UpdateTheUI();
            // Start the timer
            tmrStopwatch.Start();
        }

        /// <summary>
        /// Click event handler for the btnStop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPauseClickEH(object sender, EventArgs e)
        {
            if (tmrStopwatch.Enabled)
            {
                // Stop the Timer
                tmrStopwatch.Stop();
                btnPause.Text = "Resume";
            }
            else
            {
                // Start the Timer
                tmrStopwatch.Start();
                btnPause.Text = "Pause";
            }
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
            // Fire the PnlGameArea click event to register missed clicks when the timer ticks with out the user clicking the target or panel
            if (_missedClick)
            {
                UpdateTheUI();
                PnlGameAreaClickEH(this, EventArgs.Empty);                
            }

            // Wave time is up check if we need to stop the round (wave) or continue the game
            if (gameLogic.timeElapsed.TotalSeconds >= gameLogic.GetDuration().TotalSeconds)
            {
                // Stop the timer
                tmrStopwatch.Stop();
                // Advance the wave in game logic.
                gameLogic.WaveUp();


                // Game over check if we need to end the game or advance the wave
                // If the new wave is greater than the max wave count
                if (gameLogic.currentWave > gameLogic.GetMaxWaveCount())
                {
                   // Process the win in the UI
                    ProcessGameOver();
                }
                else
                {
                    // Advance the wave in UI
                    ProcessWaveUp();
                }

            }
            else if (tmrStopwatch.Enabled)// Continue the current wave if the game is still running (tmrStopwatch enabled)
            {
                // Increment the timeElapsed by the timer interval
                gameLogic.timeElapsed = gameLogic.timeElapsed.Add(TimeSpan.FromMilliseconds(tmrStopwatch.Interval));

                // Select a new location for the top of btnTarget
                // Randomly generate a location for the top of the button
                // between 0 and the panel height minus the button height
                btnTarget.Top = random.Next(0, (pnlGameArea.Height - btnTarget.Height));
                // Select a new location for the left side of btnTarget
                btnTarget.Left = random.Next(0, pnlGameArea.Width - btnTarget.Width);
                // Set the target to be visible
                btnTarget.Visible = true;
                // Randomize the next interval for the timer between 750ms and 1500ms
                tmrStopwatch.Interval = random.Next(750, _waveInterval);
                // Reset missed click flag  
                _missedClick = true;
            }




        } // End of TmrStopwatchTickEH

        /// <summary>
        /// Graphically process a wave up.
        /// the game logic will handle it for the data
        /// </summary>
        private void ProcessWaveUp()
        {
            // Show a message box with the final score
            MessageBox.Show($"Time's up!\n\nCurrent Score: {gameLogic.gameScore.Score}\nAccuracy: {gameLogic.gameScore.Accuracy.ToString("##.##")}%", "Advance to Next Wave", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Show the wave number
            UpdateWaveUI();
            _waveMisses = 0;
            _waveInterval = _waveInterval - 100;
        }

        /// <summary>
        /// Update the UI elements for each wave
        /// </summary>
        private void UpdateWaveUI()
        {
            ShowWaveNumber(gameLogic.currentWave);
            ShowHint();
            ChangePanelBackground(gameLogic.currentWave);
        }

        /// <summary>
        /// Method to change the background based on wave
        /// </summary>
        /// <param name="currentWave"></param>
        private void ChangePanelBackground(int currentWave)
        {
            switch (currentWave)
            {
                case 2:
                    pnlGameArea.BackgroundImage = WhackAMoleGUI.Resources.Wave2Background;
                    break;
                case 3:
                    pnlGameArea.BackgroundImage = WhackAMoleGUI.Resources.Wave3Background;
                    break;
                default:
                    pnlGameArea.BackgroundImage = WhackAMoleGUI.Resources.Wave1Background;
                    break;
            }
        }

        /// <summary>
        /// Method to handle a finished game win or loss
        /// </summary>
        private void ProcessGameOver()
        {
            // Show a message box with the final score
            MessageBox.Show($"Waves Complete!\n\nFinal Score: {gameLogic.gameScore.Score}\nAccuracy: {gameLogic.gameScore.Accuracy.ToString("##.##")}%", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Check if the score is a new high score
            bool isHighScore = gameLogic.AddScoreToList(gameLogic.gameScore);
            if (isHighScore)
            {
                MessageBox.Show("Congratulations! You achieved a new high score!", "New High Score", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateTheUI();
                BtnHighScoresClickEH(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show($"Better luck next time!\n {gameLogic.gameScore.Score} Is not high enough to hit the score board.", "No New High Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            // Reset score data in a new model instance but keep name and difficulty
            gameLogic.gameScore = new GameScoreModel(gameLogic.gameScore.Name, gameLogic.gameScore.Difficulty);
            gameLogic.currentWave = 1;
            ChangePanelBackground(gameLogic.currentWave);
            btnTarget.Visible = false;
            _waveMisses = 0;
            _waveInterval = 1500;
        }

        /// <summary>
        /// Click event handler for the btnReset
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetClickEH(object sender, EventArgs e)
        {
            // Stop any running timers
            tmrStopwatch.Stop();

            // Open the Setup Form
            Form setup = new FrmSetup(settingsDTO);
            setup.ShowDialog();

            // Store the difficulty settings from the setup form
            gameLogic.gameScore.Difficulty = (settingsDTO.BoardSize, settingsDTO.TargetSize);

            // Adjust the form sizes based on the settings
            this.Size = settingsDTO.BoardSize switch
            {
                0 => new Size(600, 400), // Small
                1 => new Size(800, 600), // Medium
                2 => new Size(1000, 800), // Large
                _ => this.Size
            };

            // Adjust the target size based on the settings
            btnTarget.Size = settingsDTO.TargetSize switch
            {
                2 => new Size(30, 30), // Small
                1 => new Size(60, 60), // Medium
                0 => new Size(90, 90), // Large
                _ => btnTarget.Size
            };

            // Make the button's region circular to account for size changes by difficulty
            UpdateButtonRegion();
            // Center the Wave Label and bring to front
            UpdateWaveUI();
            // Reset the game score and labels
            gameLogic.gameScore = new GameScoreModel(settingsDTO.PlayersName, gameLogic.gameScore.Difficulty);

            // Update the UI
            lblPlayerNameValue.Text = settingsDTO.PlayersName;
            UpdateTheUI();
        }

        /// <summary>
        /// Turns the button into a circle for better target calculations
        /// </summary>
        private void UpdateButtonRegion()
        {
            // Make the buttons region circular, handled here to account for the size changes by dificulty
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, btnTarget.Width, btnTarget.Height);
                btnTarget.Region = new Region(path);
            }
        }

        /// <summary>
        /// Click event handler for btnTarget to hide the target and score the hit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTargetClickEH(object sender, EventArgs e)
        {
            // Increment the targets hit
            gameLogic.gameScore.TargetsHit++;
            _missedClick = false;

            // Grab the click position
            MouseEventArgs mouseEvent = e as MouseEventArgs;

            // Store the click position)
            double clickX = mouseEvent.X;
            double clickY = mouseEvent.Y;

            // Calculate the center of the target
            double targetCenterX = btnTarget.Width / 2.0;
            double targetCenterY = btnTarget.Height / 2.0;

            // Store the x and y deltas
            double deltaX = targetCenterX - clickX;
            double deltaY = targetCenterY - clickY;

            // use Euclidean Distance Calculation
            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));

            // Increase score based on distance and target size
            int maxDistance = (int)Math.Sqrt(targetCenterX * targetCenterX + targetCenterY * targetCenterY);
            gameLogic.gameScore.Score += (100 - (int)(100 * distance / maxDistance)) * (settingsDTO.TargetSize + settingsDTO.BoardSize + 1);
            gameLogic.gameScore.Accuracy = (gameLogic.gameScore.Accuracy * ((int)(gameLogic.gameScore.TargetsHit + gameLogic.gameScore.TargetsMissed - 1)) + (100 - (int)(100 * distance / maxDistance))) / (int)(gameLogic.gameScore.TargetsHit + gameLogic.gameScore.TargetsMissed);
            btnTarget.Visible = false;
            UpdateTheUI();
        }

        /// <summary>
        /// Method to handle the players missed clicks on the target button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PnlGameAreaClickEH(object sender, EventArgs e)
        {
            // Increment the targets missed and update the UI
            _waveMisses++;
            gameLogic.gameScore.TargetsMissed++;
            UpdateTheUI();
            // Reset missed flag to false
            _missedClick = false;
            // Deduct the penalty for a miss from the score
            gameLogic.gameScore.Score -= 50;
            // End Game if the player missed too much in one wave
            if (_waveMisses >= 3)
            {
                tmrStopwatch.Stop();
                gameLogic.WaveUp();
                MessageBox.Show("You have missed the target three times on this wave the game is over.");
                ProcessGameOver();
            }
        }

        /// <summary>
        /// Simple UI update method to refresh the score and accuracy labels
        /// </summary>
        private void UpdateTheUI()
        {

            // Update the label with the new timeElapsed
            lblTimeElapsed.Text = gameLogic.timeElapsed.ToString(@"mm\:ss") + ($"   {(_missedClick ? "\"Missed\"" : "\"Hit\"")}   {gameLogic.gameScore.TargetsMissed} misses and {gameLogic.gameScore.TargetsHit} hits");

            lblAccuracyValue.Text = gameLogic.gameScore.Accuracy.ToString("##.##") + "%";
            lblScoreValue.Text = gameLogic.gameScore.Score.ToString("#,###");
        }

        /// <summary>
        /// Click event handler for the exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExitClickEH(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Click event handler for the high scores button. Displays the high scores form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHighScoresClickEH(object sender, EventArgs e)
        {
            Form scores = new FrmHighScores(gameLogic.GetHighScoresAtDifficultyString(gameLogic.gameScore.Difficulty));
            scores.ShowDialog();
        }

        /// <summary>
        /// Method to allow a hint to be shown at the start of each wave.
        /// </summary>
        private void ShowHint()
        {
            lblHint.Visible = true;
            lblHint.Left = lblWave.Left + 51;
            lblHint.Top = lblWave.Top + 56;
        }
        
        /// <summary>
        /// Method that centers the wave label inside the panel no matter the size.
        /// </summary>
        private void CenterWaveLabel()
        {
            lblWave.Left = (pnlGameArea.Width - lblWave.Width) / 2;
            lblWave.Top = (pnlGameArea.Height - lblWave.Height) / 2;
        }
        
        /// <summary>
        /// Show the wave number label with the param number passed in
        /// </summary>
        /// <param name="waveNumber"></param>
        private void ShowWaveNumber(int waveNumber)
        {
            lblWave.Text = $"Wave {waveNumber}";
            lblWave.Visible = true;
            CenterWaveLabel();
        }
        
        /// <summary>
        /// async Method to enable fading of the Wave number label
        /// </summary>
        /// <param name="waveNumber"></param>
        private async void ShowWaveNumberWithDelay(int waveNumber)
        {
            ShowWaveNumber(waveNumber);
            await Task.Delay(2000); // Show for 2 seconds
            lblWave.Visible = false;
        }        
    }
}
