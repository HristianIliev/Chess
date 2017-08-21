namespace Chess
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class BoardDrawer : IBoardDrawer
    {
        private ILogger logger;

        public BoardDrawer(ILogger logger)
        {
            this.Logger = logger;
        }

        public ILogger Logger
        {
            get
            {
                return this.logger;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Logger cannot be null");
                }

                this.logger = value;
            }
        }

        public void DrawPlayingBoardWithPieces(IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite)
        {
            char[,] boardWithoutPieces = this.DrawPlayingBoardWithoutPieces();

            char[,] boardWithPieces = this.InsertPieces(boardWithoutPieces, chessPiecesBlack, chessPiecesWhite);

            for (int row = 0; row < boardWithPieces.GetLength(0); row++)
            {
                for (int col = 0; col < boardWithPieces.GetLength(1); col++)
                {
                    this.Logger.Write(boardWithPieces[row, col].ToString()); 
                }

                this.Logger.WriteLine(string.Empty);
            }

            this.Logger.WriteLine("What is your next move?");
        }

        private char[,] DrawPlayingBoardWithoutPieces()
        {
            char[,] boardWithoutPieces = new char[11, 11];
            string letters = "11ABCDEFGH";
            string numbers = "12345678";
            for (int row = 0; row < boardWithoutPieces.GetLength(0); row++)
            {
                for (int col = 0; col < boardWithoutPieces.GetLength(1); col++)
                {
                    if (col == 1 || col == 10)
                    {
                        if (row == 0 || row >= 9)
                        {
                            continue;
                        }

                        boardWithoutPieces[row, col] = '|';
                    }

                    if (row == 0 || row == 9)
                    {
                        if (col == 0 || col == 1 || col == 11)
                        {
                            continue;
                        }

                        boardWithoutPieces[row, col] = '-';
                    }

                    if (col == 0)
                    {
                        if (row == 0 || row > 8)
                        {
                            continue;
                        }

                        boardWithoutPieces[row, col] = numbers[row - 1]; 
                    }

                    if (row == 10)
                    {
                        if (col < 2 || col > 9)
                        {
                            continue;
                        }

                        boardWithoutPieces[row, col] = letters[col];
                    }
                }
            }

            return boardWithoutPieces;
        }

        private char[,] InsertPieces(char[,] boardWithoutPieces, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite)
        {
            foreach (IChessPiece blackChessPiece in chessPiecesBlack)
            {
                IPosition positionForTheBoard = blackChessPiece.Position;
                int row = positionForTheBoard.Row;
                int col = positionForTheBoard.Collumn;
                string characterOfPiece = blackChessPiece.GetCharacter().ToString().ToLower();

                boardWithoutPieces[row, col] = char.Parse(characterOfPiece);
            }

            foreach (IChessPiece whiteChessPiece in chessPiecesWhite)
            {
                IPosition positionForTheBoard = whiteChessPiece.Position;
                int row = positionForTheBoard.Row;
                int col = positionForTheBoard.Collumn;

                boardWithoutPieces[row, col] = whiteChessPiece.GetCharacter();
            }

            return boardWithoutPieces;
        }
    }
}
