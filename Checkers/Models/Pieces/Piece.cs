using System.Collections.Generic;

namespace Checkers.Models
{
    public enum PieceType
    {
        RedPiece,
        BlackPiece,
        King
    }
    public abstract class Piece
    {
        public abstract PieceType Type { get; }
        public abstract Player Color { get; }

        public abstract Piece Copy();

        public abstract List<Position> GetPossibleMovePositions(Position from, Board board);
        public abstract List<Position> GetPossibleMovePositionsMultipleJump(Position from, Board board);
    }
}
