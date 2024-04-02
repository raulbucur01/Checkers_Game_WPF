using System;
using System.Collections.Generic;

namespace Checkers.Models
{
    public class GameState
    {
        public Board Board { get; }
        public Player CurrentPlayer { get; private set; }

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
            return piece.GetPossibleMovePositions(pos, Board);
        }

        public void MakeMove(Position fromPos, Position toPos)
        {
            Piece piece = Board[fromPos];
            Board[toPos] = piece;
            Board[fromPos] = null;
            CurrentPlayer = CurrentPlayer.Opponent();
            RemovePieceBetween(fromPos, toPos);
        }

        private void RemovePieceBetween(Position fromPos, Position toPos)
        {
            // northEast
            if (toPos.Row < fromPos.Row && toPos.Column > fromPos.Column)
            {
                if (fromPos.Row - 1 != toPos.Row && fromPos.Column + 1 != toPos.Column)
                {
                    Board[fromPos.Row - 1, fromPos.Column + 1] = null;
                }
            }

            // NorthWest
            if (toPos.Row < fromPos.Row && toPos.Column < fromPos.Column)
            {
                if (fromPos.Row - 1 != toPos.Row && fromPos.Column - 1 != toPos.Column)
                {
                    Board[fromPos.Row - 1, fromPos.Column - 1] = null;
                }
            }

            // SouthEast
            if (toPos.Row > fromPos.Row && toPos.Column > fromPos.Column)
            {
                if (fromPos.Row + 1 != toPos.Row && fromPos.Column + 1 != toPos.Column)
                {
                    Board[fromPos.Row + 1, fromPos.Column + 1] = null;
                }
            }

            // SouthWest
            if (toPos.Row > fromPos.Row && toPos.Column < fromPos.Column)
            {
                if (fromPos.Row + 1 != toPos.Row && fromPos.Column - 1 != toPos.Column)
                {
                    Board[fromPos.Row + 1, fromPos.Column - 1] = null;
                }
            }
        }
    }
}
