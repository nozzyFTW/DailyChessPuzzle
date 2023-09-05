using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyChessPuzzle
{
    internal class Board
    {
         
        public Board(int fSize)
        {
            // Creates a 2D array of squares on the board 
            BoardArray = new Square[8, 8];

            // Fills 2D array with 64 squares
            for (int rank = 0; rank < 8; rank++)
            {
                for (int file = 0; file < 8; file++)
                {
                    BoardArray[rank, file] = new Square(rank, file);
                }
            }
        }

        public Square[,] BoardArray { get; set; }

        public void NextLegalMoves (Square currentSquare, string currentPiece)
        {
            // Clear Previous Legal Moves 
            for (int rank = 0; rank < 8; rank++)
            {

            }

            // Find All Current Legal Moves

        }
    }
}
