using DailyChessPuzzle.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Drawing;
using Button = System.Windows.Forms.Button;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;
using TextBox = System.Windows.Forms.TextBox;

namespace DailyChessPuzzle
{
    internal class Piece
    {
        public static string piece;
        private static string dialogResult;

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

            // Effective - Replaces 8 ifs
            int[] posArr = new int[9] { 0, 112, 96, 80, 64, 48, 32, 16, 0 };
            pos = posArr[rankNum];

            foreach (string item in section)
            {
                // Checks if Piece is uppercase (which means white) or lowercase
                // (which means black). IF number, then that means blank square.

                bool isWhite = Char.IsUpper(item, 0);
                bool isBlack = (!Char.IsUpper(item, 0) && !Char.IsNumber(item, 0));
                bool isBlankSquare = Char.IsNumber(item, 0);

                if (Board.isOnBoard(pos))
                {
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
                else
                {
                    pos++;
                }
            }
        }

        public static void Move(Control control, string prevPiece, int currentPos, int prevPos, bool isMoved, string prevSquareName, string currentSquareName)
        {
            int pos, newPos;
            string targetedPiece;
            bool isPawnFirstMove = false;

            // 

            if (isMoved)
            {
                if (prevPiece == "P" && PawnPromote((prevPos - 16), prevPos)) currentSquareName += dialogResult;
                if (Puzzle.IsMove(prevSquareName, prevPos, currentSquareName, currentPos, prevPiece))
                {
                    if (Board.board_panels[currentPos].BackgroundImage.Tag.ToString() == "legal")
                    {
                        // IF the selected piece is "P" (a white pawn) and is legal, then previous square (currently
                        // containing the pawn's image) will be cleared, as well as all highlighted legal moves.
                        // Then the pawn will be displayed in its new position on the board
                        if (prevPiece == "P")
                        {
                            Board.board_panels[prevPos].BackgroundImage = null;
                            if (Main.board[prevPos - 16] == " " && Board.isOnBoard(prevPos - 16))
                            {
                                Board.board_panels[prevPos - 16].BackgroundImage = null;
                                PawnPromote((prevPos - 16), prevPos);
                                if (Main.board[prevPos - 32] == " " && Board.isOnBoard(prevPos - 32))
                                {
                                    Board.board_panels[prevPos - 32].BackgroundImage = null;
                                }
                            }

                            if (Main.board[prevPos - 17] != " " && !Char.IsUpper(Main.board[prevPos - 17], 0))
                            {
                                if (prevPos != currentPos)
                                {
                                    Board.board_panels[prevPos - 17].BackgroundImage = null;
                                }
                                else
                                {
                                    targetedPiece = Main.board[currentPos - 17];
                                    ResetPiece((prevPos - 17), targetedPiece);
                                }
                            }
                            if (Main.board[prevPos - 15] != " " && !Char.IsUpper(Main.board[prevPos - 15], 0))
                            {
                                if (prevPos != currentPos)
                                {
                                    Board.board_panels[prevPos - 15].BackgroundImage = null;
                                }
                                else
                                {
                                    targetedPiece = Main.board[currentPos - 17];
                                    ResetPiece((prevPos - 17), targetedPiece);
                                }
                            }

                            if (!PawnPromote((prevPos - 16), prevPos))
                            {
                                Board.board_panels[currentPos].BackgroundImage = Resources.wp;
                                Board.board_panels[currentPos].BackgroundImage.Tag = "P";
                                Main.board[prevPos] = " ";
                                Main.board[currentPos] = "P";
                            }
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
                            Board.board_panels[currentPos].BackgroundImage.Tag = "N";
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

                            Board.board_panels[currentPos].BackgroundImage = Resources.wk;
                            Board.board_panels[currentPos].BackgroundImage.Tag = "K";
                            Main.board[prevPos] = " ";
                            Main.board[currentPos] = "K";
                        }
                    }

                    if (prevPiece == "B")
                    {
                        Board.board_panels[prevPos].BackgroundImage = null;

                        // NE
                        pos = prevPos;
                        while (Board.isOnBoard(pos - 15))
                        {
                            if (Main.board[pos - 15] == " ")
                            {
                                pos -= 15;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // NW
                        pos = prevPos;
                        while (Board.isOnBoard(pos - 17))
                        {
                            if (Main.board[pos - 17] == " ")
                            {
                                pos -= 17;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // SE
                        pos = prevPos;
                        while (Board.isOnBoard(pos + 17))
                        {
                            if (Main.board[pos + 17] == " ")
                            {
                                pos += 17;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // SW
                        pos = prevPos;
                        while (Board.isOnBoard(pos + 15))
                        {
                            if (Main.board[pos + 15] == " ")
                            {
                                pos += 15;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        Board.board_panels[currentPos].BackgroundImage = Resources.wb;
                        Board.board_panels[currentPos].BackgroundImage.Tag = "B";
                        Main.board[prevPos] = " ";
                        Main.board[currentPos] = "B";
                    }

                    if (prevPiece == "R")
                    {
                        Board.board_panels[prevPos].BackgroundImage = null;

                        // N
                        pos = prevPos;
                        while (Board.isOnBoard(pos - 16))
                        {
                            if (Main.board[pos - 16] == " ")
                            {
                                pos -= 16;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // E
                        pos = prevPos;
                        while (Board.isOnBoard(pos + 1))
                        {
                            if (Main.board[pos + 1] == " ")
                            {
                                pos += 1;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // S
                        pos = prevPos;
                        while (Board.isOnBoard(pos + 16))
                        {
                            if (Main.board[pos + 16] == " ")
                            {
                                pos += 16;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // W
                        pos = prevPos;
                        while (Board.isOnBoard(pos - 1))
                        {
                            if (Main.board[pos - 1] == " ")
                            {
                                pos -= 1;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        Board.board_panels[currentPos].BackgroundImage = Resources.wr;
                        Board.board_panels[currentPos].BackgroundImage.Tag = "R";
                        Main.board[prevPos] = " ";
                        Main.board[currentPos] = "R";
                    }

                    if (prevPiece == "Q")
                    {
                        Board.board_panels[prevPos].BackgroundImage = null;
                        // NW
                        pos = prevPos;
                        while (Board.isOnBoard(pos - 17))
                        {
                            if (Main.board[pos - 17] == " ")
                            {
                                pos -= 17;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // N
                        pos = prevPos;
                        while (Board.isOnBoard(pos - 16))
                        {
                            if (Main.board[pos - 16] == " ")
                            {
                                pos -= 16;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // NE
                        pos = prevPos;
                        while (Board.isOnBoard(pos - 15))
                        {
                            if (Main.board[pos - 15] == " ")
                            {
                                pos -= 15;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // W
                        pos = prevPos;
                        while (Board.isOnBoard(pos - 1))
                        {
                            if (Main.board[pos - 1] == " ")
                            {
                                pos -= 1;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // E
                        pos = prevPos;
                        while (Board.isOnBoard(pos + 1))
                        {
                            if (Main.board[pos + 1] == " ")
                            {
                                pos += 1;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // SW
                        pos = prevPos;
                        while (Board.isOnBoard(pos + 15))
                        {
                            if (Main.board[pos + 15] == " ")
                            {
                                pos += 15;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // S
                        pos = prevPos;
                        while (Board.isOnBoard(pos + 16))
                        {
                            if (Main.board[pos + 16] == " ")
                            {
                                pos += 16;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        // SE
                        pos = prevPos;
                        while (Board.isOnBoard(pos + 17))
                        {
                            if (Main.board[pos + 17] == " ")
                            {
                                pos += 17;
                                Board.board_panels[pos].BackgroundImage = null;
                            }
                            else break;
                        }

                        Board.board_panels[currentPos].BackgroundImage = Resources.wq;
                        Board.board_panels[currentPos].BackgroundImage.Tag = "Q";
                        Main.board[prevPos] = " ";
                        Main.board[currentPos] = "Q";
                    }


                    try
                    {
                        Main.ComputerMove(Puzzle.moveArr[Puzzle.moveCount]);
                    }
                    catch (IndexOutOfRangeException)
                    {

                        Puzzle.isWon = true;
                        Puzzle.IsFinished();
                    }
                }
            }
            else
            {
                if (piece == "P")
                {
                    // IF the pawn is in it's starting square (2nd rank if white | 7th rank if black) then
                    // pawn is able to move up two squares
                    if (Board.startingPos[currentPos] == piece)
                    {
                        isPawnFirstMove = true;
                    }

                    // If first move for pawn, is pawn blocked from moving forward 2? No, allow piece to move
                    // forward 2 squares. Yes, Can piece be moved 1 square?
                    Console.WriteLine(Board.isOnBoard(prevPos - 16));
                    if (Main.board[currentPos - 16] == " " && Board.isOnBoard(prevPos - 16))
                    {
                        newPos = currentPos - 16;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        if (isPawnFirstMove && Main.board[currentPos - 32] == " " && Board.isOnBoard(prevPos - 32))
                        {
                            newPos = currentPos - 32;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        }

                    }
                    // Capture L
                    if (Main.board[currentPos - 17] != " " && !Char.IsUpper(Main.board[currentPos - 17], 0))
                    {
                        newPos = currentPos - 17;
                        CanCapture(newPos);
                    }
                    
                    // Capture R
                    if (Main.board[currentPos - 15] != " " && !Char.IsUpper(Main.board[currentPos - 15], 0))
                    {
                        newPos = currentPos - 15;
                        CanCapture(newPos);
                    }
                }

                if (piece == "N")
                {
                    // NNE - 2 UP, 1 RIGHT
                    if (Board.isOnBoard(currentPos - 31))
                    {
                        if (Main.board[currentPos - 31] == " ")
                        {
                            newPos = currentPos - 31;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos - 31])))
                        {
                            newPos = currentPos - 31;
                            CanCapture(newPos);
                        }
                    }

                    // NNW - 2 UP, 1 LEFT
                    if (Board.isOnBoard(currentPos - 33))
                    {
                        if (Main.board[currentPos - 33] == " ")
                        {
                            newPos = currentPos - 33;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos - 33])))
                        {
                            newPos = currentPos - 33;
                            CanCapture(newPos);
                        }
                    }

                    // EEN - 2 RIGHT, 1 UP
                    if (Board.isOnBoard(currentPos - 14))
                    {
                        if (Main.board[currentPos - 14] == " ")
                        {
                            newPos = currentPos - 14;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos - 14])))
                        {
                            newPos = currentPos - 14;
                            CanCapture(newPos);
                        }
                    }

                    // EES - 2 RIGHT, 1 DOWN
                    if (Board.isOnBoard(currentPos + 18))
                    {
                        if (Main.board[currentPos + 18] == " ")
                        {
                            newPos = currentPos + 18;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos + 18])))
                        {
                            newPos = currentPos + 18;
                            CanCapture(newPos);
                        }
                    }

                    // SSE - 2 DOWN, 1 RIGHT
                    if (Board.isOnBoard(currentPos + 31))
                    {
                        if (Main.board[currentPos + 31] == " ")
                        {
                            newPos = currentPos + 31;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos + 31])))
                        {
                            newPos = currentPos + 31;
                            CanCapture(newPos);
                        }
                    }

                    // SSW - 2 DOWN, 1 LEFT
                    if (Board.isOnBoard(currentPos + 33))
                    {
                        if (Main.board[currentPos + 33] == " ")
                        {
                            newPos = currentPos + 33;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos + 33])))
                        {
                            newPos = currentPos + 33;
                            CanCapture(newPos);
                        }
                    }

                    // WWN - 2 LEFT, 1 UP
                    if (Board.isOnBoard(currentPos - 18))
                    {
                        if (Main.board[currentPos - 18] == " ")
                        {
                            newPos = currentPos - 18;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos - 18])))
                        {
                            newPos = currentPos - 18;
                            CanCapture(newPos);
                        }
                    }

                    // WWS - 2 LEFT, 1 DOWN 
                    if (Board.isOnBoard(currentPos + 14))
                    {
                        if (Main.board[currentPos + 14] == " ")
                        {
                            newPos = currentPos + 14;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos + 14])))
                        {
                            newPos = currentPos + 14;
                            CanCapture(newPos);
                        }
                    }
                }

                if (piece == "K")
                {
                    // NW
                    try
                    {
                        if (Main.board[currentPos - 17] == " ")
                        {
                            newPos = currentPos - 17;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos - 17])))
                        {
                            newPos = currentPos - 17;
                            CanCapture(newPos);
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                    // N
                    try
                    {
                        if (Main.board[currentPos - 16] == " ")
                        {
                            newPos = currentPos - 16;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos - 16])))
                        {
                            newPos = currentPos - 16;
                            CanCapture(newPos);
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    // NE
                    try
                    {
                        if (Main.board[currentPos - 15] == " ")
                        {
                            newPos = currentPos - 15;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos - 15])))
                        {
                            newPos = currentPos - 15;
                            CanCapture(newPos);
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                    // W
                    try
                    {
                        if (Main.board[currentPos - 1] == " ")
                        {
                            newPos = currentPos - 1;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos - 1])))
                        {
                            newPos = currentPos - 1;
                            CanCapture(newPos);
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    // E
                    try
                    {
                        if (Main.board[currentPos + 1] == " ")
                        {
                            newPos = currentPos + 1;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos + 1])))
                        {
                            newPos = currentPos + 1;
                            CanCapture(newPos);
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    // SW
                    try
                    {
                        if (Main.board[currentPos + 17] == " ")
                        {
                            newPos = currentPos + 17;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos + 17])))
                        {
                            newPos = currentPos + 17;
                            CanCapture(newPos);
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    // S
                    try
                    {
                        if (Main.board[currentPos + 16] == " ")
                        {
                            newPos = currentPos + 16;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos + 16])))
                        {
                            newPos = currentPos + 16;
                            CanCapture(newPos);
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    // SE
                    try
                    {
                        if (Main.board[currentPos + 15] == " ")
                        {
                            newPos = currentPos + 15;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[currentPos + 15])))
                        {
                            newPos = currentPos + 15;
                            CanCapture(newPos);
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                }
                if (piece == "B")
                {
                    pos = currentPos;
                    // NE
                    while (Board.isOnBoard(pos - 15))
                    {
                        if (Main.board[pos - 15] == " ")
                        {
                            pos -= 15;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos - 15])))
                        {
                            pos += 15;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // NW
                    pos = currentPos;
                    while (Board.isOnBoard(pos - 17))
                    {
                        if (Main.board[pos - 17] == " ")
                        {
                            pos -= 17;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos - 17])))
                        {
                            pos += 17;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // SE
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 17))
                    {
                        if (Main.board[pos + 17] == " ")
                        {
                            pos += 17;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos + 17])))
                        {
                            pos += 17;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // SW
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 15))
                    {
                        if (Main.board[pos + 15] == " ")
                        {
                            pos += 15;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos + 15])))
                        {
                            pos += 15;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }
                }

                if (piece == "R")
                {
                    // N
                    pos = currentPos;
                    while (Board.isOnBoard(pos - 16))
                    {
                        if (Main.board[pos - 16] == " ")
                        {
                            pos -= 16;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos - 16])))
                        {
                            pos -= 16;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // E
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 1))
                    {
                        if (Main.board[pos + 1] == " ")
                        {
                            pos += 1;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos + 1])))
                        {
                            pos += 1;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // S
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 16))
                    {
                        if (Main.board[pos + 16] == " ")
                        {
                            pos += 16;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos + 16])))
                        {
                            pos += 16;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // W
                    pos = currentPos;
                    while (Board.isOnBoard(pos - 1))
                    {
                        if (Main.board[pos - 1] == " ")
                        {
                            pos -= 1;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos - 1])))
                        {
                            pos -= 1;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }
                }

                if (piece == "Q")
                {
                    // NW
                    pos = currentPos;
                    while (Board.isOnBoard(pos - 17))
                    {
                        if (Main.board[pos - 17] == " ")
                        {
                            pos -= 17;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos - 17])))
                        {
                            pos -= 17;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // N
                    pos = currentPos;
                    while (Board.isOnBoard(pos - 16))
                    {
                        if (Main.board[pos - 16] == " ")
                        {
                            pos -= 16;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos - 16])))
                        {
                            pos -= 16;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // NE
                    pos = currentPos;
                    while (Board.isOnBoard(pos - 15))
                    {
                        if (Main.board[pos - 15] == " ")
                        {
                            pos -= 15;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos - 15])))
                        {
                            pos -= 15;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // W
                    pos = currentPos;
                    while (Board.isOnBoard(pos - 1))
                    {
                        if (Main.board[pos - 1] == " ")
                        {
                            pos -= 1;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos - 1])))
                        {
                            pos -= 1;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // E
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 1))
                    {
                        if (Main.board[pos + 1] == " ")
                        {
                            pos += 1;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos + 1])))
                        {
                            pos += 1;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // SW
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 15))
                    {
                        if (Main.board[pos + 15] == " ")
                        {
                            pos += 15;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos + 15])))
                        {
                            pos += 15;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // S
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 16))
                    {
                        if (Main.board[pos + 16] == " ")
                        {
                            pos += 16;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos - 16])))
                        {
                            pos += 16;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }

                    // SE
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 17))
                    {
                        if (Main.board[pos + 17] == " ")
                        {
                            pos += 17;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else if (!Char.IsUpper(Convert.ToChar(Main.board[pos + 17])))
                        {
                            pos += 17;
                            CanCapture(pos);
                            break;
                        }
                        else break;
                    }
                }
            }
        }

        private static bool PawnPromote(int newPos, int prevPos)
        {
            int[] topRank = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
            if (topRank.Contains(newPos))
            {
                Dialog();
                string newPiece = dialogResult;

                Board.board_panels[prevPos].BackgroundImage = null;
                if (newPiece == "Q")
                {
                    Board.board_panels[newPos].BackgroundImage = Resources.wq;
                    Board.board_panels[newPos].BackgroundImage.Tag = "Q";
                    Main.board[prevPos] = " ";
                    Main.board[newPos] = "Q";
                }
                if (newPiece == "R")
                {
                    Board.board_panels[newPos].BackgroundImage = Resources.wr;
                    Board.board_panels[newPos].BackgroundImage.Tag = "R";
                    Main.board[prevPos] = " ";
                    Main.board[newPos] = "R";
                }
                if (newPiece == "N")
                {
                    Board.board_panels[newPos].BackgroundImage = Resources.wn;
                    Board.board_panels[newPos].BackgroundImage.Tag = "N";
                    Main.board[prevPos] = " ";
                    Main.board[newPos] = "N";
                }
                if (newPiece == "B")
                {
                    Board.board_panels[newPos].BackgroundImage = Resources.wb;
                    Board.board_panels[newPos].BackgroundImage.Tag = "B";
                    Main.board[prevPos] = " ";
                    Main.board[newPos] = "B";
                }
                return true;
            }
            return false;
        }

        private static void Dialog()
        {
            Form form = new Form();
            Label lblTitle = new Label();
            Label lblText = new Label();
            TextBox tbx = new TextBox();
            Button btnOk = new Button();
            Button btnCancel = new Button();

            form.Size = new Size(344, 200);
            form.Text = "";
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MinimizeBox = false;
            form.MaximizeBox = false;

            lblTitle.Text = "PIECE PROMOTION";
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(304, 39);
            lblTitle.Font = new Font("Outfit", 18, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            lblText.Text = "Type one of the following to promote to that piece: Q - Queen, R - Rook, N - Knight, B - Bishop.";
            lblText.AutoSize = false;
            lblText.Size = new Size(304, 39);
            lblText.Font = new Font("Outfit", (float)8.25, FontStyle.Regular);
            lblText.Location = new Point(12, 59);

            tbx.Size = new Size(50, 39);
            tbx.Location = new Point(12, 99);

            btnOk.Text = "OK";
            btnOk.Size = new Size(50, 30);
            btnOk.Location = new Point(65, 125);
            btnOk.Click += (sender, EventArgs) =>
            {
                if (tbx.Text.ToUpper() == "Q") dialogResult = "Q";
                if (tbx.Text.ToUpper() == "R") dialogResult = "R";
                if (tbx.Text.ToUpper() == "N") dialogResult = "N";
                if (tbx.Text.ToUpper() == "B") dialogResult = "B";
                form.Close();
            };

            btnCancel.Text = "Cancel";
            btnCancel.Size = new Size(50, 30);
            btnCancel.Location = new Point(12, 125);
            btnCancel.Click += (sender, EventArgs) =>
            {
                form.Close();
            };

            form.Controls.Add(lblTitle);
            form.Controls.Add(lblText);
            form.Controls.Add(tbx);
            form.Controls.Add(btnCancel);
            form.Controls.Add(btnOk);

            form.ShowDialog();
        }

        private static void CanCapture(int pos)
        {
            string piece = Main.board[pos];
            if (piece == "p")
            {
                Board.board_panels[pos].BackgroundImage = Resources.bp_c;
                Board.board_panels[pos].BackgroundImage.Tag = "capture p";
                Main.legal_board[pos] = "capture p";
            }
            if (piece == "n")
            {
                Board.board_panels[pos].BackgroundImage = Resources.bn_c;
                Board.board_panels[pos].BackgroundImage.Tag = "capture n";
                Main.legal_board[pos] = "capture n";
            }
            if (piece == "b")
            {
                Board.board_panels[pos].BackgroundImage = Resources.bb_c;
                Board.board_panels[pos].BackgroundImage.Tag = "capture b";
                Main.legal_board[pos] = "capture b";
            }
            if (piece == "r")
            {
                Board.board_panels[pos].BackgroundImage = Resources.br_c;
                Board.board_panels[pos].BackgroundImage.Tag = "capture r";
                Main.legal_board[pos] = "capture r";
            }
            if (piece == "q")
            {
                Board.board_panels[pos].BackgroundImage = Resources.bq_c;
                Board.board_panels[pos].BackgroundImage.Tag = "capture q";
                Main.legal_board[pos] = "capture q";
            }
        }

        public static void Captured(string piece, int currentPos, int prevPos)
        {
            if (piece == "P")
            {
                Board.board_panels[currentPos].BackgroundImage = Resources.wp;
                Board.board_panels[currentPos].BackgroundImage.Tag = "P";
                Board.board_panels[prevPos].BackgroundImage = null;
                Main.legal_board[currentPos] = " ";
                Main.board[currentPos] = "P";
                Main.board[prevPos] = " ";
            }
            if (piece == "N")
            {
                Board.board_panels[currentPos].BackgroundImage = Resources.wn;
                Board.board_panels[currentPos].BackgroundImage.Tag = "N";
                Board.board_panels[prevPos].BackgroundImage = null;
                Main.legal_board[currentPos] = " ";
                Main.board[currentPos] = "N";
                Main.board[prevPos] = " ";
            }
            if (piece == "B")
            {
                Board.board_panels[currentPos].BackgroundImage = Resources.wb;
                Board.board_panels[currentPos].BackgroundImage.Tag = "B";
                Board.board_panels[prevPos].BackgroundImage = null;
                Main.legal_board[currentPos] = " ";
                Main.board[currentPos] = "B";
                Main.board[prevPos] = " ";
            }
            if (piece == "R")
            {
                Board.board_panels[currentPos].BackgroundImage = Resources.wr;
                Board.board_panels[currentPos].BackgroundImage.Tag = "R";
                Board.board_panels[prevPos].BackgroundImage = null;
                Main.legal_board[currentPos] = " ";
                Main.board[currentPos] = "R";
                Main.board[prevPos] = " ";
            }
            if (piece == "Q")
            {
                Board.board_panels[currentPos].BackgroundImage = Resources.wq;
                Board.board_panels[currentPos].BackgroundImage.Tag = "Q";
                Board.board_panels[prevPos].BackgroundImage = null;
                Main.legal_board[currentPos] = " ";
                Main.board[currentPos] = "Q";
                Main.board[prevPos] = " ";
            }
            if (piece == "K")
            {
                Board.board_panels[currentPos].BackgroundImage = Resources.wk;
                Board.board_panels[currentPos].BackgroundImage.Tag = "K";
                Board.board_panels[prevPos].BackgroundImage = null;
                Main.legal_board[currentPos] = " ";
                Main.board[currentPos] = "K";
                Main.board[prevPos] = " ";
            }

            try
            {
                Main.ComputerMove(Puzzle.moveArr[Puzzle.moveCount]);
            }
            catch (IndexOutOfRangeException)
            {

                Puzzle.isWon = true;
                Puzzle.IsFinished();
            }
        }

        private static void ResetPiece(int pos, string piece)
        {
            if (piece == "p")
            {
                Board.board_panels[pos].BackgroundImage = null;
            }
        }
    }
}