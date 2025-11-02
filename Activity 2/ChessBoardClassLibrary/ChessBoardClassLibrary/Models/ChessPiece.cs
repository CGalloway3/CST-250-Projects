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
        // Class level properties with public getters and private setters.
        // This is an example of encapsulation: external code can read the values.
        // but only this class can modify them.
        public PieceType Type { get; private set; }
        public PieceColor Color { get; private set; }

        /// <summary>
        /// Parameterized constructor for the ChessPiece class with defaults for none set
        /// </summary>
        /// <param name="type"></param>
        /// <param name="color"></param>
        public ChessPiece(PieceType type = PieceType.None, PieceColor color = PieceColor.None) 
        {
            // Set values
            Type = type;
            Color = color;                        
        }
    }
}
