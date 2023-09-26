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
        public static bool isLegalMove;

        public Piece(string fPiece)
        {
            if (fPiece != null)
            {
                piece = fPiece;
            }
        }

        // Clear All Previous Legal Moves
        // Find All Legal Moves

        public static void Generate(List<string> section, int rankNum)
        {
            int pos = 0;
            int offsetPos = 0;

            // Effective - Replaces 8 ifs
            int[] posArr = new int[9] { 0, 56, 48, 40, 32, 24, 16, 8, 0 };
            int[] offsetPosArr = new int[9] { 0, 112, 96, 80, 64, 48, 32, 16, 0 };
            pos = posArr[rankNum];
            offsetPos = offsetPosArr[rankNum];

            foreach (string item in section)
            {
                bool isWhite = Char.IsUpper(item, 0);
                bool isBlack = (!Char.IsUpper(item, 0) && !Char.IsNumber(item, 0));
                bool isBlankSquare = Char.IsNumber(item, 0);

                if (isBlankSquare)
                {
                    for (int i = 0; i < Convert.ToInt32(item); i++)
                    {
                        Main._board[offsetPos] = " ";
                        Main.board[pos] = " ";
                        pos++;
                        offsetPos++;
                    }
                }

                if (isWhite)
                {
                    if (item == "P") // White Pawn
                    {
                        Main.board[pos] = "P";
                        Main._board[offsetPos] = "P";
                        Board.board_panels[pos].BackgroundImage = Resources.wp;
                        Board.board_panels[pos].BackgroundImage.Tag = "P";
                    }
                    if (item == "R") // White Rook
                    {
                        Main.board[pos] = "R";
                        Main._board[offsetPos] = "R";
                        Board.board_panels[pos].BackgroundImage = Resources.wr;
                        Board.board_panels[pos].BackgroundImage.Tag = "R";
                    }
                    if (item == "N") // White Knight
                    {
                        Main.board[pos] = "N";
                        Main._board[offsetPos] = "N";
                        Board.board_panels[pos].BackgroundImage = Resources.wn;
                        Board.board_panels[pos].BackgroundImage.Tag = "N";
                    }
                    if (item == "B") // White Bishop
                    {
                        Main.board[pos] = "B";
                        Main._board[offsetPos] = "B";
                        Board.board_panels[pos].BackgroundImage = Resources.wb;
                        Board.board_panels[pos].BackgroundImage.Tag = "B";
                    }
                    if (item == "Q") // White Queen
                    {
                        Main.board[pos] = "Q";
                        Main._board[offsetPos] = "Q";
                        Board.board_panels[pos].BackgroundImage = Resources.wq;
                        Board.board_panels[pos].BackgroundImage.Tag = "Q";
                    }
                    if (item == "K") // White King
                    {
                        Main.board[pos] = "K";
                        Main._board[offsetPos] = "K";
                        Board.board_panels[pos].BackgroundImage = Resources.wk;
                        Board.board_panels[pos].BackgroundImage.Tag = "K";
                    }
                    pos++;
                    offsetPos++;
                }

                if (isBlack)
                {
                    if (item == "p") // Black Pawn
                    {
                        Main.board[pos] = "p";
                        Main._board[offsetPos] = "p";
                        Board.board_panels[pos].BackgroundImage = Resources.bp;
                        Board.board_panels[pos].BackgroundImage.Tag = "p";
                    }
                    if (item == "r") // Black Rook
                    {
                        Main.board[pos] = "r";
                        Main._board[offsetPos] = "r";
                        Board.board_panels[pos].BackgroundImage = Resources.br;
                        Board.board_panels[pos].BackgroundImage.Tag = "r";
                    }
                    if (item == "n") // Black Knight
                    {
                        Main.board[pos] = "n";
                        Main._board[offsetPos] = "n";
                        Board.board_panels[pos].BackgroundImage = Resources.bn;
                        Board.board_panels[pos].BackgroundImage.Tag = "n";
                    }
                    if (item == "b") // Black Bishop
                    {
                        Main.board[pos] = "b";
                        Main._board[offsetPos] = "b";
                        Board.board_panels[pos].BackgroundImage = Resources.bb;
                        Board.board_panels[pos].BackgroundImage.Tag = "b";
                    }
                    if (item == "q") // Black Queen
                    {
                        Main.board[pos] = "q";
                        Main._board[offsetPos] = "q";
                        Board.board_panels[pos].BackgroundImage = Resources.bq;
                        Board.board_panels[pos].BackgroundImage.Tag = "q";
                    }
                    if (item == "k") // Black King
                    {
                        Main.board[pos] = "k";
                        Main._board[offsetPos] = "k";
                        Board.board_panels[pos].BackgroundImage = Resources.bk;
                        Board.board_panels[pos].BackgroundImage.Tag = "k";
                    }
                    pos++;
                    offsetPos++;
                }
            }
        }

        public static void Move(string prevPiece, int currentPos, int prevPos, bool isMoved)
        {
            int newPos;
            bool isPawnFirstMove = false;

            if (isMoved)
            {
                if (Board.board_panels[currentPos].BackgroundImage.Tag.ToString() == "legal")
                {
                    if (prevPiece == "P")
                    {
                        Board.board_panels[prevPos].BackgroundImage = null;
                        if (Main.board[prevPos - 8] == " ")
                        {
                            Board.board_panels[prevPos - 8].BackgroundImage = null;
                            if (Main.board[prevPos - 16] == " ")
                            {
                                Board.board_panels[prevPos - 16].BackgroundImage = null;
                            }
                        }

                        Board.board_panels[currentPos].BackgroundImage = Resources.wp;
                        Main.board[prevPos] = " ";
                        Main.board[currentPos] = "P";
                    }

                    if (prevPiece == "N")
                    {
                        Board.board_panels[prevPos].BackgroundImage = null;
                        if (Main.board[prevPos - 15] == " ")
                        {
                            Board.board_panels[prevPos - 15].BackgroundImage = null;
                        }
                        if (Main.board[prevPos - 17] == " ")
                        {
                            Board.board_panels[prevPos - 17].BackgroundImage = null;
                        }
                        if (Main.board[prevPos - 6] == " ")
                        {
                            Board.board_panels[prevPos - 6].BackgroundImage = null;
                        }
                        if (Main.board[prevPos + 10] == " ")
                        {
                            Board.board_panels[prevPos + 10].BackgroundImage = null;
                        }
                        if (Main.board[prevPos + 17] == " ")
                        {
                            Board.board_panels[prevPos + 17].BackgroundImage = null;
                        }
                        if (Main.board[prevPos + 15] == " ")
                        {
                            Board.board_panels[prevPos + 15].BackgroundImage = null;
                        }
                        if (Main.board[prevPos - 10] == " ")
                        {
                            Board.board_panels[prevPos - 10].BackgroundImage = null;
                        }
                        if (Main.board[prevPos + 6] == " ")
                        {
                            Board.board_panels[prevPos + 6].BackgroundImage = null;
                        }

                        Board.board_panels[currentPos].BackgroundImage = Resources.wn;
                        Main.board[prevPos] = " ";
                        Main.board[currentPos] = "N";
                    }

                    if (prevPiece == "K")
                    {
                        Board.board_panels[prevPos].BackgroundImage = null;
                        try
                        {
                            if (Main.board[currentPos - 9] == " ")
                            {
                                Board.board_panels[prevPos - 9].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main.board[currentPos - 8] == " ")
                            {
                                Board.board_panels[prevPos - 8].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main.board[currentPos - 7] == " ")
                            {
                                Board.board_panels[prevPos - 7].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main.board[currentPos - 1] == " ")
                            {
                                Board.board_panels[prevPos - 1].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main.board[currentPos + 1] == " ")
                            {
                                Board.board_panels[prevPos + 1].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main.board[currentPos + 9] == " ")
                            {
                                Board.board_panels[prevPos + 9].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main.board[currentPos + 8] == " ")
                            {
                                Board.board_panels[prevPos + 8].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main.board[currentPos + 7] == " ")
                            {
                                Board.board_panels[prevPos + 7].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    }
                }
            }
            else
            {
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
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        if (isPawnFirstMove && Main.board[currentPos - 16] == " ")
                        {
                            newPos = currentPos - 16;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        }

                    }
                }

                if (piece == "N")
                {
                    // NNE - 2 UP, 1 RIGHT
                    if (Main.board[currentPos - 15] == " ")
                    {
                        newPos = currentPos - 15;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // NNW - 2 UP, 1 LEFT
                    if (Main.board[currentPos - 17] == " ")
                    {
                        newPos = currentPos - 17;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // EEN - 2 RIGHT, 1 UP
                    if (Main.board[currentPos - 6] == " ")
                    {
                        newPos = currentPos - 6;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // EES - 2 RIGHT, 1 DOWN
                    if (Main.board[currentPos + 10] == " ")
                    {
                        newPos = currentPos + 10;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // SSE - 2 DOWN, 1 RIGHT
                    if (Main.board[currentPos + 17] == " ")
                    {
                        newPos = currentPos + 17;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // SSW - 2 DOWN, 1 LEFT
                    if (Main.board[currentPos + 15] == " ")
                    {
                        newPos = currentPos + 15;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // WWN - 2 LEFT, 1 UP
                    if (Main.board[currentPos - 10] == " ")
                    {
                        newPos = currentPos - 10;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // WWS - 2 LEFT, 1 DOWN 
                    if (Main.board[currentPos + 6] == " ")
                    {
                        newPos = currentPos + 6;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }
                }

                if (piece == "K")
                {
                    try
                    {
                        if (Main.board[currentPos - 9] == " ")
                        {
                            newPos = currentPos - 9;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                    try
                    {
                        if (Main.board[currentPos - 8] == " ")
                        {
                            newPos = currentPos - 8;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    try
                    {
                        if (Main.board[currentPos - 7] == " ")
                        {
                            newPos = currentPos - 7;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                    try
                    {
                        if (Main.board[currentPos - 1] == " ")
                        {
                            newPos = currentPos - 1;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    try
                    {
                        if (Main.board[currentPos + 1] == " ")
                        {
                            newPos = currentPos + 1;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    try
                    {
                        if (Main.board[currentPos + 9] == " ")
                        {
                            newPos = currentPos + 9;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    try
                    {
                        if (Main.board[currentPos + 8] == " ")
                        {
                            newPos = currentPos + 8;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    try
                    {
                        if (Main.board[currentPos + 7] == " ")
                        {
                            newPos = currentPos + 7;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                }
                if (piece == "B")
                {
                    
                }
            }
        }
    }
}