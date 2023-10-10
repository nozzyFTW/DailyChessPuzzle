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
                Puzzle.isNewPuzzle = true;
                Puzzle.moveCount = 0;
                Puzzle.ReadCSV();
                Puzzle.ReadFEN();
                Main.ComputerMove(Puzzle.moveArr[Puzzle.moveCount]);
            }
            
            if (radIntermediate.Checked)
            {
                Puzzle.difficulty = 1;
                Puzzle.isNewPuzzle = true;
                Puzzle.moveCount = 0;
                Puzzle.ReadCSV();
                Puzzle.ReadFEN();
                Main.ComputerMove(Puzzle.moveArr[Puzzle.moveCount]);
            }
            
            if (radHard.Checked)
            {
                Puzzle.difficulty = 2;
                Puzzle.isNewPuzzle = true;
                Puzzle.moveCount = 0;
                Puzzle.ReadCSV();
                Puzzle.ReadFEN();
                Main.ComputerMove(Puzzle.moveArr[Puzzle.moveCount]);
            }
        }
    }
}
