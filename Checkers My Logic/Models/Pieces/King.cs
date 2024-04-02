using System.Collections.Generic;

namespace Checkers.Models
{
    public class King : Piece
    {
        public override PieceType Type => PieceType.King;
        public override Player Color { get; }
        public King(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            King copy = new King(Color);
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
