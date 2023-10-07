using DailyChessPuzzle.Properties;
using System;
using System.Linq;
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

        public static string[] board = new string[64];

        public static string[] _board = new string[128]
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

        public static Panel[] board_panels = new Panel[64];

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
            Board clsBoard = new Board();

            GenerateBoardPanels();
            Puzzle.ReadFEN();
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
            int currentPos = Convert.ToInt32(control.Tag.ToString());

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
                                Piece.Captured(c, prevPiece, currentPos, prevPos);
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

                    if (!isPiecedCapture)
                    {
                        Piece.Move(control, prevPiece, currentPos, prevPos, isPieceMoved);
                    }
                }
                else
                {
                    isPieceMoved = true;
                    isPiecedCapture = false;
                    Piece.Move(control, prevPiece, currentPos, prevPos, isPieceMoved);
                }
            }
        }
    }
}