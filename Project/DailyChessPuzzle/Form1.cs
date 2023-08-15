using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyChessPuzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // RANK - row, FILE - col
        int MAX_RANK_SIZE = 8;
        int MAX_FILE_SIZE = 8;

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateBoard();
        }

        private void GenerateBoard()
        {
            for (int rank = 0; rank < MAX_RANK_SIZE; rank++)
            {
                for (int file = 0; file < MAX_FILE_SIZE; file++)
                {
                    Panel square = new Panel();
                    switch (rank)
                    {
                        case 0:
                            square.Name = $"a{file}";
                            square.Width = 128;
                            square.Height = 128;

                            if (file != 0)
                            {
                                square.Top = 0;
                                square.Left = 128 * file;
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
                            square.Name = $"b{file}";
                            square.Width = 128;
                            square.Height = 128;

                            if (file != 0)
                            {
                                square.Top = 128;
                                square.Left = 128 * file;
                            }
                            else
                            {
                                square.Top = 128;
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
                            square.Name = $"c{file}";
                            square.Width = 128;
                            square.Height = 128;

                            if (file != 0)
                            {
                                square.Top = 256;
                                square.Left = 128 * file;
                            }
                            else
                            {
                                square.Top = 256;
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
                            square.Name = $"d{file}";
                            square.Width = 128;
                            square.Height = 128;

                            if (file != 0)
                            {
                                square.Top = 384;
                                square.Left = 128 * file;
                            }
                            else
                            {
                                square.Top = 384;
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
                            square.Name = $"e{file}";
                            square.Width = 128;
                            square.Height = 128;

                            if (file != 0)
                            {
                                square.Top = 512;
                                square.Left = 128 * file;
                            }
                            else
                            {
                                square.Top = 512;
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
                            square.Name = $"f{file}";
                            square.Width = 128;
                            square.Height = 128;

                            if (file != 0)
                            {
                                square.Top = 640;
                                square.Left = 128 * file;
                            }
                            else
                            {
                                square.Top = 640;
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
                            square.Name = $"g{file}";
                            square.Width = 128;
                            square.Height = 128;

                            if (file != 0)
                            {
                                square.Top = 768;
                                square.Left = 128 * file;
                            }
                            else
                            {
                                square.Top = 768;
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
                            square.Name = $"h{file}";
                            square.Width = 128;
                            square.Height = 128;

                            if (file != 0)
                            {
                                square.Top = 896;
                                square.Left = 128 * file;
                            }
                            else
                            {
                                square.Top = 896;
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
                    pnlBoard.Controls.Add(square);
                }
            }
        }
    }
}
