/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/02/2020
 * Chess Board Project
 * Activity 2
 * References:
 */

namespace ChessBoardClassLibrary.Enums
{
    /// <summary>
    /// Signifies a piece color for easy comparison and
    /// Numeric values are signed to simplify pawn movement along the row axis:
    /// - White = -1 → moves up (decreasing row)
    /// - Black = 1 → moves down (increasing row)
    /// - None = 0 → signifies empty or neutral squares
    /// <summary>
    public enum PieceColor
    {
        White = -1,
        None = 0,
        Black = 1
    }

    /// <summary>
    /// Static class to handle safe conversion of strings to the PieceColor enum.
    /// </summary>
    public static class PieceColorConverter
    {
        /// <summary>
        /// Converts a string representation of a color (e.g., "White" or "black") 
        /// into the corresponding PieceColor enum value.
        /// </summary>
        /// <param name="colorString">The string to convert (case-insensitive).</param>
        /// <returns>The matching PieceColor, or PieceColor.None if the conversion fails.</returns>
        public static PieceColor ConvertStringToPieceColor(string colorString)
        {
            // Use Enum.TryParse for safe conversion.
            // true ignores case (so "white", "White", and "WHITE" all work).
            if (Enum.TryParse(colorString, true, out PieceColor result))
            {
                // Conversion succeeded, return the result.
                return result;
            }

            // Conversion failed (e.g., the string was "blue").
            // Return PieceColor.None as a safe default/error state.
            return PieceColor.None;
        }
    }
}
