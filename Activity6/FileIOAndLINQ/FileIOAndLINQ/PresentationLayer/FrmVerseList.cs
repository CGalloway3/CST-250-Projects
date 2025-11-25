/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/30/2025
 * File IO and LINQ
 * Activity 6
 * References:
 */


using System.Text.RegularExpressions;

namespace FileIOAndLINQ.PresentationLayer
{
    public partial class FrmVerseList : Form
    {
        // Declare class level variables
        private List<Label> _errorLabels;
        // Flags for user input
        bool isValidBook = false, isValidChapter = false, isValidVerse = false;
        bool isValidText = false, isValidMeaning = false, isValidImportance = false;

        public FrmVerseList()
        {
            InitializeComponent();
            // Initialize and hide the error list
            InitializeErrors();
            // Initialize cmbVerseBooks
            InitializeBooks();
        }

        /// <summary>
        /// Initialize the errors list
        /// </summary>
        private void InitializeErrors()
        {
            // Initialize the error label list
            _errorLabels = new List<Label>
            {
                lblBookError, lblChapterError,
                lblVerseError, lblTextError,
                lblMeaningError, lblImportanceError
            };
            // Loop through the error label list
            foreach (Label errorLabel in _errorLabels)
            {
                // Hide each label
                errorLabel.Visible = false;
            }
        }

        /// <summary>
        /// Set up the verse book combo box
        /// </summary>
        private void InitializeBooks()
        {
            // Set up a list of books of the Bible
            List<string> bibleBooks = new List<string>
                {
                    // Old Testament
                    "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy",
                    "Joshua", "Judges", "Ruth", "1 Samuel", "2 Samuel",
                    "1 Kings", "2 Kings", "1 Chronicles", "2 Chronicles", "Ezra",
                    "Nehemiah", "Esther", "Job", "Psalms", "Proverbs",
                    "Ecclesiastes", "Song of Solomon", "Isaiah", "Jeremiah", "Lamentations",
                    "Ezekiel", "Daniel", "Hosea", "Joel", "Amos",
                    "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk",
                    "Zephaniah", "Haggai", "Zechariah", "Malachi",

                    // New Testament
                    "Matthew", "Mark", "Luke", "John", "Acts",
                    "Romans", "1 Corinthians", "2 Corinthians", "Galatians", "Ephesians",
                    "Philippians", "Colossians", "1 Thessalonians", "2 Thessalonians", "1 Timothy",
                    "2 Timothy", "Titus", "Philemon", "Hebrews", "James",
                    "1 Peter", "2 Peter", "1 John", "2 John", "3 John",
                    "Jude", "Revelation"
                };

            // Populate cmbVerseBook with the list
            cmbVerseBook.DataSource = bibleBooks;
            // Set the automatically selected book to -1 (none)
            cmbVerseBook.SelectedIndex = -1;
            // Set the combo box to suggest books based on the user typing
            cmbVerseBook.AutoCompleteMode = AutoCompleteMode.Suggest;
            // Set the autocomplete source to the list items
            cmbVerseBook.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        /// <summary>
        /// Leave event handler for the book combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbVerseBookLeaveEH(object sender, EventArgs e)
        {
            // Check if the user has selected a book
            if (cmbVerseBook.SelectedIndex >= 0)
            {
                // Set the book flag to true
                isValidBook = true;
                // Hide the book error label
                lblBookError.Visible = false;
            }
            else
            {
                // Set the book flag to false
                isValidBook = false;
                // Update the book error label
                lblBookError.Text = "You must select a book";
                // Show the book error label
                lblBookError.Visible = true;
            }
        }

        /// <summary>
        /// Leave event handler to make sure the user entered a number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtVerseChapterLeaveEH(object sender, EventArgs e)
        {
            // Declare and Initialize
            // RegEx pattern to check that the chapter is a number
            Regex regex = new Regex("^[0-9]+$");
            // Match object to hold the result of the RegEx comparison
            Match match;

            // Compare the regex pattern to the textbox text
            match = regex.Match(txtVerseChapter.Text);
            // Check if the match was a success
            if (match.Success)
            {
                // Set the chapter flag to true
                isValidChapter = true;
                // Hide the chapter error label
                lblChapterError.Visible = false;
            }
            else
            {
                // Set the chapter flag to false
                isValidChapter = false;
                // Update the text for the chapter error label
                lblChapterError.Text = "The chapter must be a number";
                // Show the chapter error label
                lblChapterError.Visible = true;
            }
        }

        /// <summary>
        /// Leave event handler to validate verse input from the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtVerseVerseLeaveEH(object sender, EventArgs e)
        {
            // Declare and Initialize
            // RegEx pattern to validate the verse
            Regex regex = new Regex(@"^\d+(?:-\d+)?$");
            // Match object to hold the result of the comparison
            bool match;

            // Match the RegEx pattern with the verse text
            match = regex.IsMatch(txtVerseVerse.Text);
            // Check if the match was a success
            if (match)
            {
                // Set the verse flag to true
                isValidVerse = true;
                // Hide the verse error label
                lblVerseError.Visible = false;
            }
            else
            {
                // Set the verse flag to false
                isValidVerse = false;
                // Update the verse error label
                lblVerseError.Text = "The verse must be a number/range";
                // Show the verse error label
                lblVerseError.Visible = true;
            }
        }

        /// <summary>
        /// Leave event handler for txtVerseText
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtVerseTextLeaveEH(object sender, EventArgs e)
        {
            // Check to make sure the user entered text for the verse
            if (!string.IsNullOrWhiteSpace(txtVerseText.Text))
            {
                // Set the valid text flag to true
                isValidText = true;
                // Hide the error label
                lblTextError.Visible = false;
            }
            else
            {
                // Make sure the valid text flag is false
                isValidText = false;
                // Update the error label
                lblTextError.Text = "The text cannot be blank";
                // Show the error label
                lblTextError.Visible = true;
            }
        }
    }
}
