using System;
using System.Windows.Forms;

namespace DailyChessPuzzle
{
    public partial class Instructions : Form
    {
        public Instructions()
        {
            InitializeComponent();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
