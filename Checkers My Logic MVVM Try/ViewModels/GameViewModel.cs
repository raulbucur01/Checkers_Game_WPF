using Checkers.Models;
using System.Collections.Generic;
using System.Linq;

namespace Checkers.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        // game info
        private int _noRedPieces;

        public int NoRedPieces
        {
            get { return _noRedPieces; }
            set
            {
                if (_noRedPieces != value)
                {
                    _noRedPieces = value;
                    OnPropertyChanged(nameof(NoRedPieces));
                }
            }
        }

        private int _noBlackPieces;

        public int NoBlackPieces
        {
            get { return _noBlackPieces; }
            set
            {
                if (_noBlackPieces != value)
                {
                    _noBlackPieces = value;
                    OnPropertyChanged(nameof(NoBlackPieces));
                }
            }
        }

        private string _currentPlayer;

        public string CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
                if (_currentPlayer != value)
                {
                    _currentPlayer = value;
                    OnPropertyChanged(nameof(CurrentPlayer));
                }
            }
        }

        private bool _gameFinished;

        public bool GameFinished
        {
            get { return _gameFinished; }
            set
            {
                if (_gameFinished != value)
                {
                    _gameFinished = value;
                    OnPropertyChanged(nameof(GameFinished));
                }
            }
        }

        private string _gameOutcome;

        public string GameOutcome
        {
            get { return _gameOutcome; }
            set
            {
                if (_gameOutcome != value)
                {
                    _gameOutcome = value;
                    OnPropertyChanged(nameof(GameOutcome));
                }
            }
        }

        public GameViewModel()
        {
            possibleMoveCache = new List<Position>();
            gameState = new GameState(Player.Red, Board.Initial());

            CurrentPlayer = gameState.CurrentPlayer.ToString();
            NoRedPieces = gameState.GetNoRedPiecesLeft();
            NoBlackPieces = gameState.GetNoBlackPiecesLeft();
            GameFinished = false;
            GameOutcome = null;
        }

        private GameState gameState;
        private Position selectedPos = null;
        private List<Position> possibleMoveCache;

        public Position GetSelectedPos()
        {
            return selectedPos;
        }

        public List<Position> GetPossibleMoveCache()
        {
            return possibleMoveCache;
        }

        public Board GetBoard()
        {
            return gameState.Board;
        }

        public void OnToPositionSelected(Position pos)
        {
            Position fromPos = selectedPos;
            selectedPos = null;

            if (possibleMoveCache.Contains(pos))
            {
                HandleMove(fromPos, pos);
            }
        }

        public void HandleMove(Position fromPos, Position toPos)
        {
            gameState.MakeMove(fromPos, toPos);

            // update bindings
            CurrentPlayer = gameState.CurrentPlayer.ToString();
            NoRedPieces = gameState.GetNoRedPiecesLeft();
            NoBlackPieces= gameState.GetNoBlackPiecesLeft();

            if (NoRedPieces == 0)
            {
                GameFinished = true;
                GameOutcome = "Black player won!";
            }
            else if (NoBlackPieces == 0)
            {
                GameFinished = true;
                GameOutcome = "Red player won!";
            }
        }

        public bool OnFromPositionSelected(Position pos)
        {
            List<Position> positions = gameState.LegalMovePositionsForPiece(pos);

            if (positions.Any())
            {
                selectedPos = pos;
                CacheMoves(positions);
                return true;
            }

            return false;
        }

        public void CacheMoves(List<Position> positions)
        {
            possibleMoveCache.Clear();

            foreach (Position pos in positions)
            {
                possibleMoveCache.Add(pos);
            }
        }
    }
}
