/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/30/2025
 * File IO and LINQ
 * Activity 6
 * References:
 */

namespace FileIOAndLINQ.Models
{
    class VerseRequestModel
    {
        // Class level properties
        public string Book { get; set; }
        public int Chapter { get; set; }
        public string Verse { get; set; }
        public string Text { get; set; }
        public string Meaning { get; set; }
        public int Importance { get; set; }

        /// <summary>
        /// Default constructor for the Verse Request Model
        /// </summary>
        public VerseRequestModel()
        {
            // Set the properties to empty strings
            Book = string.Empty;
            Chapter = 0;
            Verse = string.Empty;
            Text = string.Empty;
            Meaning = string.Empty;
            Importance = 0;
        }

        /// <summary>
        /// Parameterized constructor for the Verse Request Model
        /// </summary>
        /// <param name="book"></param>
        /// <param name="chapter"></param>
        /// <param name="verse"></param>
        /// <param name="text"></param>
        /// <param name="meaning"></param>
        /// <param name="importance"></param>
        public VerseRequestModel(string book, int chapter, string verse, string text, string meaning, int importance)
        {
            // Set the properties equal to the corresponding parameters
            Book = book;
            Chapter = chapter;
            Verse = verse;
            Text = text;
            Meaning = meaning;
            Importance = importance;
        }
    }
}
