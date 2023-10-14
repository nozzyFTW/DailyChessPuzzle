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
        string selectedTeam = String.Empty;
        bool firstClick = true;
        public Welcome()
        {
            InitializeComponent();
        }

        private void TeamSelect_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (selectedTeam == String.Empty)
            btn.FlatStyle = FlatStyle.Flat;
        }

        private void TeamSelect_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name != $"btn{selectedTeam}") btn.FlatStyle = FlatStyle.Standard;
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

            SQL.HouseTeam = selectedTeam;
            Close();
        }

        private void TeamSelect_Click(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;

            if (firstClick)
            {
                btn.FlatStyle = FlatStyle.Flat;
                firstClick = false;
                if (btn.Name == "btnKepler") selectedTeam = "Kepler";
                if (btn.Name == "btnNewton") selectedTeam = "Newton";
                if (btn.Name == "btnKelvin") selectedTeam = "Kelvin";
                if (btn.Name == "btnFaraday") selectedTeam = "Faraday";
            }
            else
            {
                btn.FlatStyle = FlatStyle.Standard;
                firstClick = true;
                selectedTeam = String.Empty;
            }
        }
    }
}
