using System;
using System.Windows.Forms;

namespace DailyChessPuzzle
{
    public partial class PlayAgain : Form
    {
        public PlayAgain()
        {
            InitializeComponent();
        }

        private void PlayAgain_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 500;
            t.Tick += new EventHandler(t_Tick);
            TimeSpan ts = DateTime.Today.AddDays(1) - DateTime.Now;
            string s = ts.ToString();
            lblTimeTill.Text = ts.ToString(@"hh\:mm\:ss");
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Today.AddDays(1) - DateTime.Now;
            lblTimeTill.Text = ts.ToString(@"hh\:mm\:ss");
        }

        private void PlayAgain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main main = new Main();
            main.Close();
            Environment.Exit(0);
        }
    }
}