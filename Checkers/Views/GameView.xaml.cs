using Checkers.Models;
using System.Windows.Controls;

namespace Checkers.Views
{
    public partial class GameView : UserControl
    {
        private readonly Image[,] pieceImages = new Image[8, 8];

        private GameState gameState;
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
    }
}
