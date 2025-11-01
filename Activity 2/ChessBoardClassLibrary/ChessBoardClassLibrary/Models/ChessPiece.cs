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
        public string SignifyingLetter { get; private set; }

        public ChessPiece(PieceType type = PieceType.None, PieceColor color = PieceColor.None) 
        {
            // Set values
            Type = type;
            Color = color;
            
            // Switch on type to write signifying letter
            switch(Type)
            {
                case PieceType.None:
                    SignifyingLetter = string.Empty;
                    break;

                case PieceType.EnPassant:
                    SignifyingLetter = "E";
                    break;

                case PieceType.Pawn:
                    SignifyingLetter = "P";
                    break;

                case PieceType.Knight:
                    SignifyingLetter = "N";
                    break;

                case PieceType.Bishop:
                    SignifyingLetter = "B";
                    break;

                case PieceType.Rook:
                    SignifyingLetter = "R";
                    break;

                case PieceType.Queen:
                    SignifyingLetter = "Q";
                    break;

                case PieceType.King:
                    SignifyingLetter = "K";
                    break;

                default:
                    break;

            }
        }
    }
}
