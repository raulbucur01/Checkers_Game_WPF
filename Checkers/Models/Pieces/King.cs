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

            // SouthWest possible positions
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

            // SouthEast possible positions
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

            // SouthWest possible positions
            Position southWest = new Position(from.Row + 1, from.Column - 1);
            if (Board.IsInside(southWest))
            {
                if (board[southWest] == null)
                {
                    possibleMovePositions.Add(southWest);
                }
                else
                {
                    Position southWestFirst = southWest;
                    Position southWestSecond = new Position(from.Row + 2, from.Column - 2);

                    if (Board.IsInside(southWestFirst) && Board.IsInside(southWestSecond))
                    {
                        while (board[southWestFirst].Color != Color && board[southWestSecond] == null)
                        {
                            possibleMovePositions.Add(southWestSecond);

                            southWestFirst = new Position(southWestSecond.Row + 1, southWestSecond.Column - 1);
                            southWestSecond = new Position(southWestFirst.Row + 1, southWestFirst.Column - 1);

                            if (!Board.IsInside(southWestFirst) || !Board.IsInside(southWestSecond))
                            {
                                break;
                            }

                            if (board.IsEmpty(southWestFirst))
                            {
                                break;
                            }
                        }
                    }
                }
            }

            // SouthEast possible positions
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
                        Position southEastFirst = southEast;
                        Position southEastSecond = new Position(from.Row + 2, from.Column + 2);

                        if (Board.IsInside(southEastFirst) && Board.IsInside(southEastSecond))
                        {
                            while (board[southEastFirst].Color != Color && board[southEastSecond] == null)
                            {
                                possibleMovePositions.Add(southEastSecond);

                                southEastFirst = new Position(southEastSecond.Row + 1, southEastSecond.Column + 1);
                                southEastSecond = new Position(southEastFirst.Row + 1, southEastFirst.Column + 1);

                                if (!Board.IsInside(southEastFirst) || !Board.IsInside(southEastSecond))
                                {
                                    break;
                                }

                                if (board.IsEmpty(southEastFirst))
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return possibleMovePositions;
        }
    }
}
