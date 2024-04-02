using System.Collections.Generic;

namespace Checkers.Models
{
    public class BlackPiece : Piece
    {
        public override PieceType Type => PieceType.BlackPiece;
        public override Player Color { get; }
        public BlackPiece(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            BlackPiece copy = new BlackPiece(Color);
            return copy;
        }

        public override List<Position> GetPossibleMovePositions(Position from, Board board)
        {
            List<Position> possibleMovePositions = new List<Position>();

            // southWest possible positions
            Position southWest = new Position(from.Row + 1, from.Column - 1);
            if (Board.IsInside(southWest))
            {
                if (board[southWest] == null)
                {
                    possibleMovePositions.Add(southWest);
                }
                else
                {
                    if (board[southWest].Color != Color)
                    {
                        southWest.Row += 1;
                        southWest.Column -= 1;
                        if (Board.IsInside(southWest))
                        {
                            if (board[southWest] == null)
                            {
                                possibleMovePositions.Add(southWest);
                            }
                        }
                    }
                }
            }

            // southEast possible positions
            Position southEast = new Position(from.Row + 1, from.Column + 1);
            if (Board.IsInside(southEast))
            {
                if (board[southEast] == null)
                {
                    possibleMovePositions.Add(southEast);
                }
                else
                {
                    if (board[southEast].Color != Color)
                    {
                        southEast.Row += 1;
                        southEast.Column += 1;
                        if (Board.IsInside(southEast))
                        {
                            if (board[southEast] == null)
                            {
                                possibleMovePositions.Add(southEast);
                            }
                        }
                    }
                }
            }

            return possibleMovePositions;
        }
    }
}
