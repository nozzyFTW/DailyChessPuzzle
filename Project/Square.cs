using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyChessPuzzle
{
    internal class Square
    {
        public const int width = 75;
        public const int height = 75;
        public Square(int rank, int file)
        {
            RankNum = rank;
            FileNum = file;
        }

        public static int Width { get; set; }
        public static int Height { get; set; }
        public int RankNum { get; set; }
        public int FileNum { get; set; }
        public bool isOccupied { get; set; }
        public bool isLegalNextMove { get; set; }
    }
}
