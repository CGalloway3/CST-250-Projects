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

        /// <summary>
        /// Writes the verse list to the given file
        /// formatted based on file type
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Read verses from the given file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReadVersesFromFile(string fileName)
        {
            // Declare and initialize
            string data = "";
            List<VerseDataModel> dataVerses = new List<VerseDataModel>();

            // Set up a try-catch to read files text
            try
            {
                // Get the text from the file
                data = File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                // Return the exception message
                return ex.Message;
            }
            // Create a switch based on the file extension
            switch (Path.GetExtension(fileName))
            {
                case ".txt":
                    // Split the text file on the newline character
                    string[] lines = data.Split('\n');
                    // Loop through the array of lines
                    foreach (string line in lines)
                    {
                        // Check if each line contains data
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            // If so, convert the data to a VerseDataModel
                            // and add it to the dataVerses list
                            dataVerses.Add(ConvertTxtToVerseDataModel(line));
                        }
                    }
                    break;

                case ".json":
                    // Deserialize the data using the JsonSerializer
                    dataVerses = ServiceStack.Text.JsonSerializer.DeserializeFromString<List<VerseDataModel>>(data);
                    break;

                case ".csv":
                    // Deserialize the data using the CsvSerializer
                    dataVerses = ServiceStack.Text.CsvSerializer.DeserializeFromString<List<VerseDataModel>>(data);
                    break;

                default:
                    // Return the issue to the user
                    return "File not recognized";
            }
            // Loop through the dataVerses list
            foreach (VerseDataModel newVerse in dataVerses)
            {
                // Set the id for each new verse
                newVerse.Id = _verses.Count + 1;
                // Add the new verse to the _verses list
                _verses.Add(newVerse);
            }
            // Return a success message to the user
            return "The verses have been read from your file and added to the list";
        } // End of ReadVersesFromFile

        /// <summary>
        /// Take a line from the text file and return a VerseDataModel
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public VerseDataModel ConvertTxtToVerseDataModel(string line)
        {
            // Declare and initialize
            string[] values;
            int chapter = 0, importance = 0;
            VerseDataModel verse;

            // Split the line on '*'
            values = line.Split('*');

            // Use a try parse to parse the chapter
            int.TryParse(values[1], out chapter);

            // Parse the importance
            int.TryParse(values[5], out importance);

            // Create the new verse
            verse = new VerseDataModel(0, values[0], chapter, values[2], values[3], values[4], importance);

            // Return the verse
            return verse;
        }

        /// <summary>
        /// Get a list of the least important verses
        /// </summary>
        /// <param name="numToFind"></param>
        /// <returns></returns>
        public List<VerseDataModel> GetLeastImportantVerses(int numToFind)
        {
            // Use LINQ query syntax to order the verses and select how
            // many are needed based on the numToFind parameter
            List<VerseDataModel> leastImportantVerses = (from verse in _verses
                                                         orderby verse.Importance
                                                         select verse).Take(numToFind).ToList();

            // Return the list of least important verses
            return leastImportantVerses;
        }
    }
}
