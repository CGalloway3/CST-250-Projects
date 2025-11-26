/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/30/2025
 * File IO and LINQ
 * Activity 6
 * References:
 */


using FileIOAndLINQ.Models;
using FileIOAndLINQ.Services.BusinessLogicLayer;
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
        // Business Logic Variable
        private VerseLogic _verseLogic;
        // Binding source for the data grid view
        private BindingSource _versesBindingSource;

        public FrmVerseList()
        {
            InitializeComponent();
            // Initialize and hide the error list
            InitializeErrors();
            // Initialize cmbVerseBooks
            InitializeBooks();
            // Initialize the verse logic variable
            _verseLogic = new VerseLogic();
            // Initialize the binding source object
            _versesBindingSource = new BindingSource();
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

        /// <summary>
        /// Leave event handler for txtVerseMeaning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtVerseMeaningLeaveEH(object sender, EventArgs e)
        {
            // Check to make sure the user entered a meaning for the verse
            if (!string.IsNullOrWhiteSpace(txtVerseMeaning.Text))
            {
                // Set the valid meaning flag to true
                isValidMeaning = true;
                // Hide the error label
                lblMeaningError.Visible = false;
            }
            else
            {
                // Make sure the valid meaning flag is false
                isValidMeaning = false;
                // Update the error label
                lblMeaningError.Text = "The meaning cannot be blank";
                // Show the error label
                lblMeaningError.Visible = true;
            }
        }

        /// <summary>
        /// Leave event handler to validate importance input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NudVerseImportanceLeaveEH(object sender, EventArgs e)
        {
            // Check if the value is between 1 and 10
            if (nudVerseImportance.Value >= 1 && nudVerseImportance.Value <= 10)
            {
                // Set the importance flag to true
                isValidImportance = true;
                // Hide the importance error label
                lblImportanceError.Visible = false;
            }
            else
            {
                // Set the importance flag to false
                isValidImportance = false;
                // Update the importance error label
                lblImportanceError.Text = "The importance must be 1 - 10";
                // Show the importance error label
                lblImportanceError.Visible = true;
            }
        }

        /// <summary>
        /// Click event handler for add a new verse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddVerseClickEH(object sender, EventArgs e)
        {
            // Declare and Initialize
            int chapter = -1;
            VerseRequestModel verse;

            // Check flags to see if the user entered valid data
            if (isValidBook && isValidChapter && isValidVerse && isValidText && isValidMeaning && isValidImportance)
            {
                // Set up a try-catch to cast the chapter to an int
                try
                {
                    // Parse Chapter to int
                    chapter = int.Parse(txtVerseChapter.Text);
                }
                catch
                {
                    // Update the error label for the chapter
                    lblChapterError.Text = "The chapter must be a number";
                    // Show the chapter error label
                    lblChapterError.Visible = true;
                }
                // Create the verse variable
                verse = new VerseRequestModel(cmbVerseBook.Text, chapter, txtVerseVerse.Text,
                    txtVerseText.Text, txtVerseMeaning.Text, (int)nudVerseImportance.Value);
                // Add the new verse using the _verseLogic variable
                _verseLogic.AddVerse(verse);
                // Clear the input fields
                ClearInputFields();
                // Refresh the data grid view
                RefreshVerseDgv();
            }
            // Check if the book is invalid
            else if (!isValidBook)
            {
                // Show the book error label
                lblBookError.Visible = true;
            }
            // Check if the chapter is invalid
            else if (!isValidChapter)
            {
                // Show the chapter error label
                lblChapterError.Visible = true;
            }
            // Check if the verse is invalid
            else if (!isValidVerse)
            {
                // Show the verse error label
                lblVerseError.Visible = true;
            }
            // Check if the text is invalid
            else if (!isValidText)
            {
                // Show the text error label
                lblTextError.Visible = true;
            }
            // Check if the meaning is invalid
            else if (!isValidMeaning)
            {
                // Show the meaning error label
                lblMeaningError.Visible = true;
            }
            // Check if the importance is invalid
            else if (!isValidImportance)
            {
                // Show the importance error label
                lblImportanceError.Visible = true;
            }
        }

        /// <summary>
        /// Clear the input fields used to add a verse
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void ClearInputFields()
        {
            // Clear the book combo box
            cmbVerseBook.SelectedIndex = -1;
            // Clear the textboxes in grpAddVerse
            foreach (TextBox textBox in grpAddVerse.Controls.OfType<TextBox>())
            {
                // Clear the textbox
                textBox.Clear();
            }
            // Reset the numeric up-down control
            nudVerseImportance.Value = 1;
        }

        /// <summary>
        /// Load event handler for FrmVerseList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmVerseListLoadEH(object sender, EventArgs e)
        {
            // Set the data source for the data grid view
            dgvVerseDisplay.DataSource = _versesBindingSource;
        }

        /// <summary>
        /// Refresh the verse data grid view
        /// </summary>
        public void RefreshVerseDgv()
        {
            // Get the verses from the business logic layer
            List<VerseDisplayModel> verses = _verseLogic.GetAllVerses();
            // Set the data source for the binding source object
            _versesBindingSource.DataSource = verses;

            // Format the data grid view
            FormatVersesDgv();
        }

        /// <summary>
        /// Format the verses data grid view
        /// </summary>
        private void FormatVersesDgv()
        {
            // Calculate the width for the text and meaning columns
            int width = (dgvVerseDisplay.Width - dgvVerseDisplay.Columns[0].Width - dgvVerseDisplay.Columns[3].Width) / 2;
            // Set the width for the text column
            dgvVerseDisplay.Columns[1].Width = width;
            // Set the width for the meaning column
            dgvVerseDisplay.Columns[2].Width = width;
            // Set the default cell style so text will wrap
            dgvVerseDisplay.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // Call the auto resize row method so the rows will expand
            dgvVerseDisplay.AutoResizeRows();
        }
    }
}
