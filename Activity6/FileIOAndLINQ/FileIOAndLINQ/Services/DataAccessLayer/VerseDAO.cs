/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/30/2025
 * File IO and LINQ
 * Activity 6
 * References:
 */

using FileIOAndLINQ.Models;

namespace FileIOAndLINQ.Services.DataAccessLayer
{

    class VerseDAO
    {
        // Declare class level variables
        List<VerseDataModel> _verses;

        /// <summary>
        /// Default constructor for VerseDAO
        /// </summary>
        public VerseDAO()
        {
            // Create a new list of VerseDataModel
            _verses = new List<VerseDataModel>();
        }
        
        /// <summary>
        /// Add a new verse to the inventory
        /// </summary>
        /// <param name="verse"></param>
        /// <returns></returns>
        public int AddVerse(VerseRequestModel verse)
        {
            // Declare and initialize
            int id = _verses.Count + 1;
            VerseDataModel newVerse = new VerseDataModel();

            // Create a new verse based on the verse request model
            newVerse = new VerseDataModel(id, verse.Book, verse.Chapter,
                verse.Verse, verse.Text, verse.Meaning, verse.Importance);
            // Add the new verse to the verses list
            _verses.Add(newVerse);

            // Return the id of the new verse
            return id;
        }

        public List<VerseDataModel> GetAllVerses()
        {
            // Return the _verses List
            return _verses;
        }
    }
}
