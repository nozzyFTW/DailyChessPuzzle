using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace DailyChessPuzzle
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void TeamSelect_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatStyle = FlatStyle.Flat;
        }

        private void TeamSelect_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatStyle = FlatStyle.Standard;
        }

        private void TeamSelect_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatStyle = FlatStyle.Flat;
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (radEasy.Checked)
            {
                Puzzle.difficulty = 0;
                SQL.Difficulty = 0;
            }
            if (radIntermediate.Checked)
            {
                Puzzle.difficulty = 1;
                SQL.Difficulty = 1;
            }
            if (radHard.Checked)
            {
                Puzzle.difficulty = 2;
                SQL.Difficulty = 2;
            }

            Environment.Exit(0);
        }
    }
}
