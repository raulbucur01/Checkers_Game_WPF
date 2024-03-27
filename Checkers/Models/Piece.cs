namespace Checkers.Models
{
    public enum PieceColor { Black, White }

    public class Piece
    {
        public Piece(PieceColor color, bool isKing=false)
        {
            Color = color;
            IsKing = isKing;
        }

        public PieceColor Color { get; }
        public bool IsKing { get; set; }
    }
}
