namespace Checkers.Models
{
    public class Board
    {
        private readonly Piece[,] pieces = new Piece[8, 8];

        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }

        public Piece this[Position pos]
        {
            get { return this[pos.Row, pos.Column]; }
            set { this[pos.Row, pos.Column] = value; }
        }

        public static Board Initial()
        {
            Board board = new Board();
            board.AddStartPieces();
            return board;
        }

        private void AddStartPieces()
        {
            this[0, 1] = new NormalPiece(Player.Black);
            this[0, 3] = new NormalPiece(Player.Black);
            this[0, 5] = new NormalPiece(Player.Black);
            this[0, 7] = new NormalPiece(Player.Black);

            this[1, 0] = new NormalPiece(Player.Black);
            this[1, 2] = new NormalPiece(Player.Black);
            this[1, 4] = new NormalPiece(Player.Black);
            this[1, 6] = new NormalPiece(Player.Black);

            this[2, 1] = new NormalPiece(Player.Black);
            this[2, 3] = new NormalPiece(Player.Black);
            this[2, 5] = new NormalPiece(Player.Black);
            this[2, 7] = new NormalPiece(Player.Black);

            this[5, 0] = new NormalPiece(Player.Red);
            this[5, 2] = new NormalPiece(Player.Red);
            this[5, 4] = new NormalPiece(Player.Red);
            this[5, 6] = new NormalPiece(Player.Red);

            this[6, 1] = new NormalPiece(Player.Red);
            this[6, 3] = new NormalPiece(Player.Red);
            this[6, 5] = new NormalPiece(Player.Red);
            this[6, 7] = new NormalPiece(Player.Red);

            this[7, 0] = new NormalPiece(Player.Red);
            this[7, 2] = new NormalPiece(Player.Red);
            this[7, 4] = new NormalPiece(Player.Red);
            this[7, 6] = new NormalPiece(Player.Red);
        }

        public static bool IsInside(Position pos)
        {
            return pos.Row >= 0 && pos.Row < 8 && pos.Column >= 0 && pos.Column < 8;
        }

        public bool IsEmpty(Position pos)
        {
            return this[pos] == null;
        }
    }
}
