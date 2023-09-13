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
        public static string piece;
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
                        Board.board_panels[pos].BackgroundImage = Resources.wp;
                    }
                    if (item == "R") // White Rook
                    {
                        Main.board[pos] = "R";
                        Board.board_panels[pos].BackgroundImage = Resources.wr;
                    }
                    if (item == "N") // White Knight
                    {
                        Main.board[pos] = "N";
                        Board.board_panels[pos].BackgroundImage = Resources.wn;
                    }
                    if (item == "B") // White Bishop
                    {
                        Main.board[pos] = "B";
                        Board.board_panels[pos].BackgroundImage = Resources.wb;
                    }
                    if (item == "Q") // White Queen
                    {
                        Main.board[pos] = "Q";
                        Board.board_panels[pos].BackgroundImage = Resources.wq;
                    }
                    if (item == "K") // White King
                    {
                        Main.board[pos] = "K";
                        Board.board_panels[pos].BackgroundImage = Resources.wk;
                    }
                    pos++;
                }

                if (isBlack)
                {
                    if (item == "p") // Black Pawn
                    {
                        Main.board[pos] = "p";
                        Board.board_panels[pos].BackgroundImage = Resources.bp;
                    }
                    if (item == "r") // Black Rook
                    {
                        Main.board[pos] = "r";
                        Board.board_panels[pos].BackgroundImage = Resources.br;
                    }
                    if (item == "n") // Black Knight
                    {
                        Main.board[pos] = "n";
                        Board.board_panels[pos].BackgroundImage = Resources.bn;
                    }
                    if (item == "b") // Black Bishop
                    {
                        Main.board[pos] = "b";
                        Board.board_panels[pos].BackgroundImage = Resources.bb;
                    }
                    if (item == "q") // Black Queen
                    {
                        Main.board[pos] = "q";
                        Board.board_panels[pos].BackgroundImage = Resources.bq;
                    }
                    if (item == "k") // Black King
                    {
                        Main.board[pos] = "k";
                        Board.board_panels[pos].BackgroundImage = Resources.bk;
                    }
                    pos++;
                }
            }
        }

        public static void Move(string square, int currentPos)
        {
            bool isPawnFirstMove = false;
            if (piece == "P")
            {
                if (Board.startingPos[currentPos] == piece)
                {
                    isPawnFirstMove = true;
                }

                // If first move for pawn, is pawn blocked from moving forward 2? No, allow piece to move forward 2 squares. Yes, Can piece be moved 1 square?
                if (isPawnFirstMove)
                {
                    
                }
            }

            if (piece == "p")
            {

            }

            if (piece == "R" || piece == "r")
            {
                // N

                // E

                // S

                // W
            }

            if (piece == "N" || piece == "n")
            {
                // NNE

                // NNW

                // EEN

                // EES

                // SSE

                // SSW

                // WWN

                // WWS
        }
        }
    }
}
