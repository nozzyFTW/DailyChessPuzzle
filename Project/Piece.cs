﻿using DailyChessPuzzle.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DailyChessPuzzle
{
    internal class Piece
    {
        public static string piece;

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

                if (Board.isOnBoard(offsetPos))
                {
                    if (isBlankSquare)
                    {
                        for (int i = 0; i < Convert.ToInt32(item); i++)
                        {
                            Main._board[offsetPos] = " ";
                            //Main.board[pos] = " ";
                            pos++;
                            offsetPos++;
                        }
                    }

                    if (isWhite)
                    {
                        if (item == "P") // White Pawn
                        {
                            //Main.board[pos] = "P";
                            Main._board[offsetPos] = "P";
                            Board.board_panels[offsetPos].BackgroundImage = Resources.wp;
                            Board.board_panels[offsetPos].BackgroundImage.Tag = "P";
                        }
                        if (item == "R") // White Rook
                        {
                            //Main.board[pos] = "R";
                            Main._board[offsetPos] = "R";
                            Board.board_panels[offsetPos].BackgroundImage = Resources.wr;
                            Board.board_panels[offsetPos].BackgroundImage.Tag = "R";
                        }
                        if (item == "N") // White Knight
                        {
                            //Main.board[pos] = "N";
                            Main._board[offsetPos] = "N";
                            Board.board_panels[offsetPos].BackgroundImage = Resources.wn;
                            Board.board_panels[offsetPos].BackgroundImage.Tag = "N";
                        }
                        if (item == "B") // White Bishop
                        {
                            //Main.board[pos] = "B";
                            Main._board[offsetPos] = "B";
                            Board.board_panels[offsetPos].BackgroundImage = Resources.wb;
                            Board.board_panels[offsetPos].BackgroundImage.Tag = "B";
                        }
                        if (item == "Q") // White Queen
                        {
                            //Main.board[pos] = "Q";
                            Main._board[offsetPos] = "Q";
                            Board.board_panels[offsetPos].BackgroundImage = Resources.wq;
                            Board.board_panels[offsetPos].BackgroundImage.Tag = "Q";
                        }
                        if (item == "K") // White King
                        {
                            //Main.board[pos] = "K";
                            Main._board[offsetPos] = "K";
                            Board.board_panels[offsetPos].BackgroundImage = Resources.wk;
                            Board.board_panels[offsetPos].BackgroundImage.Tag = "K";
                        }
                        pos++;
                        offsetPos++;
                    }

                    if (isBlack)
                    {
                        if (item == "p") // Black Pawn
                        {
                            //Main.board[pos] = "p";
                            Main._board[offsetPos] = "p";
                            Board.board_panels[offsetPos].BackgroundImage = Resources.bp;
                            Board.board_panels[offsetPos].BackgroundImage.Tag = "p";
                        }
                        if (item == "r") // Black Rook
                        {
                            //Main.board[pos] = "r";
                            Main._board[offsetPos] = "r";
                            Board.board_panels[offsetPos].BackgroundImage = Resources.br;
                            Board.board_panels[offsetPos].BackgroundImage.Tag = "r";
                        }
                        if (item == "n") // Black Knight
                        {
                            //Main.board[pos] = "n";
                            Main._board[offsetPos] = "n";
                            Board.board_panels[offsetPos].BackgroundImage = Resources.bn;
                            Board.board_panels[offsetPos].BackgroundImage.Tag = "n";
                        }
                        if (item == "b") // Black Bishop
                        {
                            //Main.board[pos] = "b";
                            Main._board[offsetPos] = "b";
                            Board.board_panels[offsetPos].BackgroundImage = Resources.bb;
                            Board.board_panels[offsetPos].BackgroundImage.Tag = "b";
                        }
                        if (item == "q") // Black Queen
                        {
                            //Main.board[pos] = "q";
                            Main._board[offsetPos] = "q";
                            Board.board_panels[offsetPos].BackgroundImage = Resources.bq;
                            Board.board_panels[offsetPos].BackgroundImage.Tag = "q";
                        }
                        if (item == "k") // Black King
                        {
                            //Main.board[pos] = "k";
                            Main._board[offsetPos] = "k";
                            Board.board_panels[offsetPos].BackgroundImage = Resources.bk;
                            Board.board_panels[offsetPos].BackgroundImage.Tag = "k";
                        }
                        pos++;
                        offsetPos++;
                    }
                }
                else
                {
                    offsetPos++;
                }
            }
        }

        public static void Move(Control control, string prevPiece, int currentPos, int prevPos, bool isMoved)
        {
            int pos, newPos;
            bool isPawnFirstMove = false;

            if (isMoved)
            {
                if (Board.board_panels[currentPos].BackgroundImage.Tag.ToString() == "legal")
                {
                    if (prevPiece == "P")
                    {
                        Board.board_panels[prevPos].BackgroundImage = null;
                        if (Main._board[prevPos - 16] == " " && Board.isOnBoard(prevPos - 16))
                        {
                            Board.board_panels[prevPos - 16].BackgroundImage = null;
                            if (Main._board[prevPos - 32] == " " && Board.isOnBoard(prevPos - 32))
                            {
                                Board.board_panels[prevPos - 32].BackgroundImage = null;
                            }
                        }

                        Board.board_panels[currentPos].BackgroundImage = Resources.wp;
                        Main._board[prevPos] = " ";
                        Main._board[currentPos] = "P";
                    }

                    if (prevPiece == "N")
                    {
                        Board.board_panels[prevPos].BackgroundImage = null;
                        if (Main._board[prevPos - 15] == " ")
                        {
                            Board.board_panels[prevPos - 15].BackgroundImage = null;
                        }
                        if (Main._board[prevPos - 17] == " ")
                        {
                            Board.board_panels[prevPos - 17].BackgroundImage = null;
                        }
                        if (Main._board[prevPos - 6] == " ")
                        {
                            Board.board_panels[prevPos - 6].BackgroundImage = null;
                        }
                        if (Main._board[prevPos + 10] == " ")
                        {
                            Board.board_panels[prevPos + 10].BackgroundImage = null;
                        }
                        if (Main._board[prevPos + 17] == " ")
                        {
                            Board.board_panels[prevPos + 17].BackgroundImage = null;
                        }
                        if (Main._board[prevPos + 15] == " ")
                        {
                            Board.board_panels[prevPos + 15].BackgroundImage = null;
                        }
                        if (Main._board[prevPos - 10] == " ")
                        {
                            Board.board_panels[prevPos - 10].BackgroundImage = null;
                        }
                        if (Main._board[prevPos + 6] == " ")
                        {
                            Board.board_panels[prevPos + 6].BackgroundImage = null;
                        }

                        Board.board_panels[currentPos].BackgroundImage = Resources.wn;
                        Main._board[prevPos] = " ";
                        Main._board[currentPos] = "N";
                    }

                    if (prevPiece == "K")
                    {
                        Board.board_panels[prevPos].BackgroundImage = null;
                        try
                        {
                            if (Main._board[currentPos - 9] == " ")
                            {
                                Board.board_panels[prevPos - 9].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main._board[currentPos - 8] == " ")
                            {
                                Board.board_panels[prevPos - 8].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main._board[currentPos - 7] == " ")
                            {
                                Board.board_panels[prevPos - 7].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main._board[currentPos - 1] == " ")
                            {
                                Board.board_panels[prevPos - 1].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main._board[currentPos + 1] == " ")
                            {
                                Board.board_panels[prevPos + 1].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main._board[currentPos + 9] == " ")
                            {
                                Board.board_panels[prevPos + 9].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main._board[currentPos + 8] == " ")
                            {
                                Board.board_panels[prevPos + 8].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        try
                        {
                            if (Main._board[currentPos + 7] == " ")
                            {
                                Board.board_panels[prevPos + 7].BackgroundImage = null;
                            }
                        }
                        catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                        Board.board_panels[currentPos].BackgroundImage = Resources.wk;
                        Main._board[prevPos] = " ";
                        Main._board[currentPos] = "K";
                    }
                }

                if (prevPiece == "B")
                {
                    Board.board_panels[prevPos].BackgroundImage = null;

                    // NE
                    pos = prevPos;
                    while (Board.isOnBoard(pos - 15))
                    {
                        if (Main._board[pos - 15] == " ")
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
                        if (Main._board[pos - 17] == " ")
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
                        if (Main._board[pos + 17] == " ")
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
                        if (Main._board[pos + 15] == " ")
                        {
                            pos += 15;
                            Board.board_panels[pos].BackgroundImage = null;
                        }
                        else break;
                    }

                    Board.board_panels[currentPos].BackgroundImage = Resources.wb;
                    Main._board[prevPos] = " ";
                    Main._board[currentPos] = "B";
                }

                if (prevPiece == "R")
                {
                    Board.board_panels[prevPos].BackgroundImage = null;

                    // N
                    pos = prevPos;
                    while (Board.isOnBoard(pos - 16))
                    {
                        if (Main._board[pos - 16] == " ")
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
                        if (Main._board[pos + 1] == " ")
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
                        if (Main._board[pos + 16] == " ")
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
                        if (Main._board[pos - 1] == " ")
                        {
                            pos -= 1;
                            Board.board_panels[pos].BackgroundImage = null;
                        }
                        else break;
                    }

                    Board.board_panels[currentPos].BackgroundImage = Resources.wr;
                    Main._board[prevPos] = " ";
                    Main._board[currentPos] = "R";
                }

                if (prevPiece == "Q")
                {
                    Board.board_panels[prevPos].BackgroundImage = null;
                    // NW
                    pos = prevPos;
                    while (Board.isOnBoard(pos - 17))
                    {
                        if (Main._board[pos - 17] == " ")
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
                        if (Main._board[pos - 16] == " ")
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
                        if (Main._board[pos - 15] == " ")
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
                        if (Main._board[pos - 1] == " ")
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
                        if (Main._board[pos + 1] == " ")
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
                        if (Main._board[pos + 15] == " ")
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
                        if (Main._board[pos + 16] == " ")
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
                        if (Main._board[pos + 17] == " ")
                        {
                            pos += 17;
                            Board.board_panels[pos].BackgroundImage = null;
                        }
                        else break;
                    }

                    Board.board_panels[currentPos].BackgroundImage = Resources.wq;
                    Main._board[prevPos] = " ";
                    Main._board[currentPos] = "Q";
                }
            }
            else
            {
                if (piece == "P")
                {
                    if (Board._startingPos[currentPos] == piece)
                    {
                        isPawnFirstMove = true;
                    }

                    // If first move for pawn, is pawn blocked from moving forward 2? No, allow piece to move forward 2 squares. Yes, Can piece be moved 1 square?
                    Console.WriteLine(Board.isOnBoard(prevPos - 16));
                    if (Main._board[currentPos - 16] == " " && Board.isOnBoard(prevPos - 16))
                    {
                        newPos = currentPos - 16;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        if (isPawnFirstMove && Main._board[currentPos - 32] == " " && Board.isOnBoard(prevPos - 32))
                        {
                            newPos = currentPos - 32;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        }

                    }
                }

                if (piece == "N")
                {
                    // NNE - 2 UP, 1 RIGHT
                    if (Main._board[currentPos - 31] == " ")
                    {
                        newPos = currentPos - 31;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // NNW - 2 UP, 1 LEFT
                    if (Main._board[currentPos - 33] == " ")
                    {
                        newPos = currentPos - 33;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // EEN - 2 RIGHT, 1 UP
                    if (Main._board[currentPos - 14] == " ")
                    {
                        newPos = currentPos - 14;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // EES - 2 RIGHT, 1 DOWN
                    if (Main._board[currentPos + 18] == " ")
                    {
                        newPos = currentPos + 18;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // SSE - 2 DOWN, 1 RIGHT
                    if (Main._board[currentPos + 31] == " ")
                    {
                        newPos = currentPos + 31;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // SSW - 2 DOWN, 1 LEFT
                    if (Main._board[currentPos + 33] == " ")
                    {
                        newPos = currentPos + 33;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // WWN - 2 LEFT, 1 UP
                    if (Main._board[currentPos - 18] == " ")
                    {
                        newPos = currentPos - 18;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }

                    // WWS - 2 LEFT, 1 DOWN 
                    if (Main._board[currentPos + 14] == " ")
                    {
                        newPos = currentPos + 14;
                        Board.board_panels[newPos].BackgroundImage = Resources.legal;
                        Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                        Main.legal_board[newPos] = "legal";
                    }
                }

                if (piece == "K")
                {
                    // NW
                    try
                    {
                        if (Main._board[currentPos - 17] == " ")
                        {
                            newPos = currentPos - 17;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                    // N
                    try
                    {
                        if (Main._board[currentPos - 16] == " ")
                        {
                            newPos = currentPos - 16;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    // NE
                    try
                    {
                        if (Main._board[currentPos - 15] == " ")
                        {
                            newPos = currentPos - 15;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }

                    // W
                    try
                    {
                        if (Main._board[currentPos - 1] == " ")
                        {
                            newPos = currentPos - 1;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    // E
                    try
                    {
                        if (Main._board[currentPos + 1] == " ")
                        {
                            newPos = currentPos + 1;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    // SW
                    try
                    {
                        if (Main._board[currentPos + 17] == " ")
                        {
                            newPos = currentPos + 17;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    // S
                    try
                    {
                        if (Main._board[currentPos + 16] == " ")
                        {
                            newPos = currentPos + 16;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
                        }
                    }
                    catch (IndexOutOfRangeException ex) { Console.WriteLine(ex); }
                    
                    // SE
                    try
                    {
                        if (Main._board[currentPos + 15] == " ")
                        {
                            newPos = currentPos + 15;
                            Board.board_panels[newPos].BackgroundImage = Resources.legal;
                            Board.board_panels[newPos].BackgroundImage.Tag = "legal";
                            Main.legal_board[newPos] = "legal";
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
                        if (Main._board[pos - 15] == " ")
                        {
                            pos -= 15;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // NW
                    pos = currentPos;
                    while (Board.isOnBoard(pos - 17))
                    {
                        if (Main._board[pos - 17] == " ")
                        {
                            pos -= 17;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // SE
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 17))
                    {
                        if (Main._board[pos + 17] == " ")
                        {
                            pos += 17;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // SW
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 15))
                    {
                        if (Main._board[pos + 15] == " ")
                        {
                            pos += 15;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
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
                        if (Main._board[pos - 16] == " ")
                        {
                            pos -= 16;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // E
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 1))
                    {
                        if (Main._board[pos + 1] == " ")
                        {
                            pos += 1;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // S
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 16))
                    {
                        if (Main._board[pos + 16] == " ")
                        {
                            pos += 16;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // W
                    pos = currentPos;
                    while (Board.isOnBoard(pos - 1))
                    {
                        if (Main._board[pos - 1] == " ")
                        {
                            pos -= 1;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
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
                        if (Main._board[pos - 17] == " ")
                        {
                            pos -= 17;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // N
                    pos = currentPos;
                    while (Board.isOnBoard(pos - 16))
                    {
                        if (Main._board[pos - 16] == " ")
                        {
                            pos -= 16;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // NE
                    pos = currentPos;
                    while (Board.isOnBoard(pos - 15))
                    {
                        if (Main._board[pos - 15] == " ")
                        {
                            pos -= 15;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // W
                    pos = currentPos;
                    while (Board.isOnBoard(pos - 1))
                    {
                        if (Main._board[pos - 1] == " ")
                        {
                            pos -= 1;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // E
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 1))
                    {
                        if (Main._board[pos + 1] == " ")
                        {
                            pos += 1;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // SW
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 15))
                    {
                        if (Main._board[pos + 15] == " ")
                        {
                            pos += 15;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // S
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 16))
                    {
                        if (Main._board[pos + 16] == " ")
                        {
                            pos += 16;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }

                    // SE
                    pos = currentPos;
                    while (Board.isOnBoard(pos + 17))
                    {
                        if (Main._board[pos + 17] == " ")
                        {
                            pos += 17;
                            Board.board_panels[pos].BackgroundImage = Resources.legal;
                            Board.board_panels[pos].BackgroundImage.Tag = "legal";
                            Main.legal_board[pos] = "legal";
                        }
                        else break;
                    }
                }
            }
        }
    }
}