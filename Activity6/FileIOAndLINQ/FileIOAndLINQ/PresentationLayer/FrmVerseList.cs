/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/30/2025
 * File IO and LINQ
 * Activity 6
 * References:
 */


namespace FileIOAndLINQ.PresentationLayer
{
    public partial class FrmVerseList : Form
    {
        // Declare class level variables
        private List<Label> _errorLabels;

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
    }
}
