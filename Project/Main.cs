using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DailyChessPuzzle
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        //string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        public static string fen = "2k5/p1p2Q1p/3bN3/1q1pp3/4b1P1/1PB1P2P/P2P1P2/2KR3R b - - 2 20";

        private static bool pastPieceClicked = false;
        private static bool isNewPiece = true;
        private static bool isPieceMoved = false;
        public static int prevPos;
        public static string prevPiece;

        public static string[] board = new string[64];

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
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Board clsBoard = new Board();
            ReadFEN readFEN = new ReadFEN();

            GenerateBoardPanels();
            ReadFEN.Read();
        }

        private void GenerateBoardPanels()
        {
            //Panel[] pnlArr = new Panel[64];

            foreach (Panel pnl in pnlBoard.Controls)
            {
                if (pnl.Tag != null)
                {
                    int tag = Convert.ToInt32(pnl.Tag.ToString());
                    pnl.BackgroundImageLayout = ImageLayout.Zoom;
                    Board.board_panels[tag] = pnl;
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

            switch (isNewPiece)
            {
                case true:
                    isPieceMoved = false;
                    prevPos = currentPos;
                    prevPiece = piece;
                    Piece.Move(prevPiece, currentPos, prevPos, isPieceMoved);
                    isNewPiece = false;

                    break;

                case false:
                    isPieceMoved = true;
                    Piece.Move(prevPiece, currentPos, prevPos, isPieceMoved);
                    isNewPiece = true;
                    
                    break;
            }

            
        }
    }
}
