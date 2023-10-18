using DailyChessPuzzle.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Windows.Forms;

namespace DailyChessPuzzle
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private static bool isPieceMoved = false;
        private static bool isPiecedCapture = false;
        public static int prevPos;
        public static string prevPiece;
        public static string prevSquareName;
        private static bool isFirstCorrectMove = true;
        private static bool isFirstIncorrectMove = true;

        public static PictureBox imgStrike1, imgStrike2, imgStrike3;
        public static Label lblCorrectMove, lblIncorrectMove, lblKeplerScore, lblNewtonScore, lblKelvinScore, lblFaradayScore;
        private static Main form = new Main();

        public static string[] board = new string[128]
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

        public static string[] square_codes = new string[64]
        {
            "A8", "B8", "C8", "D8", "E8", "F8", "G8", "H8",
            "A7", "B7", "C7", "D7", "E7", "F7", "G7", "H7",
            "A6", "B6", "C6", "D6", "E6", "F6", "G6", "H6",
            "A5", "B5", "C5", "D5", "E5", "F5", "G5", "H5",
            "A4", "B4", "C4", "D4", "E4", "F4", "G4", "H4",
            "A3", "B3", "C3", "D3", "E3", "F3", "G3", "H3",
            "A2", "B2", "C2", "D2", "E2", "F2", "G2", "H2",
            "A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1"
        };

        public static string[] legal_board = new string[128]
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

        private void Form1_Load(object sender, EventArgs e)
        {
            SQL sql = new SQL();

            string username = Environment.UserName;
            SQL.UserName = username;

            if (SQL.AlreadyPlayed())
            {
                PlayAgain playAgain = new PlayAgain();
                playAgain.ShowDialog();
            }
            else
            {
                if (!SQL.UsernameExists(username))
                {
                    Welcome welcome = new Welcome();
                    welcome.ShowDialog();
                    SQL.NewUser();
                }

                Board clsBoard = new Board();

                GenerateBoardPanels();
                SetupControls();
                Puzzle clsPuzzle = new Puzzle(txtTask);

                Puzzle.ReadFEN();
                ComputerMove(Puzzle.moveArr[Puzzle.moveCount]);
            }
        }

        private void SetupControls()
        {
            SQL.GetCurrentScore();
            SQL.GetTeamScores();
            // imgStrike1
            imgStrike1 = new PictureBox();
            imgStrike1.Size = new Size(75, 75);
            imgStrike1.Location = new Point(96, 4);
            imgStrike1.Image = Resources.inactive_x;

            // imgStrike2
            imgStrike2 = new PictureBox();
            imgStrike2.Size = new Size(75, 75);
            imgStrike2.Location = new Point(196, 4);
            imgStrike2.Image = Resources.inactive_x;

            // imgStrike3
            imgStrike3 = new PictureBox();
            imgStrike3.Size = new Size(75, 75);
            imgStrike3.Location = new Point(296, 4);
            imgStrike3.Image = Resources.inactive_x;

            // lblCorrectMove
            lblCorrectMove = new Label();
            lblCorrectMove.Size = new Size(182, 98);
            lblCorrectMove.Location = new Point(7, 57);

            // lblIncorrectMove
            lblIncorrectMove = new Label();
            lblIncorrectMove.Size = new Size(182, 98);
            lblIncorrectMove.Location = new Point(204, 57);
            lblIncorrectMove.TextAlign = ContentAlignment.TopRight;

            // lblKeplerScore
            lblKeplerScore = new Label();
            lblKeplerScore.Size = new Size(182, 28);
            lblKeplerScore.
            lblKeplerScore.Text = Puzzle.teamScores[0].ToString();

            // lblNewtonScore
            lblNewtonScore.Text = Puzzle.teamScores[1].ToString();

            // lblKelvinScore
            lblKelvinScore.Text = Puzzle.teamScores[2].ToString();

            // lblFaradayScore
            lblFaradayScore.Text = Puzzle.teamScores[3].ToString();

            panel2.Controls.Add(imgStrike1);
            panel2.Controls.Add(imgStrike2);
            panel2.Controls.Add(imgStrike3);
            panel3.Controls.Add(lblCorrectMove);
            panel3.Controls.Add(lblIncorrectMove);
        }

        private void GenerateBoardPanels()
        {
            //Panel[] pnlArr = new Panel[64];

            foreach (Panel pnl in pnlBoard.Controls)
            {
                if (pnl.Tag != null)
                {
                    Console.WriteLine(Board.isOnBoard(Convert.ToInt32(pnl.Tag.ToString())));
                    if (Board.isOnBoard(Convert.ToInt32(pnl.Tag)))
                    {
                        int tag = Convert.ToInt32(pnl.Tag.ToString());
                        pnl.BackgroundImageLayout = ImageLayout.Zoom;
                        Board.board_panels[tag] = pnl;
                    }
                }

            }
        }

        private void Square_Click(object sender, EventArgs e)
        {
            string piece;

            Control control = (Control)sender;
            string squareName = control.Name;
            int currentPos = Convert.ToInt32(control.Tag.ToString());

            if (!Puzzle.isFinished)
            {
                try
                {
                    piece = control.BackgroundImage.Tag.ToString();

                }
                catch (NullReferenceException)
                {
                    piece = null;
                }

                Piece clsPiece = new Piece(piece);


                // Square clicked, check if piece or tile clicked, if tile - check if tag = legal, if piece - check if new piece - deactivate previous legal moves and generate new legal move markers
                if (control.BackgroundImage != null)
                {
                    if (currentPos == prevPos)
                    {
                        isPieceMoved = false;
                        prevPiece = piece;
                        prevPos = currentPos;
                        prevSquareName = squareName;

                        legal_board = new string[128]
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

                        foreach (var c in Board.board_panels)
                        {
                            if (c != null)
                            {
                                if (c.BackgroundImage != null)
                                {
                                    if (c.BackgroundImage.Tag.ToString() == "legal")
                                    {
                                        c.BackgroundImage = null;
                                        continue;
                                    }
                                    if (c.BackgroundImage.Tag.ToString().Contains("capture"))
                                    {
                                        string[] subPiece = c.BackgroundImage.Tag.ToString().Split(' ');
                                        string p = subPiece[1];

                                        if (p == "p")
                                        {
                                            c.BackgroundImage = Resources.bp;
                                            c.BackgroundImage.Tag = "p";
                                        }
                                        if (p == "n")
                                        {
                                            c.BackgroundImage = Resources.bn;
                                            c.BackgroundImage.Tag = "n";
                                        }
                                        if (p == "b")
                                        {
                                            c.BackgroundImage = Resources.bb;
                                            c.BackgroundImage.Tag = "b";
                                        }
                                        if (p == "r")
                                        {
                                            c.BackgroundImage = Resources.br;
                                            c.BackgroundImage.Tag = "r";
                                        }
                                        if (p == "q")
                                        {
                                            c.BackgroundImage = Resources.bq;
                                            c.BackgroundImage.Tag = "q";
                                        }
                                        if (p == "k")
                                        {
                                            c.BackgroundImage = Resources.br;
                                            c.BackgroundImage.Tag = "k";
                                        }
                                    }
                                }
                            }                            
                        }
                        /*foreach (var c in pnlBoard.Controls.OfType<Panel>())
                        {
                            if (c != null)
                            {
                                if (c.BackgroundImage != null)
                                {
                                    if (c.BackgroundImage.Tag.ToString() == "legal")
                                    {
                                        c.BackgroundImage = null;
                                        continue;
                                    }
                                    if (c.BackgroundImage.Tag.ToString().Contains("capture"))
                                    {
                                        string[] subPiece = c.BackgroundImage.Tag.ToString().Split(' ');
                                        string p = subPiece[1];

                                        if (p == "p")
                                        {
                                            c.BackgroundImage = Resources.bp;
                                            c.BackgroundImage.Tag = "p";
                                        }
                                        if (p == "n")
                                        {
                                            c.BackgroundImage = Resources.bn;
                                            c.BackgroundImage.Tag = "n";
                                        }
                                        if (p == "b")
                                        {
                                            c.BackgroundImage = Resources.bb;
                                            c.BackgroundImage.Tag = "b";
                                        }
                                        if (p == "r")
                                        {
                                            c.BackgroundImage = Resources.br;
                                            c.BackgroundImage.Tag = "r";
                                        }
                                        if (p == "q")
                                        {
                                            c.BackgroundImage = Resources.bq;
                                            c.BackgroundImage.Tag = "q";
                                        }
                                        if (p == "k")
                                        {
                                            c.BackgroundImage = Resources.br;
                                            c.BackgroundImage.Tag = "k";
                                        }
                                    }
                                }
                            }
                        }*/
                    }
                    if (control.BackgroundImage.Tag.ToString() != "legal" || control.BackgroundImage.Tag.ToString().Contains("capture"))
                    {
                        // Clear Previous Legal Move Flags
                        foreach (var c in pnlBoard.Controls.OfType<Panel>())
                        {
                            if (c.BackgroundImage != null)
                            {
                                if (c.BackgroundImage.Tag.ToString() == "legal")
                                {
                                    c.BackgroundImage = null;
                                    isPiecedCapture = false;
                                }
                                else if (c.BackgroundImage.Tag.ToString().Contains("capture"))
                                {
                                    isPiecedCapture = true;
                                    Console.WriteLine("Capture");
                                    if (Puzzle.IsMove(prevSquareName, prevPos, squareName, currentPos, prevPiece))
                                    {
                                        Piece.Captured(prevPiece, currentPos, prevPos);
                                    }
                                }
                            }
                        }

                        legal_board = new string[128]
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

                        // Piece Clicked
                        isPieceMoved = false;
                        prevPiece = piece;
                        prevPos = currentPos;
                        prevSquareName = squareName;

                        if (!isPiecedCapture)
                        {
                            Piece.Move(control, prevPiece, currentPos, prevPos, isPieceMoved, prevSquareName, squareName);
                        }
                        else isPiecedCapture = false;
                    }
                    else
                    {
                        isPieceMoved = true;
                        isPiecedCapture = false;

                        Piece.Move(control, prevPiece, currentPos, prevPos, isPieceMoved, prevSquareName, squareName);
                    }
                }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        public static void ComputerMove(string move)
        {
            string piece = String.Empty;
            int originalPos = 0;
            int newPos = 0;

            string originalSquare = move.Substring(0, 2);
            string newSquare = move.Substring(2);

            Console.WriteLine(originalSquare + " " + newSquare);

            foreach (Panel pnl in form.pnlBoard.Controls)
            {
                if (pnl.Tag != null)
                {
                    if (pnl.Name == originalSquare.ToUpper())
                    {
                        originalPos = Convert.ToInt32(pnl.Tag.ToString());
                        piece = board[originalPos];
                    }
                    if (pnl.Name == newSquare.ToUpper())
                    {
                        newPos = Convert.ToInt32(pnl.Tag.ToString());
                    }
                }
            }

            Board.board_panels[originalPos].BackgroundImage = null;
            Board.board_panels[newPos].BackgroundImage = null;
            if (piece == "p")
            {
                Board.board_panels[newPos].BackgroundImage = Resources.bp;
                Board.board_panels[newPos].BackgroundImage.Tag = "p";
                board[originalPos] = " ";
                board[newPos] = "p";
            }
            if (piece == "n")
            {
                Board.board_panels[newPos].BackgroundImage = Resources.bn;
                Board.board_panels[newPos].BackgroundImage.Tag = "n";
                board[originalPos] = " ";
                board[newPos] = "n";
            }
            if (piece == "b")
            {
                Board.board_panels[newPos].BackgroundImage = Resources.bb;
                Board.board_panels[newPos].BackgroundImage.Tag = "b";
                board[originalPos] = " ";
                board[newPos] = "b";
            }
            if (piece == "r")
            {
                Board.board_panels[newPos].BackgroundImage = Resources.br;
                Board.board_panels[newPos].BackgroundImage.Tag = "r";
                board[originalPos] = " ";
                board[newPos] = "r";
            }
            if (piece == "q")
            {
                Board.board_panels[newPos].BackgroundImage = Resources.bq;
                Board.board_panels[newPos].BackgroundImage.Tag = "q";
                board[originalPos] = " ";
                board[newPos] = "q";
            }
            if (piece == "k")
            {
                Board.board_panels[newPos].BackgroundImage = Resources.bk;
                Board.board_panels[newPos].BackgroundImage.Tag = "k";
                board[originalPos] = " ";
                board[newPos] = "k";
            }
            Puzzle.moveCount++;
        }

        public static bool Strike()
        {
            Puzzle.strike++;
            if (Puzzle.strike <= 4)
            {
                switch (Puzzle.strike)
                {
                    case 1:
                        imgStrike1.Image = Resources.active_x;
                        Puzzle.score--;
                        break;

                    case 2:
                        imgStrike2.Image = Resources.active_x;
                        Puzzle.score--;
                        break;

                    case 3:
                        imgStrike3.Image = Resources.active_x;
                        Puzzle.isGameOver = true;
                        Puzzle.IsFinished();
                        return false;
                        
                }
                return Puzzle.isGameOver = false;
            }
            else return Puzzle.isGameOver = true;
        }

        public static void UpdateCorrect(string move)
         {
            if (isFirstCorrectMove)
            {
                isFirstCorrectMove = false;
                lblCorrectMove.Text = $"{move}\n";
            }
            else lblCorrectMove.Text += $"{move}\n";
        }

        public static void UpdateIncorrect(string move)
        {
            if (isFirstIncorrectMove)
            {
                isFirstIncorrectMove = false;
                lblIncorrectMove.Text = $"{move}\n";
            }
            else lblIncorrectMove.Text += $"{move}\n";
        }

        public static void UpdateScoreLabel()
        {
            lblKeplerScore.Text 
        }
    }
}