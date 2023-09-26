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

        public static string[] startingPos = new string[64]
        {
            "r", "n", "b", "q", "k", "b", "n", "r",
            "p", "p", "p", "p", "p", "p", "p", "p",
            " ", " ", " ", " ", " ", " ", " ", " ",
            " ", " ", " ", " ", " ", " ", " ", " ",
            " ", " ", " ", " ", " ", " ", " ", " ",
            " ", " ", " ", " ", " ", " ", " ", " ",
            "P", "P", "P", "P", "P", "P", "P", "P",
            "R", "N", "B", "Q", "K", "B", "N", "R"
        };

        public static string[] _startingPos = new string[128]
        {
            "r", "n", "b", "q", "k", "b", "n", "r", "x", "x", "x", "x", "x", "x", "x", "x",
            "p", "p", "p", "p", "p", "p", "p", "p", "x", "x", "x", "x", "x", "x", "x", "x",
            " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
            " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
            " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
            " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
            "P", "P", "P", "P", "P", "P", "P", "P", "x", "x", "x", "x", "x", "x", "x", "x",
            "R", "N", "B", "Q", "K", "B", "N", "R", "x", "x", "x", "x", "x", "x", "x", "x"
        };

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
