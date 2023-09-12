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
        public Piece(string fPiece)
        {
            piece = fPiece;
        }

        // Clear All Previous Legal Moves
        // Find All Legal Moves

        public static void Generate(List<string> section, int rankNum)
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
                        Main.board[pos] = " ";
                        pos++;
                    }
                }

                if (isWhite)
                {
                    if (item == "P") // White Pawn
                    {
                        Main.board[pos] = "P";
                        Board.panels[pos].BackgroundImage = Resources.wp;
                    }
                    if (item == "R") // White Rook
                    {
                        Main.board[pos] = "R";
                        Board.panels[pos].BackgroundImage = Resources.wr;
                    }
                    if (item == "N") // White Knight
                    {
                        Main.board[pos] = "N";
                        Board.panels[pos].BackgroundImage = Resources.wn;
                    }
                    if (item == "B") // White Bishop
                    {
                        Main.board[pos] = "B";
                        Board.panels[pos].BackgroundImage = Resources.wb;
                    }
                    if (item == "Q") // White Queen
                    {
                        Main.board[pos] = "Q";
                        Board.panels[pos].BackgroundImage = Resources.wq;
                    }
                    if (item == "K") // White King
                    {
                        Main.board[pos] = "K";
                        Board.panels[pos].BackgroundImage = Resources.wk;
                    }
                }

                if (isBlack)
                {

                }
            }
        }
    }
}
