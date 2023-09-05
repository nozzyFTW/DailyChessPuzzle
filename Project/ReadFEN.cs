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

        string Rank1, Rank2, Rank3, Rank4, Rank5, Rank6, Rank7, Rank8, sideToMove, castlingAbility, enPassantAbility;
        int halfmoveClock, fullmoveCounter;
        public ReadFEN(string[] fenSection)
        {
            Rank8 = fenSection[0];
            Rank7 = fenSection[1];
            Rank6 = fenSection[2];
            Rank5 = fenSection[3];
            Rank4 = fenSection[4];
            Rank3 = fenSection[5];
            Rank2 = fenSection[6];
            Rank1 = fenSection[7];

            sideToMove = fenSection[8];
            castlingAbility = fenSection[9];
            enPassantAbility = fenSection[10]; 
            halfmoveClock = Convert.ToInt32(fenSection[11]);
            fullmoveCounter = Convert.ToInt32(fenSection[12]);
        }

        public void Read()
        {
            // FEN = <Piece Placement> <Side to Move> <Castling Ability> <En Passsant Target Square> <Halfmove Clock> <Fullmove Counter>
            string[] fenSections = Main.fen.Split('/', ' ');
            ReadFEN readFEN = new ReadFEN(fenSections);

            int count = 8;
            List<string> fenRank = new List<string>();

            while (count > 0)
            {
                fenRank.Clear();
                switch (count)
                {

                    case 8:
                        fenRank = readFEN.Rank8.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 7:
                        fenRank = readFEN.Rank7.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 6:
                        fenRank = readFEN.Rank6.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 5:
                        fenRank = readFEN.Rank5.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 4:
                        fenRank = readFEN.Rank4.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 3:
                        fenRank = readFEN.Rank3.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 2:
                        fenRank = readFEN.Rank2.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;

                    case 1:
                        fenRank = readFEN.Rank1.ToCharArray().Select(x => x.ToString()).ToList();
                        GeneratePieces(fenRank, count);

                        break;
                }
                count--;
            }
        }
    }
}
