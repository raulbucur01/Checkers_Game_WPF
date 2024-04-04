using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Checkers.Models
{
    public static class Images
    {
        private static readonly Dictionary<PieceType, ImageSource> blackSources = new Dictionary<PieceType, ImageSource>()
        {
            { PieceType.BlackPiece, LoadImage("/Assets/BlackPiece.png") },
            { PieceType.King, LoadImage("/Assets/KingB.png") }
        };

        private static readonly Dictionary<PieceType, ImageSource> redSources = new Dictionary<PieceType, ImageSource>()
        {
            { PieceType.RedPiece, LoadImage("/Assets/RedPiece.png") },
            { PieceType.King, LoadImage("/Assets/KingR.png") }
        };

        private static ImageSource LoadImage(string filePath)
        {
            return new BitmapImage(new Uri(filePath, UriKind.Relative));
        }

        public static ImageSource GetImage(Player color, PieceType type)
        {
            if (color == Player.Red)
            {
                return redSources[type];
            }
            else if (color == Player.Black)
                    return blackSources[type];
            
            return null;
        }

        public static ImageSource GetImage(Piece piece)
        {
            if (piece == null)
                return null;

            return GetImage(piece.Color, piece.Type);
        }
    }
}
