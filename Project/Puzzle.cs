using DailyChessPuzzle.Properties;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;

namespace DailyChessPuzzle
{
    internal class Puzzle
    {
        //public static string fen = "r6r/p2b1pp1/3k4/2bp4/2P5/6q1/P2Q3P/1R2R2K w - - 2 28";
        //public static string moves = "d2d5 d6c7 b1b7 c7c8 d5d7";
        //public static string fen = "4r1k1/5ppp/r1p5/p1n1RP2/8/2P2N1P/2P3P1/3R2K1 b - - 0 21";
        //public static string moves = "e8e5 d1d8 e5e8 d8e8";

        // 0 - EASY, 1 - INTERMEDIATE, 2 - HARD
        public static int difficulty = 0;

        public static string startingSideToMove;
        public static int moveCount = 0;
        public static string[] moveArr;
        public static int strike = 0;
        public static bool isGameOver = false;
        private static bool isWon = false;
        public static bool isFinished = false;
        public static bool isNewPuzzle = false;

        private static List<CSV> easyPuzzleList = new List<CSV>();
        private static List<CSV> intermediatePuzzleList = new List<CSV>();
        private static List<CSV> hardPuzzleList = new List<CSV>();

        public static CSV todaysPuzzle;

        public Puzzle(Label lbl)
        {
            ReadCSV();

            moveArr = todaysPuzzle.Moves.Split(' ');
            ReadFEN();

            if (startingSideToMove.ToUpper() == "W")
            {
                lbl.Text = $"White to Move and Mate in {Math.Round((double) moveArr.Length / 2, MidpointRounding.AwayFromZero)}";
            }
            else lbl.Text = $"Black to Move and Mate in {Math.Round((double)moveArr.Length / 2, MidpointRounding.AwayFromZero)}";

        }

        public static void ReadCSV()
        {
            easyPuzzleList.Clear();
            intermediatePuzzleList.Clear();
            hardPuzzleList.Clear();

            string[] filenameArr = new string[3] {
                @"..\\..\\..\\Assets\\CSV\\Filtered CSVs\\easy.csv",
                @"..\\..\\..\\Assets\\CSV\\Filtered CSVs\\intermediate.csv",
                @"..\\..\\..\\Assets\\CSV\\Filtered CSVs\\hard.csv"
            };
            string[] listArr = new string[3]
            {
                "easyPuzzleList",
                "intermediatePuzzleList",
                "hardPuzzleList"
            };

            for (int i = 0; i < 3; i++)
            {
                using (StreamReader sr = new StreamReader(filenameArr[i]))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        CSV csv = new CSV(fields);
                        
                        if (i == 0) easyPuzzleList.Add(csv);
                        if (i == 1) intermediatePuzzleList.Add(csv);
                        if (i == 2) hardPuzzleList.Add(csv);
                    }
                }
            }
            Day();
        }

        private static void Day()
        {
            DateTime currentDay = DateTime.Now.Date;
            DateTime startDay = new DateTime(2023, 10, 10);

            int dayCount = (int)(currentDay - startDay).TotalDays;

            if (difficulty == 0) todaysPuzzle = easyPuzzleList[dayCount];
            if (difficulty == 1) todaysPuzzle = intermediatePuzzleList[dayCount];
            if (difficulty == 2) todaysPuzzle = hardPuzzleList[dayCount];
        }

        public static void ReadFEN()
        {
            string Rank1, Rank2, Rank3, Rank4, Rank5, Rank6, Rank7, Rank8;

            if (isNewPuzzle)
            {
                Main.board = new string[128]
                {
                " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
                " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
                " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
                " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
                " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
                " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
                " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
                " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x"
                };

                foreach (Panel pnl in Board.board_panels)
                {
                    if (pnl != null)
                    {
                        if (pnl.BackgroundImage != null) pnl.BackgroundImage = null;
                    }
                }
            }

            // FEN = <Piece Placement> <Side to Move> <Castling Ability> <En Passsant Target Square> <Halfmove Clock> <Fullmove Counter>
            string[] fenSections = todaysPuzzle.FEN.Split('/', ' ');

            Rank8 = fenSections[0];
            Rank7 = fenSections[1];
            Rank6 = fenSections[2];
            Rank5 = fenSections[3];
            Rank4 = fenSections[4];
            Rank3 = fenSections[5];
            Rank2 = fenSections[6];
            Rank1 = fenSections[7];

            startingSideToMove = fenSections[8];

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

        public static bool IsMove(string oldSquare, int prevPos, string newSquare, int currentPos, string prevPiece)
        {
            
            string moveMade = (oldSquare + newSquare).ToLower();
            try
            {
                if (moveMade == moveArr[moveCount])
                {
                    moveCount++;
                    Main.ComputerMove(moveArr[moveCount]);
                    return true;
                }
                else
                {
                    Main.Strike();
                    if (isGameOver == false)
                    {
                        if (prevPiece == "P")
                        {
                            Board.board_panels[prevPos].BackgroundImage = Resources.wp;
                            Board.board_panels[prevPos].BackgroundImage.Tag = "P";
                            Board.board_panels[currentPos].BackgroundImage = null;
                            Main.board[currentPos] = " ";
                            Main.board[prevPos] = "P";
                        }
                        if (prevPiece == "N")
                        {
                            Board.board_panels[prevPos].BackgroundImage = Resources.wn;
                            Board.board_panels[prevPos].BackgroundImage.Tag = "N";
                            Board.board_panels[currentPos].BackgroundImage = null;
                            Main.board[currentPos] = " ";
                            Main.board[prevPos] = "N";
                        }
                        if (prevPiece == "B")
                        {
                            Board.board_panels[prevPos].BackgroundImage = Resources.wb;
                            Board.board_panels[prevPos].BackgroundImage.Tag = "B";
                            Board.board_panels[currentPos].BackgroundImage = null;
                            Main.board[currentPos] = " ";
                            Main.board[prevPos] = "B";
                        }
                        if (prevPiece == "R")
                        {
                            Board.board_panels[prevPos].BackgroundImage = Resources.wr;
                            Board.board_panels[prevPos].BackgroundImage.Tag = "R";
                            Board.board_panels[currentPos].BackgroundImage = null;
                            Main.board[currentPos] = " ";
                            Main.board[prevPos] = "R";
                        }
                        if (prevPiece == "Q")
                        {
                            Board.board_panels[prevPos].BackgroundImage = Resources.wq;
                            Board.board_panels[prevPos].BackgroundImage.Tag = "Q";
                            Board.board_panels[currentPos].BackgroundImage = null;
                            Main.board[currentPos] = " ";
                            Main.board[prevPos] = "Q";
                        }
                        if (prevPiece == "K")
                        {
                            Board.board_panels[prevPos].BackgroundImage = Resources.wk;
                            Board.board_panels[prevPos].BackgroundImage.Tag = "K";
                            Board.board_panels[currentPos].BackgroundImage = null;
                            Main.board[currentPos] = " ";
                            Main.board[prevPos] = "K";
                        }
                    }
                    return false;
                }
            }
            catch (IndexOutOfRangeException)
            {
                isWon = true;
                Piece.Captured(prevPiece, currentPos, prevPos);


                IsFinished();
                return false;
            }
        }

        public static bool IsFinished()
        {
            if (isWon)
            {
                isFinished = true;
                Win win = new Win();
                win.Show();
                return true;
            }
            else if (isGameOver)
            {
                isFinished = true;
                GameOver gameOver = new GameOver();
                gameOver.Show();
                return true;
            }
            else return false;
        }
    }
}
