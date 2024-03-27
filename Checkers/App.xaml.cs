using Checkers.Models;
using System.Windows;

namespace Checkers
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Board board = new Board(8,8);
            Piece selected = board.GetPiece(0, 1);
            board.ForcedPlacePiece(new Piece(PieceColor.Black), 0, 0);
            board.ResetBoard();

            base.OnStartup(e);
        }
    }
}
