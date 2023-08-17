using DailyChessPuzzle.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DailyChessPuzzle
{
    internal class Piece
    {
        string piece;
        int row, col;
        public Piece (string fPiece, int fRow, int fCol)
        {
            piece = fPiece;
            row = fRow;
            col = fCol;
            setPieceImage();
        }

        public int Row { get; set; }
        public int Col { get; set; }
        private void setPieceImage()
        {
            Image pieceImage = (Image)Resources.ResourceManager.GetObject(fPiece);
        }
        public bool isLegalMove()
        {
            
        }
    }
}
