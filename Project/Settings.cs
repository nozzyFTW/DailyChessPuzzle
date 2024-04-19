using System;
using System.Windows.Forms;

namespace DailyChessPuzzle
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            if (control.Name == "radEasy")
            {
                if (radEasy.Checked)
                {
                    radIntermediate.Checked = false;
                    radHard.Checked = false;
                }
            }
            if (control.Name == "radIntermediate")
            {
                if (radIntermediate.Checked)
                {
                    radEasy.Checked = false;
                    radHard.Checked = false;
                }
            }
            if (control.Name == "radHard")
            {
                if (radHard.Checked)
                {
                    radEasy.Checked = false;
                    radIntermediate.Checked = false;
                }
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            if (radEasy.Checked)
            {
                Puzzle.difficulty = 0;
                SQL.Difficulty = 0;
                Puzzle.isNewPuzzle = true;
                Puzzle.moveCount = 0;
                Puzzle update = new Puzzle(Main.lblTask);
                Main.ComputerMove(Puzzle.moveArr[Puzzle.moveCount]);
            }
            
            if (radIntermediate.Checked)
            {
                Puzzle.difficulty = 1;
                SQL.Difficulty = 1;
                Puzzle.isNewPuzzle = true;
                Puzzle.moveCount = 0;
                Puzzle update = new Puzzle(Main.lblTask);
                Main.ComputerMove(Puzzle.moveArr[Puzzle.moveCount]);
            }
            
            if (radHard.Checked)
            {
                Puzzle.difficulty = 2;
                SQL.Difficulty = 2;
                Puzzle.isNewPuzzle = true;
                Puzzle.moveCount = 0;
                Puzzle update = new Puzzle(Main.lblTask);
                Main.ComputerMove(Puzzle.moveArr[Puzzle.moveCount]);
            }

            SQL.UpdateDifficultySetting();
            this.Close();
        }
    }
}
