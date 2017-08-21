namespace Chess
{
    using System;
    using System.Collections.Generic;
    using Chess.Contracts;

    public class CommandHandler : ICommandHandler
    {
        private IReader reader;
        private ILogger logger;

        public CommandHandler(IReader reader, ILogger logger)
        {
            this.Reader = reader;
            this.Logger = logger;
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Reader cannot be null");
                }

                this.reader = value;
            }
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

        public void HandleCommand(IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            string command = this.Reader.ReadLine();
            string[] commandTokens = command.Split(' ');

            string locationOfTheChessPieceToMove = commandTokens[0];
            int collumnOfThePieceToMove = this.GetCollumnFromLetter(locationOfTheChessPieceToMove[0]);
            int rowOfThePieceToMove = locationOfTheChessPieceToMove[1] - '0';

            string positionToMoveTo = commandTokens[1];
            int collumnOfTheNewPosition = this.GetCollumnFromLetter(positionToMoveTo[0]);
            int rowOfTheNewPosition = positionToMoveTo[1] - '0';

            if (turn == 0)
            {
                foreach (IChessPiece chessPiece in chessPiecesWhite)
                {
                    IPosition positionOfChessPiece = chessPiece.Position;
                    if (positionOfChessPiece.Collumn == collumnOfThePieceToMove && positionOfChessPiece.Row == rowOfThePieceToMove)
                    {
                        if (chessPiece.CanDoTheMove(collumnOfTheNewPosition, rowOfTheNewPosition, chessPiecesBlack, chessPiecesWhite, turn))
                        {
                            chessPiece.Move(collumnOfTheNewPosition, rowOfTheNewPosition, chessPiecesBlack, chessPiecesWhite, turn);
                        }
                        else
                        {
                            throw new InvalidOperationException("This white chess piece cannot move like that");
                        }
                    }
                }
            }
            else if (turn == 1)
            {
                foreach (IChessPiece chessPiece in chessPiecesBlack)
                {
                    IPosition positionOfChessPiece = chessPiece.Position;
                    if (positionOfChessPiece.Collumn == collumnOfThePieceToMove && positionOfChessPiece.Row == rowOfThePieceToMove)
                    {
                        if (chessPiece.CanDoTheMove(collumnOfTheNewPosition, rowOfTheNewPosition, chessPiecesBlack, chessPiecesWhite, turn))
                        {
                            chessPiece.Move(collumnOfTheNewPosition, rowOfTheNewPosition, chessPiecesBlack, chessPiecesWhite, turn);
                        }
                        else
                        {
                            throw new InvalidOperationException("This black chess piece cannot move like that");
                        }
                    }
                }
            }
        }

        private int GetCollumnFromLetter(char letter)
        {
            int result;

            switch (letter)
            {
                case 'A':
                    result = 2;
                    break;
                case 'B':
                    result = 3;
                    break;
                case 'C':
                    result = 4;
                    break;
                case 'D':
                    result = 5;
                    break;
                case 'E':
                    result = 6;
                    break;
                case 'F':
                    result = 7;
                    break;
                case 'G':
                    result = 8;
                    break;
                case 'H':
                    result = 9;
                    break;
                default:
                    throw new ArgumentException("Invalid letter");
            }

            return result;
        }
    }
}
