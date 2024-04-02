using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Checkers.Models
{
    public class NormalRedPiece : Piece
    {
        public override PieceType Type => PieceType.NormalRedPiece;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.NorthWest,
            Direction.NorthEast
        };

        public NormalRedPiece(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            NormalRedPiece copy = new NormalRedPiece(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private IEnumerable<Position> MovePositions(Position from, Board board)
        {
            foreach (Direction dir in dirs)
            {
                Position to = from + dir;

                if (!Board.IsInside(to))
                {
                    continue;
                }

                if (board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            foreach (Position to in MovePositions(from, board))
            {
                yield return new NormalMove(from, to);
            }
        }
    }
}
