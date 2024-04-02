using System;
using System.Collections.Generic;

namespace Checkers.Models
{
    public class GameState
    {
        public Board Board { get; }
        public Player CurrentPlayer { get; private set; }

        public bool MultipleJumpAllowed { get; set; } = true;

        public GameState(Player player, Board board)
        {
            CurrentPlayer = player;
            Board = board;
        }

        public List<Position> LegalMovePositionsForPiece(Position pos)
        {
            if (Board.IsEmpty(pos) || Board[pos].Color != CurrentPlayer)
            {
                return new List<Position>();
            }

            Piece piece = Board[pos];
            if (MultipleJumpAllowed)
            {
                return piece.GetPossibleMovePositionsMultipleJump(pos, Board);
            }

            return piece.GetPossibleMovePositions(pos, Board);
        }

        public void MakeMove(Position fromPos, Position toPos)
        {
            Piece piece = Board[fromPos];
            Board[fromPos] = null;

            if (PromotableToKing(toPos))
            {
                piece = new King(CurrentPlayer);
            }

            Board[toPos] = piece;
            CurrentPlayer = CurrentPlayer.Opponent();
            RemovePiecesBetween(fromPos, toPos);
        }

        public bool PromotableToKing(Position toPos)
        {
            if (toPos.Row == 7 || toPos.Row == 0)
                return true;

            return false;
        }

        private void RemovePiecesBetween(Position fromPos, Position toPos)
        {
            // NorthEast
            if (toPos.Row < fromPos.Row && toPos.Column > fromPos.Column)
            {
                for (int i = fromPos.Row - 1, j = fromPos.Column + 1; i > toPos.Row && j < toPos.Column; i--, j++)
                {
                    Board[i, j] = null;
                }
            }

            // NorthWest
            if (toPos.Row < fromPos.Row && toPos.Column < fromPos.Column)
            {
                for (int i = fromPos.Row - 1, j = fromPos.Column - 1; i > toPos.Row && j > toPos.Column; i--, j--)
                {
                    Board[i, j] = null;
                }
            }

            // SouthEast
            if (toPos.Row > fromPos.Row && toPos.Column > fromPos.Column)
            {
                for (int i = fromPos.Row + 1, j = fromPos.Column + 1; i < toPos.Row && j < toPos.Column; i++, j++)
                {
                    Board[i, j] = null;
                }
            }

            // SouthWest
            if (toPos.Row > fromPos.Row && toPos.Column < fromPos.Column)
            {
                for (int i = fromPos.Row + 1, j = fromPos.Column - 1; i < toPos.Row && j > toPos.Column; i++, j--)
                {
                    Board[i, j] = null;
                }
            }
        }
    }
}
