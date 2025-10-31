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
    /// Represents the types of chess pieces.
    /// PieceType.None (-1) represents an empty square.
    /// PieceType.EnPassant (0) is a temporary “ghost” piece, 
    /// used exclusively to indicate en passant availability to pawns; 
    /// other pieces treat it as empty.
    /// </summary>
    public enum PieceType
    {
        None = -1,
        EnPassant = 0,
        Pawn = 1,
        Knight = 2,
        Bishop = 3,
        Rook = 4,
        Queen = 5,
        King = 6
    }

    /// <summary>
    /// Static class to handle safe conversion of strings to the PieceType enum.
    /// </summary>
    public static class PieceTypeConverter
    {
        /// <summary>
        /// Converts a string representation of a piece type (e.g., "Pawn" or "knight") 
        /// into the corresponding PieceType enum value.
        /// </summary>
        /// <param name="pieceString">The string to convert (case-insensitive).</param>
        /// <returns>The matching PieceType, or PieceType.None if the conversion fails.</returns>
        public static PieceType ConvertStringToPieceType(string pieceString)
        {
            // Use Enum.TryParse for safe conversion.
            // true ignores case (so "pawn", "Pawn", and "PAWN" all work).
            if (Enum.TryParse(pieceString, true, out PieceType result))
            {
                // Conversion succeeded, return the result.
                return result;
            }

            // Conversion failed (e.g., the string was "dragon").
            // Return PieceType.None as a safe default/error state.
            return PieceType.None;
        }
    }
}
