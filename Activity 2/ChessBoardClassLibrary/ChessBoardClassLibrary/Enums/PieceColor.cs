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
}
