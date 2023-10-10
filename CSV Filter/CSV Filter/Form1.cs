using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_Filter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> EasyList = new List<string>();
        List<string> InterList = new List<string>();
        List<string> HardList = new List<string>();

        private void Read(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(@"../../../CSVs/lichess_db_puzzle.csv"))
            {
                string line;
                string[] lineArr;

                while ((line = sr.ReadLine()) != null)
                {
                    lineArr = line.Split(',');

                    if (lineArr[1].Contains("b"))
                    {
                        if (lineArr[7].Contains("mate"))
                        {
                            if (Convert.ToInt32(lineArr[3]) >= 2000)
                            {
                                HardList.Add(line);
                            }
                            else if (Convert.ToInt32(lineArr[3]) >= 1400)
                            {
                                InterList.Add(line);
                            }
                            else
                            {
                                EasyList.Add(line);
                            }
                        }
                    }
                }
            }
            Write();
        }

        private void Write()
        {
            using (StreamWriter sw = new StreamWriter("easy.csv"))
            {
                foreach (string line in EasyList)
                {
                    sw.WriteLine(line);
                }
            }

            using (StreamWriter sw = new StreamWriter("intermediate.csv"))
            {
                foreach (string line in InterList)
                {
                    sw.WriteLine(line);
                }
            }

            using (StreamWriter sw = new StreamWriter("hard.csv"))
            {
                foreach (string line in HardList)
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
}
