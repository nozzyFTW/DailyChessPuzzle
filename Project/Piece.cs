using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace DailyChessPuzzle
{
    internal class Piece
    {
        string piece;
        Panel[] board_panels;
        public Piece(string fPiece, string[] board, Panel[] fBoard)
        {
            piece = fPiece;
            board_panels = fBoard;
        }

        public void PawnMovement()
        {
            bool isFirstMove;

        }
    }
}
