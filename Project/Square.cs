using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyChessPuzzle
{
    internal class Square
    {
        public Square(int rank, int file)
        {
            RankNum = rank;
            FileNum = file;
        }

        public int RankNum { get; set; }
        public int FileNum { get; set; }
        public bool isOccupied { get; set; }
        public bool isLegalNextMove { get; set; }
    }
}
