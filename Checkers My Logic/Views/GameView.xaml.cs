using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Checkers.Views
{
    public partial class GameView : UserControl
    {
        private readonly Image[,] pieceImages = new Image[8, 8];
        private readonly Rectangle[,] highlights = new Rectangle[8, 8];
        //private readonly Dictionary<Position, Move> moveCache = new Dictionary<Position, Move>();
        private List<Position> possibleMoveCache = new List<Position>();

        private GameState gameState;
        private Position selectedPos = null;
        public GameView()
        {
            InitializeComponent();
            InitializeBoard();

            gameState = new GameState(Player.Red, Board.Initial());
            DrawBoard(gameState.Board);
        }

        private void InitializeBoard()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Image image = new Image();
                    pieceImages[r, c] = image;
                    PieceGrid.Children.Add(image);

                    Rectangle highlight = new Rectangle();
                    highlights[r, c] = highlight;
                    HighlightGrid.Children.Add(highlight);
                }
            }
        }

        private void DrawBoard(Board board)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Piece piece = board[r, c];
                    pieceImages[r, c].Source = Images.GetImage(piece);
                }
            }
        }

        private void BoardGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(BoardGrid);
            Position pos = ToSquarePosition(point);

            if (selectedPos == null)
            {
                OnFromPositionSelected(pos);
            }
            else
            {
                OnToPositionSelected(pos);
            }
        }

        private void OnToPositionSelected(Position pos)
        {
            Position fromPos = selectedPos;
            selectedPos = null;
            HideHighlights();

            if (possibleMoveCache.Contains(pos))
            {
                HandleMove(fromPos, pos);
            }
        }

        private void HandleMove(Position fromPos, Position toPos)
        {
            gameState.MakeMove(fromPos, toPos);
            DrawBoard(gameState.Board);
        }

        private void OnFromPositionSelected(Position pos)
        {
            List<Position> positions = gameState.LegalMovePositionsForPiece(pos);

            if (positions.Any())
            {
                selectedPos = pos;
                CacheMoves(positions);
                ShowHighlights();
            }
        }

        private Position ToSquarePosition(Point point)
        {
            double squareSize = BoardGrid.ActualWidth / 8;
            int row = (int)(point.Y / squareSize);
            int column = (int)(point.X / squareSize);

            return new Position(row, column);
        }

        private void CacheMoves(List<Position> positions)
        {
            possibleMoveCache.Clear();

            foreach (Position pos in positions)
            {
                possibleMoveCache.Add(pos);
            }
        }

        private void ShowHighlights()
        {
            Color color = Color.FromArgb(150, 125, 255, 125);

            foreach (Position to in possibleMoveCache)
            {
                highlights[to.Row, to.Column].Fill = new SolidColorBrush(color);
            }
        }

        private void HideHighlights()
        {
            foreach (Position to in possibleMoveCache)
            {
                highlights[to.Row, to.Column].Fill = Brushes.Transparent;
            }
        }
    }
}
