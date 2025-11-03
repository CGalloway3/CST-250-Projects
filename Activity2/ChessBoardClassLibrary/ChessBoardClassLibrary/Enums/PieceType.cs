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
    /// Extension of the enum PieceType to allow functionality of the dictionary use with out using a dictionary.
    /// </summary>
    public static class PieceTypeExtensions
    {
        public static char ToChar(this PieceType piece) 
        {
            char typeChar = piece switch
            {
                PieceType.None => '.',
                PieceType.EnPassant => 'e',
                PieceType.Pawn => 'P',
                PieceType.Knight => 'N',
                PieceType.Bishop => 'B',
                PieceType.Rook => 'R',
                PieceType.Queen => 'Q',
                PieceType.King => 'K',
                _ => '?'
            };
            return typeChar;
        }
    }
}


