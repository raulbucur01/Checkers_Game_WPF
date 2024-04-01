namespace Checkers.Models
{
    public class NormalPiece : Piece
    {
        public override PieceType Type => PieceType.NormalPiece;
        public override Player Color { get; }

        public NormalPiece(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            NormalPiece copy = new NormalPiece(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
