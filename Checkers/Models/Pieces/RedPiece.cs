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

        public override List<Position> GetPossibleMovePositionsMultipleJump(Position from, Board board)
        {
            List<Position> possibleMovePositions = new List<Position>();

            // NorthEast possible positions
            Position northEast = new Position(from.Row - 1, from.Column + 1);
            if (Board.IsInside(northEast))
            {
                if (board[northEast] == null)
                {
                    possibleMovePositions.Add(northEast);
                }
                else
                {
                    Position northEastFirst = northEast;
                    Position northEastSecond = new Position(from.Row - 2, from.Column + 2);

                    if (Board.IsInside(northEastFirst) && Board.IsInside(northEastSecond))
                    {
                        while (board[northEastFirst].Color != Color && board[northEastSecond] == null)
                        {
                            possibleMovePositions.Add(northEastSecond);

                            northEastFirst = new Position(northEastSecond.Row - 1, northEastSecond.Column + 1);
                            northEastSecond = new Position(northEastFirst.Row - 1, northEastFirst.Column + 1);

                            

                            if (!Board.IsInside(northEastFirst) || !Board.IsInside(northEastSecond))
                            {
                                break;
                            }

                            if (board.IsEmpty(northEastFirst))
                            {
                                break;
                            }
                        }
                    }
                }
            }

            // NorthWest possible positions
            Position northWest = new Position(from.Row - 1, from.Column - 1);
            if (Board.IsInside(northWest))
            {
                if (board[northWest] == null)
                {
                    possibleMovePositions.Add(northWest);
                }
                else
                {
                    Position northWestFirst = northWest;
                    Position northWestSecond = new Position(from.Row - 2, from.Column - 2);

                    if (Board.IsInside(northWestFirst) && Board.IsInside(northWestSecond))
                    {
                        while (board[northWestFirst].Color != Color && board[northWestSecond] == null)
                        {
                            possibleMovePositions.Add(northWestSecond);

                            northWestFirst = new Position(northWestSecond.Row - 1, northWestSecond.Column - 1);
                            northWestSecond = new Position(northWestFirst.Row - 1, northWestFirst.Column - 1);

                            if (!Board.IsInside(northWestFirst) || !Board.IsInside(northWestSecond))
                            {
                                break;
                            }

                            if (board.IsEmpty(northWestFirst))
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return possibleMovePositions;
        }
    }
}
