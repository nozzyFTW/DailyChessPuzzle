using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Panel = System.Windows.Forms.Panel;

namespace DailyChessPuzzle
{
    internal class Board
    {
        public static List<Panel> panels = new List<Panel>();
        public Board()
        {
            // Creates a 2D array of squares on the board 
            BoardArray = new Square[8, 8];
            board_panels = new Panel[64];

            // Fills 2D array with 64 squares
            for (int rank = 0; rank < 8; rank++)
            {
                for (int file = 0; file < 8; file++)
                {
                    BoardArray[rank, file] = new Square(rank, file);
                }
            }

            // Initiate Board Panels
            foreach (string square in Main.square_codes)
            {
                
            }
        }

        public static Square[,] BoardArray { get; set; }
        public static Panel[] board_panels { get; set; }

        public void NextLegalMoves(Square currentSquare, string currentPiece)
        {
            // Clear Previous Legal Moves 
            for (int rank = 0; rank < 8; rank++)
            {
                for (int file = 0; file < 8; file++)
                {

                }
            }

            // Find All Current Legal Moves

        }
    }
}
