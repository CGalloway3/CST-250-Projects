/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/30/2025
 * File IO and LINQ
 * Activity 6
 * References:
 */

using FileIOAndLINQ.Models;
using FileIOAndLINQ.Services.DataAccessLayer;

namespace FileIOAndLINQ.Services.BusinessLogicLayer
{
    class VerseLogic
    {
        // Class level variables
        private VerseDAO _verseDAO;

        /// <summary>
        /// Default constructor for VerseLogic
        /// </summary>
        public VerseLogic()
        {
            // Initialize the data access object
            _verseDAO = new VerseDAO();
        }

         public int AddVerse(VerseRequestModel verse)
        {
            // return the DAO method
            return _verseDAO.AddVerse(verse);
        }
    }
}
