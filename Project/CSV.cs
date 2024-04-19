namespace DailyChessPuzzle
{
    internal class CSV
    {
        private string fen, moves, rating;
        public CSV(string[] fields)
        {
            fen = fields[1];
            moves = fields[2];
            rating = fields[3];
        }

        public string FEN { get { return fen; } }
        public string Moves { get { return moves; } }
        public string Rating { get { return rating; } }
    }
}
