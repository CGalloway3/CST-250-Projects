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
}
