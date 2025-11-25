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
    class VerseDisplayModel
    {
        // Class level properties
        public string Reference { get; set; }
        public string Text { get; set; }
        public string Meaning { get; set; }
        public int Importance { get; set; }

        /// <summary>
        /// Default constructor for the Verse Display Model
        /// </summary>
        public VerseDisplayModel()
        {
            // Set the properties to default values
            Reference = "";
            Text = "";
            Meaning = "";
            Importance = 0;
        }

        /// <summary>
        /// Parameterized constructor for the Verse Display Model
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="text"></param>
        /// <param name="meaning"></param>
        /// <param name="importance"></param>
        public VerseDisplayModel(string reference, string text, string meaning, int importance)
        {
            // Set the properties equal to the corresponding parameters
            Reference = reference;
            Text = text;
            Meaning = meaning;
            Importance = importance;
        }
    }
}
