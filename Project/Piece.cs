using DailyChessPuzzle.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyChessPuzzle
{
    internal class Piece
    {
        List<string> section = new List<string>();
        int rankNum;

        public Piece(List<string> fSection, int fRankNum)
        { 
            section = fSection;
            rankNum = fRankNum;
        }

        private void GeneratePieces(List<string> section, int rankNum)
        {
            int pos;

            // Effective - Replaces 8 ifs
            int[] posArr = new int[9] { 0, 56, 48, 40, 32, 24, 16, 8, 0 };
            pos = posArr[rankNum];

            foreach (string item in section)
            {
                // As the pieces are determined Black (lowercase) and White (uppercase) Char.IsUpper() can be used to determine which type piece is being added.
                bool isWhitePiece = (Char.IsUpper(item, 0));
                bool isBlackPiece = !(Char.IsUpper(item, 0));
                bool isBlankSquare = (Char.IsNumber(item, 0));

                Main.board_panels[pos].BackgroundImageLayout = ImageLayout.Zoom;

                if (isBlankSquare)
                {
                    pos += Convert.ToInt32(item);
                    continue;
                }

                if (isWhitePiece)
                {
                    if (item == "P") Main.board_panels[pos].BackgroundImage = Resources.wp;     // White Pawn
                    if (item == "R") Main.board_panels[pos].BackgroundImage = Resources.wr;     // White Rook
                    if (item == "N") Main.board_panels[pos].BackgroundImage = Resources.wn;     // White Knight
                    if (item == "B") Main.board_panels[pos].BackgroundImage = Resources.wb;     // White Bishop
                    if (item == "Q") Main.board_panels[pos].BackgroundImage = Resources.wq;     // White Queen
                    if (item == "K") Main.board_panels[pos].BackgroundImage = Resources.wk;     // White King
                }
                if (isBlackPiece)
                {
                    if (item == "p") Main.board_panels[pos].BackgroundImage = Resources.bp;     // Black Pawn
                    if (item == "r") Main.board_panels[pos].BackgroundImage = Resources.br;     // Black Rook
                    if (item == "n") Main.board_panels[pos].BackgroundImage = Resources.bn;     // Black Knight
                    if (item == "b") Main.board_panels[pos].BackgroundImage = Resources.bb;     // Black Bishop
                    if (item == "q") Main.board_panels[pos].BackgroundImage = Resources.bq;     // Black Queen
                    if (item == "k") Main.board_panels[pos].BackgroundImage = Resources.bk;     // Black King
                }
                pos++;
            }
        }
    }
}
