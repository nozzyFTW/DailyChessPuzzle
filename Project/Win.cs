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
    public partial class Win : Form
    {
        public Win()
        {
            InitializeComponent();
        }

        private void Win_Load(object sender, EventArgs e)
        {
            lblRating.Text = Puzzle.todaysPuzzle.Rating;
        }

        private void Win_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main main = new Main();
            main.Close();
            Environment.Exit(0);
        }
    }
}
