using DailyChessPuzzle.Properties;
using System;
using System.ComponentModel;
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
        public static Label lblTask, lblCorrectMove, lblIncorrectMove, lblKeplerScore, lblNewtonScore, lblKelvinScore, lblFaradayScore;
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
            //SQL sql = new SQL();

            string username = Environment.UserName;
            SQL.UserName = username;

            // Checks if Player has already played today
            if (SQL.AlreadyPlayed())
            {
                PlayAgain playAgain = new PlayAgain();
                playAgain.ShowDialog();
            }
            else
            {
                // Checks if it is the first time the user has played
                if (!SQL.UsernameExists(username))
                {
                    Welcome welcome = new Welcome();
                    welcome.ShowDialog();
                    SQL.NewUser();
                }

                Instructions instructions = new Instructions();
                instructions.ShowDialog();

                Board clsBoard = new Board();

                GenerateBoardPanels();
                SetupControls();
                Puzzle clsPuzzle = new Puzzle(lblTask);

                Puzzle.ReadFEN();
                ComputerMove(Puzzle.moveArr[Puzzle.moveCount]);
            }
        }

        private void SetupControls()
        {
            // After gathering current scores (both individual and team),
            // each control is setup programmatically if required, (the strike
            // images, move correct/incorrect labels, and team score labels)

            SQL.GetCurrentScore();
            SQL.GetTeamScores();

            imgStrike1 = new PictureBox();
            imgStrike1.Size = new Size(75, 75);
            imgStrike1.Location = new Point(96, 4);
            imgStrike1.Image = Resources.inactive_x;

            imgStrike2 = new PictureBox();
            imgStrike2.Size = new Size(75, 75);
            imgStrike2.Location = new Point(196, 4);
            imgStrike2.Image = Resources.inactive_x;

            imgStrike3 = new PictureBox();
            imgStrike3.Size = new Size(75, 75);
            imgStrike3.Location = new Point(296, 4);
            imgStrike3.Image = Resources.inactive_x;

            lblTask = new Label();
            lblTask.Size = new Size(380, 34);
            lblTask.Location = new Point(705, 32);
            lblTask.Font = new Font("Outfit", (float)14.25, FontStyle.Bold);
            lblTask.TextAlign = ContentAlignment.MiddleLeft;

            lblCorrectMove = new Label();
            lblCorrectMove.Size = new Size(182, 98);
            lblCorrectMove.Location = new Point(7, 57);
            lblCorrectMove.Font = new Font("Outfit", (float)8.25);

            lblIncorrectMove = new Label();
            lblIncorrectMove.Size = new Size(182, 98);
            lblIncorrectMove.Location = new Point(204, 57);
            lblIncorrectMove.TextAlign = ContentAlignment.TopRight;
            lblIncorrectMove.Font = new Font("Outfit", (float)8.25);

            lblKeplerScore = new Label();
            lblKeplerScore.Size = new Size(182, 28);
            lblKeplerScore.Location = new Point(7, 57);
            lblKeplerScore.Text = Puzzle.teamScores[0].ToString();
            lblKeplerScore.Font = new Font("Outfit", (float)8.25);
            lblKeplerScore.ForeColor = Color.LimeGreen;

            lblNewtonScore = new Label();
            lblNewtonScore.Size = new Size(182, 28);
            lblNewtonScore.Location = new Point(204, 57);
            lblNewtonScore.TextAlign = ContentAlignment.TopRight;
            lblNewtonScore.Text = Puzzle.teamScores[1].ToString();
            lblNewtonScore.Font = new Font("Outfit", (float)8.25);
            lblNewtonScore.ForeColor = Color.Red;

            lblKelvinScore = new Label();
            lblKelvinScore.Size = new Size(182, 28);
            lblKelvinScore.Location = new Point(7, 108  );
            lblKelvinScore.Text = Puzzle.teamScores[2].ToString();
            lblKelvinScore.Font = new Font("Outfit", (float)8.25);
            lblKelvinScore.ForeColor = Color.Orange;

            lblFaradayScore = new Label();
            lblFaradayScore.Size = new Size(182, 28);
            lblFaradayScore.Location = new Point(204, 108);
            lblFaradayScore.TextAlign = ContentAlignment.TopRight;
            lblFaradayScore.Text = Puzzle.teamScores[3].ToString();
            lblFaradayScore.Font = new Font("Outfit", (float)8.25);
            lblFaradayScore.ForeColor = Color.Blue;

            panel2.Controls.Add(imgStrike1);
            panel2.Controls.Add(imgStrike2);
            panel2.Controls.Add(imgStrike3);
            Controls.Add(lblTask);
            panel3.Controls.Add(lblCorrectMove);
            panel3.Controls.Add(lblIncorrectMove);
            panel4.Controls.Add(lblKeplerScore);
            panel4.Controls.Add(lblNewtonScore);
            panel4.Controls.Add(lblKelvinScore);
            panel4.Controls.Add(lblFaradayScore);
        }

        private void GenerateBoardPanels()
        {
            // Filters through all of the panels within the manually created board panel, and
            // binds the panel to the board_panels array to be altered later on through piece
            // movement and position generation.

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


                // Square clicked, check if piece or tile clicked, if tile - check if tag = legal,
                // if piece - check if new piece - deactivate previous legal moves and generate
                // new legal move markers.
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
                    }
                    else if (control.BackgroundImage.Tag.ToString() != "legal" || control.BackgroundImage.Tag.ToString().Contains("capture"))
                    {
                        // Clear Previous Legal Move Flags
                        foreach (var c in pnlBoard.Controls.OfType<Panel>())
                        {
                            if (c.BackgroundImage != null)
                            {
                                if (c.BackgroundImage.Tag.ToString() == "legal")
                                {
                                    if (!Char.IsUpper(piece, 0))
                                    {
                                        c.BackgroundImage = null;
                                        isPiecedCapture = false;
                                    }
                                }
                                else if (c.BackgroundImage.Tag.ToString().Contains("capture"))
                                {
                                    isPiecedCapture = true;
                                    Console.WriteLine("Capture");
                                    if (Puzzle.IsMove(prevSquareName, prevPos, squareName, currentPos, prevPiece))
                                    {
                                        if (!Char.IsUpper(piece, 0)) Piece.Captured(prevPiece, currentPos, prevPos);
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

                        if (!Char.IsUpper(piece, 0)) Piece.Move(control, prevPiece, currentPos, prevPos, isPieceMoved, prevSquareName, squareName);
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
            // Gets the original square, and combines it with the target square to move piece to
            // the correct square based off set move from puzzle

            string piece = String.Empty;
            int originalPos = 0;
            int newPos = 0;

            string originalSquare = move.Substring(0, 2);
            string newSquare = move.Substring(2);

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

        public static bool Strike(string piece)
        {
            // Adds strike and checks if game is over
            if (!Char.IsUpper(piece, 0))
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
                            return true;

                    }
                    Puzzle.isGameOver = false;
                    return true;
                }
                else
                {
                    Puzzle.isGameOver = true;
                    return true;
                }
            }
            else
            {
                Puzzle.isGameOver = false;
                return false;
            }
        }

        public static void UpdateCorrect(string move)
        {
            // Updates correctMove label

            if (isFirstCorrectMove)
            {
                isFirstCorrectMove = false;
                lblCorrectMove.Text = $"{move}\n";
            }
            else lblCorrectMove.Text += $"{move}\n";
        }

        public static void UpdateIncorrect(string move)
        {
            // Updates incorrectMove label

            if (isFirstIncorrectMove)
            {
                isFirstIncorrectMove = false;
                lblIncorrectMove.Text = $"{move}\n";
            }
            else lblIncorrectMove.Text += $"{move}\n";
        }

        public static void UpdateScoreLabel()
        {
            // Updates team score labels

            lblKeplerScore.Text = Puzzle.teamScores[0].ToString();
            lblNewtonScore.Text = Puzzle.teamScores[1].ToString();
            lblKelvinScore.Text = Puzzle.teamScores[2].ToString();
            lblFaradayScore.Text = Puzzle.teamScores[3].ToString();
        }
    }
}