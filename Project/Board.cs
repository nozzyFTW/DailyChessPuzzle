﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Panel = System.Windows.Forms.Panel;

namespace DailyChessPuzzle
{
    internal class Board
    {
        public static List<Panel> panels = new List<Panel>();

        public static string[] startingPos = new string[64]
        {
            "r", "n", "b", "q", "k", "b", "n", "r",
            "p", "p", "p", "p", "p", "p", "p", "p",
            " ", " ", " ", " ", " ", " ", " ", " ",
            " ", " ", " ", " ", " ", " ", " ", " ",
            " ", " ", " ", " ", " ", " ", " ", " ",
            " ", " ", " ", " ", " ", " ", " ", " ",
            "P", "P", "P", "P", "P", "P", "P", "P",
            "R", "N", "B", "Q", "K", "B", "N", "R"
        };

        public static string[] _startingPos = new string[128]
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
            return !(Convert.ToBoolean(destination & 0x88));
        }
    }
}
