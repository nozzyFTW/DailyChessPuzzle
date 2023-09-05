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
        string[] board;
        Panel[] board_panels;
        public Piece(string fPiece, string[] fBoard, Panel[] fBoardPanels)
        {
            piece = fPiece;
            board = fBoard;
            board_panels = fBoardPanels;
        }

        // Clear All Previous Legal Moves
        // Find All Legal Moves

        public void PawnMovement()
        {
            bool isFirstMove;

            
        }
    }
}
