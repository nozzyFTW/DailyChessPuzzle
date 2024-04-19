using System;
using System.Windows.Forms;

namespace DailyChessPuzzle
{
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();
        }

        private void GameOver_Load(object sender, EventArgs e)
        {
            lblRating.Text = Puzzle.todaysPuzzle.Rating;
            lblMoves.Text = Puzzle.todaysPuzzle.Moves;
        }

        private void GameOver_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main main = new Main();
            main.Close();
            Environment.Exit(0);
        }
    }
}
