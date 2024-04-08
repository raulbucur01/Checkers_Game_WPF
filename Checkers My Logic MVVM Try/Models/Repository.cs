using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Models
{
    public class Repository
    {
        private int _noRedWins { get; set; }
        private int _noBlackWins { get; set; }
        private int _maxWinnerPiecesRemaining { get; set; }

        private List<GameState> _games = new List<GameState>();

        public int NoRedWins
        {
            get { return _noRedWins; }
            set
            {
                _noRedWins = value;
                SaveStatistics();
            }
        }

        public int NoBlackWins
        {
            get { return _noBlackWins; }
            set
            {
                _noBlackWins = value;
                SaveStatistics();
            }
        }

        public int MaxWinnerPiecesRemaining
        {
            get { return _maxWinnerPiecesRemaining; }
            set
            {
                if (value > _maxWinnerPiecesRemaining)
                {
                    _maxWinnerPiecesRemaining = value;
                    SaveStatistics();
                }
            }
        }

        public Repository()
        {
            LoadStatistics();
            LoadGames();
        }

        private void LoadGames()
        {
            throw new NotImplementedException();
        }

        private void LoadStatistics()
        {
            StreamReader reader = new StreamReader("C:/MY_CODE/GitHubRepos/Checkers_Game_WPF/Checkers My Logic MVVM Try/Resources/statistics.txt");

            string redWins = reader.ReadLine();
            if (int.TryParse(redWins, out int redWinsInt))
            {
                _noRedWins = redWinsInt;
            }

            string blackWins = reader.ReadLine();
            if (int.TryParse(blackWins, out int blackWinsInt))
            {
                _noBlackWins = blackWinsInt;
            }

            string maxWinnerPieces = reader.ReadLine();
            if (int.TryParse(maxWinnerPieces, out int maxWinnerPiecesInt))
            {
                _maxWinnerPiecesRemaining = maxWinnerPiecesInt;
            }

            reader.Close();
        }

        private void SaveStatistics()
        {
            StreamWriter writer = new StreamWriter("C:/MY_CODE/GitHubRepos/Checkers_Game_WPF/Checkers My Logic MVVM Try/Resources/statistics.txt");

            writer.WriteLine(_noRedWins);
            writer.WriteLine(_noBlackWins);
            writer.WriteLine(_maxWinnerPiecesRemaining);

            writer.Close();
        }
    }
}
