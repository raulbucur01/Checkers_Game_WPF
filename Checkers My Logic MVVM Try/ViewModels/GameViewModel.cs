using Checkers.Commands;
using Checkers.Models;
using Checkers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

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

        // statistics
        private string _noRedWins;

        public string NoRedWins
        {
            get { return _noRedWins; }
            set
            {
                if (_noRedWins != value)
                {
                    _noRedWins = value;
                    OnPropertyChanged(nameof(NoRedWins));
                }
            }
        }

        private string _noBlackWins;

        public string NoBlackWins
        {
            get { return _noBlackWins; }
            set
            {
                if (_noBlackWins != value)
                {
                    _noBlackWins = value;
                    OnPropertyChanged(nameof(NoBlackWins));
                }
            }
        }

        private string _maxWinnerPiecesRemaining;

        public string MaxWinnerPiecesRemaining
        {
            get { return _maxWinnerPiecesRemaining; }
            set
            {
                if (_maxWinnerPiecesRemaining != value)
                {
                    _maxWinnerPiecesRemaining = value;
                    OnPropertyChanged(nameof(MaxWinnerPiecesRemaining));
                }
            }
        }

        // multiple jump
        private bool _multipleJumpAllowed;

        public bool MultipleJumpAllowed
        {
            get { return _multipleJumpAllowed; }
            set
            {
                if (_multipleJumpAllowed != value)
                {
                    _multipleJumpAllowed = value;
                    OnPropertyChanged(nameof(MultipleJumpAllowed));
                }
            }
        }
        public ICommand NewGameCommand { get; }
        public ICommand AllowMultipleJumpCommand { get; }
        public ICommand SaveGameCommand { get; }
        public ICommand OpenGameCommand { get; }

        public event EventHandler BoardStateChanged;

        private readonly IDialogService _dialogService;

        public GameViewModel()
        {
            possibleMoveCache = new List<Position>();
            gameState = new GameState(Player.Red, Board.Initial());

            // dialog service
            _dialogService = new DialogService();

            // game info
            CurrentPlayer = gameState.CurrentPlayer.ToString();
            NoRedPieces = gameState.GetNoRedPiecesLeft();
            NoBlackPieces = gameState.GetNoBlackPiecesLeft();
            GameFinished = false;
            GameOutcome = null;

            repository = new Repository();

            // statistics
            NoRedWins = "Red wins: " + repository.NoRedWins;
            NoBlackWins = "Black wins: " + repository.NoBlackWins;
            MaxWinnerPiecesRemaining = "Maximum winner pieces left: " + repository.MaxWinnerPiecesRemaining;

            // commands
            NewGameCommand = new RelayCommand(ExecuteNewGame);
            AllowMultipleJumpCommand = new RelayCommand(ExecuteAllowMultipleJump);
            SaveGameCommand = new RelayCommand(ExecuteSaveGame);
            OpenGameCommand = new RelayCommand(ExecuteOpenGame);
        }

        private void ExecuteOpenGame(object obj)
        {
            string filePath = _dialogService.ShowOpenFileDialog("", "txt");

            if (!string.IsNullOrEmpty(filePath))
            {
                gameState = repository.LoadGameFromFile(filePath);

                CurrentPlayer = gameState.CurrentPlayer.ToString();
                NoRedPieces = gameState.GetNoRedPiecesLeft();
                NoBlackPieces = gameState.GetNoBlackPiecesLeft();
                GameFinished = false;
                GameOutcome = null;
                MultipleJumpAllowed = gameState.MultipleJumpAllowed;

                BoardStateChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void ExecuteSaveGame(object obj)
        {
            string filePath = _dialogService.ShowSaveFileDialog("game", "txt");

            if (!string.IsNullOrEmpty(filePath))
            {
                repository.SaveGameToFile(filePath, gameState);
            }
        }

        private void ExecuteNewGame(object obj)
        {
            gameState = new GameState(Player.Red, Board.Initial());

            CurrentPlayer = gameState.CurrentPlayer.ToString();
            NoRedPieces = gameState.GetNoRedPiecesLeft();
            NoBlackPieces = gameState.GetNoBlackPiecesLeft();
            GameFinished = false;
            GameOutcome = null;

            // notify subscribers that the board state has changed
            BoardStateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ExecuteAllowMultipleJump(object obj)
        {
            if (gameState.MultipleJumpAllowed == false)
                gameState.MultipleJumpAllowed = true;
            else
                gameState.MultipleJumpAllowed = false;
        }

        private Repository repository;
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

                repository.NoBlackWins += 1;
                NoBlackWins = "Black wins: " + repository.NoBlackWins;

                repository.MaxWinnerPiecesRemaining = NoBlackPieces;
                MaxWinnerPiecesRemaining = "Maximum winner pieces left: " + repository.MaxWinnerPiecesRemaining;
            }
            else if (NoBlackPieces == 0)
            {
                GameFinished = true;
                GameOutcome = "Red player won!";

                repository.NoRedWins += 1;
                NoRedWins = "Red wins: " + repository.NoRedWins;

                repository.MaxWinnerPiecesRemaining = NoRedPieces;
                MaxWinnerPiecesRemaining = "Maximum winner pieces left: " + repository.MaxWinnerPiecesRemaining;
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
