using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyChessPuzzle
{
    internal class ReadFEN
    {

        string rank1, rank2, rank3, rank4, rank5, rank6, rank7, rank8, sideToMove, castlingAbility, enPassantAbility;
        int halfmoveClock, fullmoveCounter;
        public ReadFEN(string[] fenSection)
        {
            rank8 = fenSection[0];
            rank7 = fenSection[1];
            rank6 = fenSection[2];
            rank5 = fenSection[3];
            rank4 = fenSection[4];
            rank3 = fenSection[5];
            rank2 = fenSection[6];
            rank1 = fenSection[7];

            sideToMove = fenSection[8];
            castlingAbility = fenSection[9];
            enPassantAbility = fenSection[10]; 
            halfmoveClock = Convert.ToInt32(fenSection[11]);
            fullmoveCounter = Convert.ToInt32(fenSection[12]);
        }

        public string Rank8 { get { return rank8; } }
        public string Rank7 { get { return rank7; } }
        public string Rank6 { get { return rank6; } }
        public string Rank5 { get { return rank5; } }
        public string Rank4 { get { return rank4; } }
        public string Rank3 { get { return rank3; } }
        public string Rank2 { get { return rank2; } }
        public string Rank1 { get { return rank1; } }
    }
}
