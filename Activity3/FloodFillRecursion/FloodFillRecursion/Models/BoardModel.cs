/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/09/2020
 * Flood Fill Recursion
 * Activity 3 Part 4
 * References:
 */

namespace FloodFillRecursion.Models
{
    internal class BoardModel
    {
        // Board Model Properties
        public int Size { get; set; }
        public CellModel[,] Grid {get; set;}
        public int NumShapes { get; set; }

        /// <summary>
        /// Parameterized constructor for BoardModel
        /// </summary>
        /// <param name="size"></param>
        /// <param name="numShapes"></param>
        public BoardModel(int size, int numShapes)
        {
            // Declare and Initialize
            Size = size;
            NumShapes = numShapes;
            Grid = new CellModel[Size, Size];

            //Set up the Grid
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Grid[row, col] = new CellModel(row, col, "E");
                }
            }

            // Place random shapes on the board
            PlaceShapes();
        }

        /// <summary>
        /// Create shape to place on the board
        /// </summary>
        public void PlaceShapes()
        {
            // Declare and Initialize
            // Random object to generate numbers
            Random random = new Random();
            int shapeSize = Size / 3, row = 0, col = 0;

            // Create three shapes
            for (int shapes = 0; shapes < NumShapes; shapes++)
            {
                // Generate the row and col for the
                // top left corner of the square
                row = random.Next(0, Size - shapeSize + 1);
                col = random.Next(0, Size - shapeSize + 1);
                for (int offset = 0; offset < shapeSize; offset++)
                {
                    // Top Wall
                    Grid[row + offset, col + offset].Contents = "W";
                    // Left Wall
                    Grid[row + offset, col].Contents = "W";
                    // Bottom Wall
                    try
                    {
                        Grid[row + shapeSize - 1 + offset, col + offset].Contents = "W";
                    }
                    catch (IndexOutOfRangeException e)  
                    {
                        // catch out of bounds and continue to next iteration
                        continue;
                    }
                    // Right Wall
                    Grid[row + offset + shapeSize - 1, col + shapeSize - 1].Contents = "W";
                }
            }
        } // End of PlaceShapes method
    }
}
