/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/02/2020
 * Chess Board Project
 * Activity 2
 * References:
 */

using ChessBoardClassLibrary.Enums;

namespace ChessBoardClassLibrary.Models
{
    public class ChessPiece
    {
        public PieceType Type { get; private set; }
        public PieceColor Color { get; private set; }

        public ChessPiece(PieceType type = PieceType.None, PieceColor color = PieceColor.None) 
        {
            Type = type;
            Color = color;
        }
    }
}
