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

        /// <summary>
        /// Get the list of verses in the inventory.
        /// </summary>
        /// <returns></returns>
        public List<VerseDataModel> GetAllVerses()
        {
            // Return the _verses List
            return _verses;
        }

        public string WriteVersesToFile(string fileName)
        {
            // Declare and Initialize
            string serialized = "";

            // Create a switch based on file extensions to fill the serialized string
            switch (Path.GetExtension(fileName))
            {
                case ".txt":
                    // Loop through the _verses list
                    foreach (var verse in _verses)
                    {
                        // Add each verse to the end of the serialized string
                        serialized += verse.ToString() + "\n";
                    }
                    break;
                case ".json":
                    // Use ServiceStack to serialize to json
                    serialized = ServiceStack.Text.JsonSerializer.SerializeToString(_verses);
                    break;
                case ".csv":
                    // Use ServiceStack to serialize to csv
                    serialized = ServiceStack.Text.CsvSerializer.SerializeToString(_verses);
                    break;
                default:
                    return "File not recognized";
            }
            // Try to save the serialized string to file.
            try
            {
                // Use File.WriteAllText to send the serialized string to the file
                File.WriteAllText(fileName, serialized);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            // Return success message to the user
            return "The verses have been saved to your file.";
        }
    }
}
