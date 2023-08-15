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

        string[,] board = new string[8, 8];

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

                            square.Width = 120;
                            square.Height = 120;

                            if (file != 0)
                            {
                                square.Top = 0;
                                square.Left = 120 * file;
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

                            square.Width = 120;
                            square.Height = 120;

                            if (file != 0)
                            {
                                square.Top = 120;
                                square.Left = 120 * file;
                            }
                            else
                            {
                                square.Top = 120;
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

                            square.Width = 120;
                            square.Height = 120;

                            if (file != 0)
                            {
                                square.Top = 240;
                                square.Left = 120 * file;
                            }
                            else
                            {
                                square.Top = 240;
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

                            square.Width = 120;
                            square.Height = 120;

                            if (file != 0)
                            {
                                square.Top = 360;
                                square.Left = 120 * file;
                            }
                            else
                            {
                                square.Top = 360;
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

                            square.Width = 120;
                            square.Height = 120;

                            if (file != 0)
                            {
                                square.Top = 480;
                                square.Left = 120 * file;
                            }
                            else
                            {
                                square.Top = 480;
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

                            square.Width = 120;
                            square.Height = 120;

                            if (file != 0)
                            {
                                square.Top = 600;
                                square.Left = 120 * file;
                            }
                            else
                            {
                                square.Top = 600;
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

                            square.Width = 120;
                            square.Height = 120;

                            if (file != 0)
                            {
                                square.Top = 720;
                                square.Left = 120 * file;
                            }
                            else
                            {
                                square.Top = 720;
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

                            square.Width = 120;
                            square.Height = 120;

                            if (file != 0)
                            {
                                square.Top = 840;
                                square.Left = 120 * file;
                            }
                            else
                            {
                                square.Top = 840;
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
            
        }
    }
}
