using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //lblTimeTill.Text = TimeSpan.Parse(ts.ToString("hh:mm:ss")).ToString();
            //lblTimeTill.Text = TimeSpan.ParseExact(s, @"d\.hh\:mm\:ss", CultureInfo.InvariantCulture).ToString();
            //lblTimeTill.Text = $"{ts.Hours}:{ts.Minutes}:{ts.Seconds}";
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Today.AddDays(1) - DateTime.Now;
            lblTimeTill.Text = ts.ToString(@"hh\:mm\:ss");
            //lblTimeTill.Text = $"{ts.Hours}:{ts.Minutes}:{ts.Seconds}";
        }
    }
}