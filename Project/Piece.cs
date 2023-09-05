using DailyChessPuzzle.Properties;
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

        public void Generate(List<string> section, int rankNum)
        {
            int pos = 0;

            // Effective - Replaces 8 ifs
            int[] posArr = new int[9] { 0, 56, 48, 40, 32, 24, 16, 8, 0 };
            pos = posArr[rankNum];

            foreach (string item in section)
            {
                bool isWhite = Char.IsUpper(item, 0);
                bool isBlack = (!Char.IsUpper(item, 0) && !Char.IsNumber(item, 0));
                bool isBlankSquare = Char.IsNumber(item, 0);

                if (isBlankSquare)
                {
                    for (int i = 0; i < Convert.ToInt32(item); i++)
                    {
                        board[pos] = " ";
                        pos++;
                    }
                }

                if (isWhite)
                {
                    if (item == "P") // White Pawn
                    {
                        board[pos] = "P";
                        board_panels[pos].BackgroundImage = Resources.wp;
                    }
                    if (item == "R") // White Rook
                    {
                        board[pos] = "R";
                        board_panels[pos].BackgroundImage = Resources.wr;
                    }
                    if (item == "N") // White Knight
                    {
                        board[pos] = "N";
                        board_panels[pos].BackgroundImage = Resources.wn;
                    }
                    if (item == "B") // White Bishop
                    {
                        board[pos] = "B";
                        board_panels[pos].BackgroundImage = Resources.wb;
                    }
                    if (item == "Q") // White Queen
                    {
                        board[pos] = "Q";
                        board_panels[pos].BackgroundImage = Resources.wq;
                    }
                    if (item == "K") // White King
                    {
                        board[pos] = "K";
                        board_panels[pos].BackgroundImage = Resources.wk;
                    }
                }

                if (isBlack)
                {

                }
            }
        }
    }
}
