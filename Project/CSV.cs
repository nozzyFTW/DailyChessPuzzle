using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DailyChessPuzzle
{
    internal class CSV
    {
        private string fen, moves, rating;
        public CSV(string[] fields)
        {
            fen = fields[1];
            moves = fields[2];
            rating = fields[3];
        }

        public string FEN { get { return fen; } }
        public string Moves { get { return moves; } }
        public string Rating { get { return rating; } }
    }
}
