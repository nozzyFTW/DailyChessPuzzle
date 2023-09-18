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
                        Board.board_panels[pos].BackgroundImage.Tag = "P";
                    }
                    if (item == "R") // White Rook
                    {
                        Main.board[pos] = "R";
                        Board.board_panels[pos].BackgroundImage = Resources.wr;
                        Board.board_panels[pos].BackgroundImage.Tag = "R";
                    }
                    if (item == "N") // White Knight
                    {
                        Main.board[pos] = "N";
                        Board.board_panels[pos].BackgroundImage = Resources.wn;
                        Board.board_panels[pos].BackgroundImage.Tag = "N";
                    }
                    if (item == "B") // White Bishop
                    {
                        Main.board[pos] = "B";
                        Board.board_panels[pos].BackgroundImage = Resources.wb;
                        Board.board_panels[pos].BackgroundImage.Tag = "B";
                    }
                    if (item == "Q") // White Queen
                    {
                        Main.board[pos] = "Q";
                        Board.board_panels[pos].BackgroundImage = Resources.wq;
                        Board.board_panels[pos].BackgroundImage.Tag = "Q";
                    }
                    if (item == "K") // White King
                    {
                        Main.board[pos] = "K";
                        Board.board_panels[pos].BackgroundImage = Resources.wk;
                        Board.board_panels[pos].BackgroundImage.Tag = "K";
                    }
                    pos++;
                }

                if (isBlack)
                {
                    if (item == "p") // Black Pawn
                    {
                        Main.board[pos] = "p";
                        Board.board_panels[pos].BackgroundImage = Resources.bp;
                        Board.board_panels[pos].BackgroundImage.Tag = "p";
                    }
                    if (item == "r") // Black Rook
                    {
                        Main.board[pos] = "r";
                        Board.board_panels[pos].BackgroundImage = Resources.br;
                        Board.board_panels[pos].BackgroundImage.Tag = "r";
                    }
                    if (item == "n") // Black Knight
                    {
                        Main.board[pos] = "n";
                        Board.board_panels[pos].BackgroundImage = Resources.bn;
                        Board.board_panels[pos].BackgroundImage.Tag = "n";
                    }
                    if (item == "b") // Black Bishop
                    {
                        Main.board[pos] = "b";
                        Board.board_panels[pos].BackgroundImage = Resources.bb;
                        Board.board_panels[pos].BackgroundImage.Tag = "b";
                    }
                    if (item == "q") // Black Queen
                    {
                        Main.board[pos] = "q";
                        Board.board_panels[pos].BackgroundImage = Resources.bq;
                        Board.board_panels[pos].BackgroundImage.Tag = "q";
                    }
                    if (item == "k") // Black King
                    {
                        Main.board[pos] = "k";
                        Board.board_panels[pos].BackgroundImage = Resources.bk;
                        Board.board_panels[pos].BackgroundImage.Tag = "k";
                    }
                    pos++;
                }
            }
        }

        public static void Move(string square, int currentPos)
        {
            int newPos;
            bool isPawnFirstMove = false;
            if (piece == "P")
            {
                if (Board.startingPos[currentPos] == piece)
                {
                    isPawnFirstMove = true;
                }

                // If first move for pawn, is pawn blocked from moving forward 2? No, allow piece to move forward 2 squares. Yes, Can piece be moved 1 square?
                if (Main.board[currentPos - 8] == " ")
                {
                    newPos = currentPos - 8;
                    Board.board_panels[newPos].BackgroundImage = Resources.legal;
                    if (isPawnFirstMove && Main.board[currentPos - 16] == " ")
                    {
                        newPos = currentPos - 16;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                    }
                    
                }
                if (isPawnFirstMove)
                {
                    if (Main.board[currentPos - 8] == " " && Main.board[currentPos - 16] == " ")
                    {

                    }
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
