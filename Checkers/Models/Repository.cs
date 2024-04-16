﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Checkers.Models
{
    public class Repository
    {
        private int _noRedWins;
        private int _noBlackWins;
        private int _maxWinnerPiecesRemaining;

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
        }

        private void LoadStatistics()
        {
            string path = Path.GetFullPath("./Resources/statistics.txt");
            string substringToRemove = "\\bin\\Debug";
            string relativePath = path.Replace(substringToRemove, "");
            StreamReader reader = new StreamReader(Path.GetFullPath(relativePath));

            string redWins = reader.ReadLine();
            if (int.TryParse(redWins, out int redWinsInt))
            {
                NoRedWins = redWinsInt;
            }

            string blackWins = reader.ReadLine();
            if (int.TryParse(blackWins, out int blackWinsInt))
            {
                NoBlackWins = blackWinsInt;
            }

            string maxWinnerPieces = reader.ReadLine();
            if (int.TryParse(maxWinnerPieces, out int maxWinnerPiecesInt))
            {
                MaxWinnerPiecesRemaining = maxWinnerPiecesInt;
            }

            reader.Close();
        }

        private void SaveStatistics()
        {
            //string path = Path.GetFullPath("./Resources/statistics.txt");
            //string substringToRemove = "\\bin\\Debug";
            //string relativePath = path.Replace(substringToRemove, "");
            //StreamWriter writer = new StreamWriter(Path.GetFullPath(relativePath));

            StreamWriter writer = new StreamWriter("C:/MY_CODE/GitHubRepos/Checkers_Game_WPF/Checkers/Resources/statistics.txt");

            writer.WriteLine(NoRedWins);
            writer.WriteLine(NoBlackWins);
            writer.WriteLine(MaxWinnerPiecesRemaining);

            writer.Close();
        }

        // codification: red piece: 1, red king: 2, black piece: 3, black king: 4, blank space: 0
        public void SaveGameToFile(string filePath, GameState gameState)
        {
            StreamWriter writer = new StreamWriter(filePath);

            Board board = gameState.Board;

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (board[r, c] == null)
                    {
                        writer.Write("0");
                    }
                    else if (board[r, c].Type == PieceType.RedPiece)
                    {
                        writer.Write("1");
                    }
                    else if (board[r, c].Type == PieceType.King && board[r, c].Color == Player.Red)
                    {
                        writer.Write("2");
                    }
                    else if (board[r, c].Type == PieceType.BlackPiece)
                    {
                        writer.Write("3");
                    }
                    else if (board[r, c].Type == PieceType.King && board[r, c].Color == Player.Black)
                    {
                        writer.Write("4");
                    }
                }

                writer.Write("\n");
            }

            writer.Write($"{gameState.CurrentPlayer}\n");
            writer.Write($"{gameState.MultipleJumpAllowed}\n");

            writer.Close();
        }

        public GameState LoadGameFromFile(string filename)
        {
            StreamReader reader = new StreamReader(filename);

            Board board = new Board();
            for (int r = 0; r < 8; r++)
            {
                string line = reader.ReadLine();

                for (int c = 0; c < 8; c++)
                {
                    char inputC = line[c];

                    switch (inputC)
                    {
                        case '1':
                            board[r, c] = new RedPiece(Player.Red);
                            break;

                        case '2':
                            board[r, c] = new King(Player.Red);
                            break;

                        case '3':
                            board[r, c] = new BlackPiece(Player.Black);
                            break;

                        case '4':
                            board[r, c] = new King(Player.Black);
                            break;

                        default:
                            break;
                    }
                }
            }

            string crtPlayerString = reader.ReadLine();
            Player crtPlayer = crtPlayerString == "Red" ? Player.Red : Player.Black; 

            string multipleJumpAllowedString = reader.ReadLine();
            bool multipleJumpAllowed = multipleJumpAllowedString == "True" ? true : false;

            GameState newGameState = new GameState(crtPlayer, board, multipleJumpAllowed);

            reader.Close();

            return newGameState;
        }
    }
}
