/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 12/07/2025
 * Mine Sweeper Class Library
 * Milestone 6
 * References:Mixkit. (n.d.). Mixkit. https://mixkit.co/
 *             OpenGameArt.org. (n.d.). OpenGameArt.org. https://opengameart.org/
 *             Used to acquire all game sound effects.
 */
using System.Media;
using WMPLib;

namespace MinesweeperGUIApp.Utilities
{
    public class SoundManager
    {
        // Class level variables
        private WMPLib.WindowsMediaPlayer _musicPlayer;
        private Random _random;
        private List<string>? _musicTracks;
        WMPLib.IWMPPlaylist _playlist;

        // Sound effect variables
        private SoundPlayer? _revealSound;
        private SoundPlayer? _flagSound;
        private SoundPlayer? _hitBombSound;
        private SoundPlayer? _winSound;
        private SoundPlayer? _loseSound;
        private SoundPlayer? _rewardSound;
        private SoundPlayer? _leadersSound;
        private SoundPlayer? _pauseSound;
        private SoundPlayer? _settingsSound;
        private SoundPlayer? _foundBombSound;
        private SoundPlayer? _missBombSound;

        /// <summary>
        /// Public default constructor for the sound manager class
        /// </summary>
        public SoundManager()
        {
            // Initialize random, background music player, and player settings
            _random = new Random();
            _musicPlayer = new WindowsMediaPlayer();
            _musicPlayer.settings.volume = 30; // 0-100
            // Enable loop and shuffle
            _musicPlayer.settings.setMode("loop", true);
            _musicPlayer.settings.setMode("shuffle", true);
            _playlist = _musicPlayer.playlistCollection.newPlaylist("BackgroundMusic");

            // Load all music files from the Music folder
            LoadMusicTracks();

            // Load sounds effect files from the Effects folder 
            LoadSoundEffectFiles();

            // Pre-load sounds to avoid delay on first play
            PreLoadEffects();
        }

        // Background Music Methods
        /// <summary>
        /// Start playing the background music
        /// </summary>
        /// <param name="filePath"></param>
        public void StartBackgroundMusic()
        {
            if (_musicTracks != null && _musicTracks.Count > 0)
            {
                PlayBackgroundTracks();
            }
        }

        /// <summary>
        /// Stop background music play
        /// </summary>
        public void StopBackgroundMusic()
        {
            _musicPlayer.controls.stop();
        }

        /// <summary>
        /// Pause the background music
        /// </summary>
        public void PauseBackgroundMusic()
        {
            _musicPlayer.controls.pause();
        }

        /// <summary>
        /// Resume the paused music
        /// </summary>
        public void ResumeBackgroundMusic()
        {
            _musicPlayer.controls.play();
        }

        /// <summary>
        /// Method to support the users ability to adjust the background music volume
        /// </summary>
        /// <param name="volume"></param>
        public void SetMusicVolume(int volume) // 0-100
        {
            _musicPlayer.settings.volume = volume;
        }

        // Expression-bodied member Sound Effect Methods
        public void PlayReveal() => _revealSound.Play();
        public void PlayFlag() => _flagSound.Play();
        public void PlayHitBomb() => _hitBombSound.Play();
        public void PlayWin() => _winSound.Play();
        public void PlayLose() => _loseSound.Play();
        public void PlayReward() => _rewardSound.Play();
        public void PlayLeaders() => _leadersSound.Play();
        public void PlayPause() => _pauseSound.Play();
        public void PlaySettings() => _settingsSound.Play();
        public void PlayFoundBomb() => _foundBombSound.Play();
        public void PlayMissBomb() => _missBombSound.Play();

        /// <summary>
        /// Play a random track from the list for the background music
        /// </summary>
        private void PlayBackgroundTracks()
        {
            // Shortcut return it there are no tracks in the list (folder was empty)
            if (_musicTracks.Count == 0) return;

            // Add songs to the playlist
            foreach (string trackPath in _musicTracks)
            {
                WMPLib.IWMPMedia mediaItem = _musicPlayer.newMedia(trackPath);
                _playlist.appendItem(mediaItem);
            }

            // Set this as the player's current playlist and start playback
            _musicPlayer.currentPlaylist = _playlist;

            // AutoStart is usually true by default. If not:
            _musicPlayer.controls.play();
        }
        
        // Loading Methods
        /// <summary>
        /// Load all music files from the Music directory
        /// </summary>
        private void LoadMusicTracks()
        {
            _musicTracks = new List<string>();

            string musicFolder = Path.Combine(Application.StartupPath, "Resources", "Sounds", "Music");

            // Create Music folder if it doesn't exist
            if (!Directory.Exists(musicFolder))
            {
                Directory.CreateDirectory(musicFolder);
                return; // No tracks to load yet
            }

            // Get all supported audio file types
            var musicFiles = Directory.GetFiles(musicFolder, "*.*")
                .Where(file => file.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase) ||
                              file.EndsWith(".wav", StringComparison.OrdinalIgnoreCase) ||
                              file.EndsWith(".wma", StringComparison.OrdinalIgnoreCase) ||
                              file.EndsWith(".m4a", StringComparison.OrdinalIgnoreCase))
                .ToList();

            _musicTracks = musicFiles;
        }

        /// <summary>
        /// Load all sound effect files from the effects directory
        /// </summary>
        private void LoadSoundEffectFiles()
        {
            // Set up the directory structure for the sound effects
            string musicFolder = Path.Combine(Application.StartupPath, "Resources", "Sounds", "Effects");

            // Load in all the sound files to their respective variables
            _revealSound = new SoundPlayer(Path.Combine(musicFolder, "reveal.wav"));
            _flagSound = new SoundPlayer(Path.Combine(musicFolder, "flag.wav"));
            _hitBombSound = new SoundPlayer(Path.Combine(musicFolder, "hitBomb.wav"));
            _winSound = new SoundPlayer(Path.Combine(musicFolder, "win.wav"));
            _loseSound = new SoundPlayer(Path.Combine(musicFolder, "lose.wav"));
            _rewardSound = new SoundPlayer(Path.Combine(musicFolder, "findReward.wav"));
            _leadersSound = new SoundPlayer(Path.Combine(musicFolder, "leaders.wav"));
            _pauseSound = new SoundPlayer(Path.Combine(musicFolder, "pause.wav"));
            _settingsSound = new SoundPlayer(Path.Combine(musicFolder, "settings.wav"));
            _foundBombSound = new SoundPlayer(Path.Combine(musicFolder, "foundBomb.wav"));
            _missBombSound = new SoundPlayer(Path.Combine(musicFolder, "missBomb.wav"));
        }

        /// <summary>
        /// Method for preloading all the sound effects into the game
        /// Doing this avoids short delays the first time a sound plays
        /// </summary>
        private void PreLoadEffects()
        {
            // Preload all the sounds
            _revealSound.Load();
            _flagSound.Load();
            _hitBombSound.Load();
            _winSound.Load();
            _loseSound.Load();
            _rewardSound.Load();
            _leadersSound.Load();
            _pauseSound.Load();
            _settingsSound.Load();
            _foundBombSound.Load();
            _missBombSound.Load();
        }
    }
}

