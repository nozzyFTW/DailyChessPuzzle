using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using DailyChessPuzzle.Properties;
using Svg;

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

        string[] board = new string[64]
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

        /*string[] board_coords = new string[64]
        {
            "A8", "B8", "C8", "D8", "E8", "F8", "G8", "H8",
            "A7", "B7", "C7", "D7", "E7", "F7", "G7", "H7",
            "A6", "B6", "C6", "D6", "E6", "F6", "G6", "H6",
            "A5", "B5", "C5", "D5", "E5", "F5", "G5", "H5",
            "A4", "B4", "C4", "D4", "E4", "F4", "G4", "H4",
            "A3", "B3", "C3", "D3", "E3", "F3", "G3", "H3",
            "A2", "B2", "C2", "D2", "E2", "F2", "G2", "H2",
            "A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1"
        };*/

        Panel[] board_panels = new Panel[64];

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateBoard();
            GeneratePieces();
        }

        private void GenerateBoard()
        {
            int count = 0;
            for (int rank = 0; rank < RANK_SIZE; rank++)
            {
                for (int file = 0; file < FILE_SIZE; file++)
                {
                    Panel square = new Panel();
                    Label label = new Label();
                    switch (rank)
                    {
                        case 0:
                            square.Name = $"h{file + 1}";
                            label.Text = square.Name;

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
                            label.Text = square.Name;

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
                            label.Text = square.Name;

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
                            label.Text = square.Name;

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
                            label.Text = square.Name;

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
                            label.Text = square.Name;

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
                            label.Text = square.Name;

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
                            label.Text = square.Name;

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
                    square.Controls.Add(label);
                }
            }
        }

        private void GeneratePieces()
        {
            // ReadFEN();

            foreach (var square in board_panels)
            {
                int index = Array.IndexOf(board_panels, square);

                bool isWhite = (Char.IsUpper(board[index], 0));
                bool isBlack = !(Char.IsUpper(board[index], 0));

                if (isWhite)
                {
                    if (board[index] == "P") square.BackgroundImage = Resources.wp;     // White Pawn
                    if (board[index] == "R") square.BackgroundImage = Resources.wr;     // White Rook
                    if (board[index] == "N") square.BackgroundImage = Resources.wn;     // White Knight
                    if (board[index] == "B") square.BackgroundImage = Resources.wb;     // White Bishop
                    if (board[index] == "Q") square.BackgroundImage = Resources.wq;     // White Queen
                    if (board[index] == "K") square.BackgroundImage = Resources.wk;     // White King
                }
                if (isBlack)
                {
                    if (board[index] == "p") square.BackgroundImage = Resources.bp;     // Black Pawn
                    if (board[index] == "r") square.BackgroundImage = Resources.br;     // Black Rook
                    if (board[index] == "n") square.BackgroundImage = Resources.bn;     // Black Knight
                    if (board[index] == "b") square.BackgroundImage = Resources.bb;     // Black Bishop
                    if (board[index] == "q") square.BackgroundImage = Resources.bq;     // Black Queen
                    if (board[index] == "k") square.BackgroundImage = Resources.bk;     // Black King
                }

                
                pnlBoard.Controls.Add(square);
            }
        }

        private void ReadFEN()
        {
            
        }
    }
}
