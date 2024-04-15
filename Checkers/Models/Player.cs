using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public enum Player
    {
        None,
        Red,
        Black
    }

    public static class PlayerExtenstions
    {
        public static Player Opponent(this Player player)
        {
            switch (player)
            {
                case Player.Red:
                    return Player.Black;
                case Player.Black:
                    return Player.Red;
                default:
                    return Player.None;
            }
        }
    }
}
