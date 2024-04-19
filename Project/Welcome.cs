using System;
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
            // IF mouse enters the button, then FlatStyle is set to "flat" since FlatAppearance has
            // been manually altered for each button to contain an outline in the team's colour
            // ssupon hover.

            Button btn = (Button)sender;
            if (selectedTeam == String.Empty) btn.FlatStyle = FlatStyle.Flat;
        }

        private void TeamSelect_MouseLeave(object sender, EventArgs e)
        {
            // IF mouse leaves the button and button hasn't been clicked / team selected, then
            // FlatStyle will be changed to "standard", removing the outline of the button

            Button btn = (Button)sender;
            if (btn.Name != $"btn{selectedTeam}") btn.FlatStyle = FlatStyle.Standard;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            // Deselects other radio buttons upon selection of radio button.

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
            // IF House Team has not been selected display MessageBox telling user to select
            // House Team. IF House Team has been selected check dificulty selected and set
            // the difficulty of the puzzle.

            if (selectedTeam == String.Empty)
            {
                MessageBox.Show("A House Team must be selected.");
            }
            else
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
        }

        private void TeamSelect_Click(object sender, MouseEventArgs e)
        {
            // IF the button has not been selected yet (firstClick) then the button is outlined
            // using FlatStyle.Flat to create an outline on the button and preventing any outline
            // on other buttons. If any button is selected upon "secondClick" (!firstClick) then
            // button and team selection is reset.

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
