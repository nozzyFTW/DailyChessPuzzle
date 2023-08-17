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

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateBoard();
            GeneratePieces();
        }

        private void GenerateBoard()
        {
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
                    square.Controls.Add(label);
                    pnlBoard.Controls.Add(square);
                    
                }
            }
        }

        private void GeneratePieces()
        {
            // ReadFEN();


        }

        private void ReadFEN()
        {
            
        }
    }
}
