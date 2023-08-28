﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using DailyChessPuzzle.Properties;

namespace DailyChessPuzzle
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        // RANK - row, FILE - col
        int RANK_SIZE = 8;
        int FILE_SIZE = 8;

        //string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        //string fen = "rnbqkbnr/ppppp1pp/8/5pN1/8/8/PPPPPPPP/RNBQKB1R b KQkq - 0 1";
        string fen = "q3k1nr/1pp1nQpp/3p4/1P2p3/4P3/B1PP1b2/B5PP/5K2 b k - 0 17";

        string[] board = new string[64]
        {
            "r", "n", "b", "q", "k", "b", "n", "r",
            "p", "p", "p", "p", "p", "p", "p", "p",
            " ", " ", " ", " ", " ", " ", " ", " ",
            " ", " ", " ", " ", " ", " ", " ", " ",
            " ", " ", " ", " ", " ", " ", " ", " ",
            " ", " ", " ", " ", " ", " ", " ", " ",
            "P", "P", "P", "P", "P", "P", "P", "P",
            "R", "N", "B", "Q", "K", "B", "N", "R",
        };

       /*string[] piece_board = new string[128]
        {
            "r", "n", "b", "q", "k", "b", "n", "r", "x", "x", "x", "x", "x", "x", "x", "x",
            "p", "p", "p", "p", "p", "p", "p", "p", "x", "x", "x", "x", "x", "x", "x", "x",
            " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
            " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
            " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
            " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
            "P", "P", "P", "P", "P", "P", "P", "P", "x", "x", "x", "x", "x", "x", "x", "x",
            "R", "N", "B", "Q", "K", "B", "N", "R", "x", "x", "x", "x", "x", "x", "x", "x"
        };*/

        public static Panel[] board_panels = new Panel[64];
      /*{
            "A8", "B8", "C8", "D8", "E8", "F8", "G8", "H8",
            "A7", "B7", "C7", "D7", "E7", "F7", "G7", "H7",
            "A6", "B6", "C6", "D6", "E6", "F6", "G6", "H6",
            "A5", "B5", "C5", "D5", "E5", "F5", "G5", "H5",
            "A4", "B4", "C4", "D4", "E4", "F4", "G4", "H4",
            "A3", "B3", "C3", "D3", "E3", "F3", "G3", "H3",
            "A2", "B2", "C2", "D2", "E2", "F2", "G2", "H2",
            "A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1"
        };*/

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateBoard();
            ReadFEN();
        }

        private void GenerateBoard()
        {
            int count = 0;
            for (int rank = 0; rank < RANK_SIZE; rank++)
            {
                for (int file = 0; file < FILE_SIZE; file++)
                {
                    Panel square = new Panel();
                    //Label label = new Label();
                    switch (rank)
                    {
                        case 0:
                            square.Name = $"h{file + 1}";
                            // label.Text = square.Name;

                            square.Width = 75;
                            square.Height = 75;

                            if (file != 0)
                            {
                                square.Top = 0;
                                square.Left = 75 * file;
                            }
                            else
                            {
                                square.Top = 0;
                                square.Left = 0;
                            }

                            if ((file % 2) == 0)
                            {
                                square.BackColor = Color.PeachPuff;
                            }
                            else
                            {
                                square.BackColor = Color.SandyBrown;
                            }
                            break;

                        case 1:
                            square.Name = $"g{file + 1}";
                            // label.Text = square.Name;

                            square.Width = 75;
                            square.Height = 75;

                            if (file != 0)
                            {
                                square.Top = 75;
                                square.Left = 75 * file;
                            }
                            else
                            {
                                square.Top = 75;
                                square.Left = 0;
                            }

                            if ((file % 2) != 0)
                            {
                                square.BackColor = Color.PeachPuff;
                            }
                            else
                            {
                                square.BackColor = Color.SandyBrown;
                            }
                            break;

                        case 2:
                            square.Name = $"f{file + 1}";
                            // label.Text = square.Name;

                            square.Width = 75;
                            square.Height = 75;

                            if (file != 0)
                            {
                                square.Top = 150;
                                square.Left = 75 * file;
                            }
                            else
                            {
                                square.Top = 150;
                                square.Left = 0;
                            }

                            if ((file % 2) == 0)
                            {
                                square.BackColor = Color.PeachPuff;
                            }
                            else
                            {
                                square.BackColor = Color.SandyBrown;
                            }
                            break;

                        case 3:
                            square.Name = $"e{file + 1}";
                            // label.Text = square.Name;

                            square.Width = 75;
                            square.Height = 75;

                            if (file != 0)
                            {
                                square.Top = 225;
                                square.Left = 75 * file;
                            }
                            else
                            {
                                square.Top = 225;
                                square.Left = 0;
                            }

                            if ((file % 2) != 0)
                            {
                                square.BackColor = Color.PeachPuff;
                            }
                            else
                            {
                                square.BackColor = Color.SandyBrown;
                            }
                            break;

                        case 4:
                            square.Name = $"d{file + 1}";
                            // label.Text = square.Name;

                            square.Width = 75;
                            square.Height = 75;

                            if (file != 0)
                            {
                                square.Top = 300;
                                square.Left = 75 * file;
                            }
                            else
                            {
                                square.Top = 300;
                                square.Left = 0;
                            }

                            if ((file % 2) == 0)
                            {
                                square.BackColor = Color.PeachPuff;
                            }
                            else
                            {
                                square.BackColor = Color.SandyBrown;
                            }
                            break;

                        case 5:
                            square.Name = $"c{file + 1}";
                            // label.Text = square.Name;

                            square.Width = 75;
                            square.Height = 75;

                            if (file != 0)
                            {
                                square.Top = 375;
                                square.Left = 75 * file;
                            }
                            else
                            {
                                square.Top = 375;
                                square.Left = 0;
                            }

                            if ((file % 2) != 0)
                            {
                                square.BackColor = Color.PeachPuff;
                            }
                            else
                            {
                                square.BackColor = Color.SandyBrown;
                            }
                            break;

                        case 6:
                            square.Name = $"b{file + 1}";
                            // label.Text = square.Name;

                            square.Width = 75;
                            square.Height = 75;

                            if (file != 0)
                            {
                                square.Top = 450;
                                square.Left = 75 * file;
                            }
                            else
                            {
                                square.Top = 450;
                                square.Left = 0;
                            }

                            if ((file % 2) == 0)
                            {
                                square.BackColor = Color.PeachPuff;
                            }
                            else
                            {
                                square.BackColor = Color.SandyBrown;
                            }
                            break;

                        case 7:
                            square.Name = $"a{file + 1}";
                            // label.Text = square.Name;

                            square.Width = 75;
                            square.Height = 75;

                            if (file != 0)
                            {
                                square.Top = 525;
                                square.Left = 75 * file;
                            }
                            else
                            {
                                square.Top = 525;
                                square.Left = 0;
                            }

                            if ((file % 2) != 0)
                            {
                                square.BackColor = Color.PeachPuff;
                            }
                            else
                            {
                                square.BackColor = Color.SandyBrown;
                            }
                            break;
                    }

                    board_panels[count] = square;
                    count++;
                    pnlBoard.Controls.Add(square);
                    //square.Controls.Add(label);
                }
            }
        }

        private void ReadFEN()
        {
            // FEN = <Piece Placement> <Side to Move> <Castling Ability> <En Passsant Target Square> <Halfmove Clock> <Fullmove Counter>
            string[] fenSections = fen.Split('/', ' ');
            ReadFEN readFEN = new ReadFEN(fenSections);

            int count = 8;
            List<string> fenRank = new List<string>();

            while (count > 0)
            {
                fenRank.Clear();
                switch (count)
                {
                    
                    case 8:
                        fenRank = readFEN.Rank8.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 7:
                        fenRank = readFEN.Rank7.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 6:
                        fenRank = readFEN.Rank6.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 5:
                        fenRank = readFEN.Rank5.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 4:
                        fenRank = readFEN.Rank4.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 3:
                        fenRank = readFEN.Rank3.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 2:
                        fenRank = readFEN.Rank2.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 1:
                        fenRank = readFEN.Rank1.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;
                }
                count--;
            }
        }

        private void GeneratePieces(List<string> section, int rankNum)
        {
            int pos = 0;

            // Effective - Replaces 8 ifs
            int[] posArr = new int[9] { 0, 56, 48, 40, 32, 24, 16, 8, 0 };
            pos = posArr[rankNum];

            foreach (string item in section)
            {
                // As the pieces are determined Black (lowercase) and White (uppercase) Char.IsUpper() can be used to determine which type piece is being added.
                bool isWhitePiece = (Char.IsUpper(item, 0));
                bool isBlackPiece = !(Char.IsUpper(item, 0));
                bool isBlankSquare = (Char.IsNumber(item, 0));

                board_panels[pos].BackgroundImageLayout = ImageLayout.Zoom;
    
                if (isBlankSquare)
                {
                    pos += Convert.ToInt32(item);
                    continue;
                }

                if (isWhitePiece)
                {
                    if (item == "P") board_panels[pos].BackgroundImage = Resources.wp;     // White Pawn
                    if (item == "R") board_panels[pos].BackgroundImage = Resources.wr;     // White Rook
                    if (item == "N") board_panels[pos].BackgroundImage = Resources.wn;     // White Knight
                    if (item == "B") board_panels[pos].BackgroundImage = Resources.wb;     // White Bishop
                    if (item == "Q") board_panels[pos].BackgroundImage = Resources.wq;     // White Queen
                    if (item == "K") board_panels[pos].BackgroundImage = Resources.wk;     // White King
                }
                if (isBlackPiece)
                {
                    if (item == "p") board_panels[pos].BackgroundImage = Resources.bp;     // Black Pawn
                    if (item == "r") board_panels[pos].BackgroundImage = Resources.br;     // Black Rook
                    if (item == "n") board_panels[pos].BackgroundImage = Resources.bn;     // Black Knight
                    if (item == "b") board_panels[pos].BackgroundImage = Resources.bb;     // Black Bishop
                    if (item == "q") board_panels[pos].BackgroundImage = Resources.bq;     // Black Queen
                    if (item == "k") board_panels[pos].BackgroundImage = Resources.bk;     // Black King
                }
                pos++;
            }
        }

        private void GenerateMoves()
        {
            // Pawn


            // Rook


            // Knight


            // Bishop


            // Queen


            // King
        }
    }
}
