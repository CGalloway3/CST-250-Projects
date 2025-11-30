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
    class VerseXlsxModel
    {
        // Class level properties
        public double Id { get; set; }
        public string Book { get; set; }
        public double Chapter { get; set; }
        public string Verse { get; set; }
        public string Text { get; set; }
        public string Meaning { get; set; }
        public double Importance { get; set; }

        /// <summary>
        /// Default constructor for the Verse Data Model
        /// </summary>
        public VerseXlsxModel()
        {
            // Set the properties to default values
            Id = 0;
            Book = "";
            Chapter = 0;
            Verse = "";
            Text = "";
            Meaning = "";
            Importance = 0;
        }

        /// <summary>
        /// Parameterized constructor for the Verse Request Model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <param name="chapter"></param>
        /// <param name="verse"></param>
        /// <param name="text"></param>
        /// <param name="meaning"></param>
        /// <param name="importance"></param>
        public VerseXlsxModel(double id, string book, double chapter, string verse, string text, string meaning, double importance)
        {
            // Set the properties equal to the corresponding parameters
            Id = id;
            Book = book;
            Chapter = chapter;
            Verse = verse;
            Text = text;
            Meaning = meaning;
            Importance = importance;
        }

        /// <summary>
        /// Quick and dirty conversion method to change the xlsx model to a data model
        /// </summary>
        /// <returns></returns>
        public VerseDataModel ToDataModel()
        {
            // Create a new Verse Data Model from the xlsx model properties.
            VerseDataModel verseData = new VerseDataModel((int)Id, Book, (int)Chapter, Verse, Text, Meaning, (int)Importance);
            // Return the now properly formatted Verse Data
            return verseData;
        }
    }
}
