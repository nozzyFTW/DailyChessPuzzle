using System;
using System.Collections.Generic;
using Panel = System.Windows.Forms.Panel;

namespace DailyChessPuzzle
{
    internal class Board
    {
        public static List<Panel> panels = new List<Panel>();

        public static string[] startingPos = new string[128]
        {
            "r", "n", "b", "q", "k", "b", "n", "r", "x", "x", "x", "x", "x", "x", "x", "x",
            "p", "p", "p", "p", "p", "p", "p", "p", "x", "x", "x", "x", "x", "x", "x", "x",
            " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
            " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
            " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
            " ", " ", " ", " ", " ", " ", " ", " ", "x", "x", "x", "x", "x", "x", "x", "x",
            "P", "P", "P", "P", "P", "P", "P", "P", "x", "x", "x", "x", "x", "x", "x", "x",
            "R", "N", "B", "Q", "K", "B", "N", "R", "x", "x", "x", "x", "x", "x", "x", "x"
        };

        public Board()
        {
            board_panels = new Panel[128];
        }
        public static Panel[] board_panels { get; set; }

        public static bool isOnBoard(int destination)
        {
            // Uses Bitwise AND Operation
            // IF (Destination & 0x88) return off board.
            // Reversed result to return true if on board rather than invalid.
            return !(Convert.ToBoolean(destination & 0x88));
        }
        public static void ResetBoard()
        {
            foreach (var square in Board.board_panels)
            {
                if (square != null)
                {
                    if (square.BackgroundImage != null)
                    {
                        if (square.BackgroundImage.Tag.ToString() == "legal")
                        {
                            square.BackgroundImage.Tag = null;
                        }
                        else if (square.BackgroundImage.Tag.ToString().Contains("capture"))
                        {
                            string piece = square.BackgroundImage.Tag.ToString();
                            piece = piece.Split(' ')[0];

                            Board.board_panels[pos].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(piece);
                            Board.board_panels[pos].BackgroundImage.Tag = pieceName;
                        }
                    }
                }
            }
        }
    }
}
