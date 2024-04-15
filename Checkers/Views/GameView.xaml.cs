using Checkers.Models;
using Checkers.ViewModels;
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

        private GameViewModel gameViewModel;
        public GameView()
        {
            InitializeComponent();
            InitializeBoard();

            gameViewModel = (GameViewModel)DataContext;

            DrawBoard(gameViewModel.GetBoard());

            // subscribing to the BoardStateChanged event
            gameViewModel.BoardStateChanged += (sender, e) =>
            {
                DrawBoard(gameViewModel.GetBoard());
            };
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

            if (gameViewModel.GetSelectedPos() == null)
            {
                if (gameViewModel.OnFromPositionSelected(pos))
                {
                    ShowHighlights();
                }
            }
            else
            {
                HideHighlights();
                gameViewModel.OnToPositionSelected(pos);
                DrawBoard(gameViewModel.GetBoard());
            }
        }

        private Position ToSquarePosition(Point point)
        {
            double squareSize = BoardGrid.ActualWidth / 8;
            int row = (int)(point.Y / squareSize);
            int column = (int)(point.X / squareSize);

            return new Position(row, column);
        }

        private void ShowHighlights()
        {
            Color color = Color.FromArgb(120, 30, 144, 255);

            foreach (Position to in gameViewModel.GetPossibleMoveCache())
            {
                highlights[to.Row, to.Column].Fill = new SolidColorBrush(color);
            }
        }

        private void HideHighlights()
        {
            foreach (Position to in gameViewModel.GetPossibleMoveCache())
            {
                highlights[to.Row, to.Column].Fill = Brushes.Transparent;
            }
        }
    }
}
