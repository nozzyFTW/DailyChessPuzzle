using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyChessPuzzle
{
    internal class Puzzle
    {
        public static string fen = "r6r/p2b1pp1/3k4/2bp4/2P5/6q1/P2Q3P/1R2R2K w - - 2 28";
        public static string moves = "d2d5 d6c7 b1b7 c7c8 d5d7";

        public static void ReadFEN()
        {
            string Rank1, Rank2, Rank3, Rank4, Rank5, Rank6, Rank7, Rank8, sideToMove, castlingAbility, enPassantAbility;
            int halfmoveClock, fullmoveCounter;

            // FEN = <Piece Placement> <Side to Move> <Castling Ability> <En Passsant Target Square> <Halfmove Clock> <Fullmove Counter>
            string[] fenSections = fen.Split('/', ' ');

            Rank8 = fenSections[0];
            Rank7 = fenSections[1];
            Rank6 = fenSections[2];
            Rank5 = fenSections[3];
            Rank4 = fenSections[4];
            Rank3 = fenSections[5];
            Rank2 = fenSections[6];
            Rank1 = fenSections[7];

            sideToMove = fenSections[8];
            castlingAbility = fenSections[9];
            enPassantAbility = fenSections[10];
            halfmoveClock = Convert.ToInt32(fenSections[11]);
            fullmoveCounter = Convert.ToInt32(fenSections[12]);

            int count = 8;
            List<string> fenRank = new List<string>();

            while (count > 0)
            {
                fenRank.Clear();
                switch (count)
                {

                    case 8:
                        fenRank = Rank8.ToCharArray().Select(x => x.ToString()).ToList();
                        Piece.Generate(fenRank, count);

                        break;

                    case 7:
                        fenRank = Rank7.ToCharArray().Select(x => x.ToString()).ToList();
                        Piece.Generate(fenRank, count);

                        break;

                    case 6:
                        fenRank = Rank6.ToCharArray().Select(x => x.ToString()).ToList();
                        Piece.Generate(fenRank, count);

                        break;

                    case 5:
                        fenRank = Rank5.ToCharArray().Select(x => x.ToString()).ToList();
                        Piece.Generate(fenRank, count);

                        break;

                    case 4:
                        fenRank = Rank4.ToCharArray().Select(x => x.ToString()).ToList();
                        Piece.Generate(fenRank, count);

                        break;

                    case 3:
                        fenRank = Rank3.ToCharArray().Select(x => x.ToString()).ToList();
                        Piece.Generate(fenRank, count);

                        break;

                    case 2:
                        fenRank = Rank2.ToCharArray().Select(x => x.ToString()).ToList();
                        Piece.Generate(fenRank, count);

                        break;

                    case 1:
                        fenRank = Rank1.ToCharArray().Select(x => x.ToString()).ToList();
                        Piece.Generate(fenRank, count);

                        break;
                }
                count--;
            }
        }
    }
}
