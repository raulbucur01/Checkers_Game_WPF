using System.Collections.Generic;

namespace Checkers.Models
{
    public class RedPiece : Piece
    {
        public override PieceType Type => PieceType.RedPiece;
        public override Player Color { get; }
        public RedPiece(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            RedPiece copy = new RedPiece(Color);
            return copy;
        }

        public override List<Position> GetPossibleMovePositions(Position from, Board board)
        {
            List<Position> possibleMovePositions = new List<Position>();

            // northWest possible positions
            Position northWest = new Position(from.Row - 1, from.Column - 1);
            if (Board.IsInside(northWest))
            {
                if (board[northWest] == null)
                {
                    possibleMovePositions.Add(northWest);
                }
                else
                {
                    if (board[northWest].Color != Color)
                    {
                        northWest.Row -= 1;
                        northWest.Column -= 1;
                        if (Board.IsInside(northWest))
                        {
                            if (board[northWest] == null)
                            {
                                possibleMovePositions.Add(northWest);
                            }
                        }
                    }
                }
            }

            // northEast possible positions
            Position northEast = new Position(from.Row - 1, from.Column + 1);
            if (Board.IsInside(northEast))
            {
                if (board[northEast] == null)
                {
                    possibleMovePositions.Add(northEast);
                }
                else
                {
                    if (board[northEast].Color != Color)
                    {
                        northEast.Row -= 1;
                        northEast.Column += 1;
                        if (Board.IsInside(northEast))
                        {
                            if (board[northEast] == null)
                            {
                                possibleMovePositions.Add(northEast);
                            }
                        }
                    }
                }
            }

            return possibleMovePositions;
        }
    }
}
