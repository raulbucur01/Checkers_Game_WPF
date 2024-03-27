using System;
using System.Collections.Generic;

namespace Checkers.Models
{
    public class Board
    {
        private List<List<Piece>> squares;

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            squares = new List<List<Piece>>(rows);
            for (int i = 0; i < rows; i++)
            {
                squares.Add(new List<Piece>(columns));
                for (int j = 0; j < columns; j++)
                {
                    squares[i].Add(null);
                }
            }

            // put white pieces
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if ((row + col) % 2 == 1)
                    {
                        squares[row][col] = new Piece(PieceColor.White);
                    }
                }
            }

            // put black pieces 
            for (int row = 5; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if ((row + col) % 2 == 1)
                    {
                        squares[row][col] = new Piece(PieceColor.Black);
                    }
                }
            }
        }

        public void ResetBoard()
        {
            foreach (var row in squares)
            {
                for (int col = 0; col < Columns; col++)
                {
                    row[col] = null;
                }
            }

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if ((row + col) % 2 == 1)
                    {
                        squares[row][col] = new Piece(PieceColor.White);
                    }
                }
            }

            for (int row = 5; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if ((row + col) % 2 == 1)
                    {
                        squares[row][col] = new Piece(PieceColor.Black);
                    }
                }
            }
        }


        public Piece GetPiece(int row, int col)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns)
                throw new ArgumentOutOfRangeException("Invalid row or column");

            return squares[row][col];
        }

        public void ForcedPlacePiece(Piece piece, int row, int col)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns)
                throw new ArgumentOutOfRangeException("Invalid row or column");

            squares[row][col] = piece;
        }
    }
}
