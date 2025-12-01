/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/30/2025
 * File IO and LINQ
 * Activity 6
 * References:
 */

using FileIOAndLINQ.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System.Security.Cryptography.Xml;

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

                case ".xml":
                    // Use ServiceStack to serialize to xml
                    serialized = ServiceStack.Text.XmlSerializer.SerializeToString(_verses);
                    break;

                case ".xlsx":
                    // Open the EPPlus Excel Package for use with the user selected fileName
                    using (var package = new ExcelPackage(fileName))
                    {
                        // Initialize the variable sheet with the Bible Verses sheet if it exists.
                        var sheet = package.Workbook.Worksheets["Bible Verses"];

                        // If the Bible Verses sheet does exist we need to remove it.
                        if (sheet != null)
                        {
                            package.Workbook.Worksheets.Delete(sheet);
                        }
                        
                        // Set the sheet as a new sheet
                        sheet = package.Workbook.Worksheets.Add("Bible Verses");
                        
                        // Fill the sheet with our data into a table starting at A1
                        sheet.Cells["A1"].LoadFromCollection(_verses, true, TableStyles.Medium4);

                        // Format the newly added table
                        sheet.Columns[1].Width = 4;
                        sheet.Columns[1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        sheet.Columns[2].Width = 20;
                        sheet.Columns[2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        sheet.Columns[3].Width = 10;
                        sheet.Columns[3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        sheet.Columns[4].Width = 8;
                        sheet.Columns[4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        sheet.Columns[5].Width = 50;
                        sheet.Columns[5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Justify;
                        sheet.Columns[6].Width = 50;
                        sheet.Columns[6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Justify;
                        sheet.Columns[7].Width = 12.5;
                        sheet.Columns[7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        sheet.Rows.Height = 48;

                        // Save to file
                        package.Save();
                    }
                    return "The Excel file was successfully created";

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

                case ".xml":
                    // Deserialize the data using XmlSerializer
                    dataVerses = ServiceStack.Text.XmlSerializer.DeserializeFromString<List<VerseDataModel>>(data);
                    break;

                case ".xlsx":
                    // Open the EPPlus Excel Package for use with the user selected fileName
                    using (var package = new ExcelPackage(fileName))
                    {
                        // Check if the worksheet exists
                        var worksheet = package.Workbook.Worksheets["Bible Verses"];
                        if (worksheet == null)
                        {
                            return "Worksheet 'Bible Verses' not found";
                        }

                        // Check if there's any data
                        if (worksheet.Dimension == null || worksheet.Dimension.Rows < 2)
                        {
                            return "No data found in worksheet";
                        }

                        // Create a xlsx data model list to hold our incoming table.
                        // Incoming data from Excel hold numbers in doubles. Creating this new model allows me to
                        // easily convert the data coming in into the data we need.
                        List<VerseXlsxModel> xlsxVerses = new List<VerseXlsxModel>();
                        // Fill the model list with the data in the xlsx file.
                        xlsxVerses = worksheet.Tables[0].ToCollection<VerseXlsxModel>();

                        // Convert each list item from xlsx data to verse data and the add it to the dataVerses list.
                        foreach (VerseXlsxModel verse in xlsxVerses)
                        {
                            dataVerses.Add(verse.ToDataModel());
                        }
                    }

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
        
        /// <summary>
        /// Get a list of the most important verses
        /// </summary>
        /// <param name="numToFind"></param>
        /// <returns></returns>
        public List<VerseDataModel> GetMostImportantVerses(int numToFind)
        {
            // Use LINQ method syntax to order the verses and select how
            //   many are needed based on the numToFind parameter
            List<VerseDataModel> mostImportantVerses = _verses.OrderByDescending(verse => verse.Importance).Take(numToFind).ToList();
            // Return the list of least important verses
            return mostImportantVerses;
        }

        /// <summary>
        /// Public DAO method to count the number of verses in the list of verses entries.  
        /// </summary>
        /// <returns></returns>
        public int GetTotalNumberOfVerses()
        {
            // Declare and Initialize
            int totalCount = 0;

            // count each verse entry
            foreach (var verse in _verses)
            {
                // Add up the total verses
                totalCount += CountVersesInReference(verse.Verse);
            }
            // Return the final count
            return totalCount;
        }

        /// <summary>
        /// Private method to count the number of verses in a single verse entry to handle spans (i.e. 2-6)
        /// </summary>
        /// <param name="verse"></param>
        /// <returns></returns>
        private int CountVersesInReference(string verse)
        {
            // Catch null or empty strings
            if (string.IsNullOrWhiteSpace(verse))
                return 0;

            try
            {
                // Check for range (handle both hyphen and en dash)
                // With Regex validating our input this is a bit of overkill
                // but better safe than sorry later.
                if (verse.Contains('-') || verse.Contains('–'))
                {
                    // Replace en dash with regular hyphen for consistency going forward
                    verse = verse.Replace('–', '-');

                    // Split the start and end values to a range array
                    var verseRange = verse.Split('-');
                    // If the array has exactly 2 elements (start and end)
                    if (verseRange.Length == 2)
                    {
                        // Parse the start and end values
                        if (int.TryParse(verseRange[0].Trim(), out int startVerse) &&
                            int.TryParse(verseRange[1].Trim(), out int endVerse))
                        {
                            // Calculate the span (inclusive)
                            return (endVerse - startVerse) + 1;
                        }
                    }
                }

                // Single verse with no hyphen
                return 1;
            }
            catch (Exception ex) 
            {
                // If parsing fails, count as 1
                return 1;
            }

        }

        internal List<VerseDataModel> SearchVerses(string searchText)
        {
            List<VerseDataModel> filteredVerses;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // Return all verses if search is empty
                filteredVerses = _verses;
            }
            else
            {
                var searchLower = searchText.ToLower();

                filteredVerses = _verses.Where(v =>
                    (v.Text?.ToLower().Contains(searchLower) ?? false) ||
                    (v.Meaning?.ToLower().Contains(searchLower) ?? false)
                ).ToList();
            }

            // Return the search filtered verses
            return filteredVerses;
        }
    }
}
