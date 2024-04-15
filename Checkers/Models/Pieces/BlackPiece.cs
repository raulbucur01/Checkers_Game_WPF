using System.Collections.Generic;
using System.Diagnostics;

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

        public override List<Position> GetPossibleMovePositionsMultipleJump(Position from, Board board)
        {
            List<Position> possibleMovePositions = new List<Position>();

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
