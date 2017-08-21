namespace Chess
{
    using System;
    using System.Collections.Generic;
    using ChessPieces;
    using Contracts;
    using Providers;

    public class Engine : IEngine
    {
        private bool checkmate;
        private IList<IChessPiece> chessPiecesBlack;
        private IList<IChessPiece> chessPiecesWhite;

        public Engine()
        {
        }

        public IList<IChessPiece> ChessPiecesBlack
        {
            get
            {
                return this.chessPiecesBlack;
            }

            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException("The pieces of the first player cannot be empty");
                }

                this.chessPiecesBlack = value;
            }
        }

        public IList<IChessPiece> ChessPiecesWhite
        {
            get
            {
                return this.chessPiecesWhite;
            }

            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentNullException("The pieces of the second player cannot be empty");
                }

                this.chessPiecesWhite = value;
            }
        }
       
        public bool Checkmate
        {
            get
            {
                return this.checkmate;
            }

            set
            {
                this.checkmate = value;
            }
        }

        public void StartGame(ILogger logger, IReader reader)
        {
            int turn = 0;
            this.OrderPiecesAtTheStart();
            while (this.Checkmate != true)
            {              
                IBoardDrawer boardDrawerForTheGame = new BoardDrawer(logger);
                boardDrawerForTheGame.DrawPlayingBoardWithPieces(this.ChessPiecesBlack, this.ChessPiecesWhite);

                ICommandHandler commandHandler = new CommandHandler(reader, logger);
                commandHandler.HandleCommand(this.ChessPiecesBlack, this.ChessPiecesWhite, turn);

                bool hasAKing = false;
                if (turn == 0)
                {
                    foreach (IChessPiece blackPiece in this.ChessPiecesBlack)
                    {
                        if (blackPiece is IKing)
                        {
                            hasAKing = true;
                        }

                        if (blackPiece.CheckIfCheck(turn, this.ChessPiecesBlack, this.ChessPiecesWhite) == "Check")
                        {
                            logger.WriteLine("Black king is check! Move it!");
                        }
                    }

                    if (hasAKing == false)
                    {
                        this.Checkmate = true;
                        logger.WriteLine("White wins");
                        break;
                    }

                    turn = 1;
                }
                else if (turn == 1)
                {
                    foreach (IChessPiece whitePiece in this.ChessPiecesWhite)
                    {
                        if (whitePiece is IKing)
                        {
                            hasAKing = true;
                        }

                        if (whitePiece.CheckIfCheck(turn, this.ChessPiecesBlack, this.ChessPiecesWhite) == "Check")
                        {
                            logger.WriteLine("White king is check! Move it!");
                        }
                    }

                    if (hasAKing == false)
                    {
                        this.Checkmate = true;
                        logger.WriteLine("Black wins");
                        break;
                    }

                    turn = 0;
                }
            }
        }

        private void OrderPiecesAtTheStart()
        {
            IRook leftBlackRook = new Rook(new Position(2, 1));
            IKnight leftBlackKnight = new Knight(new Position(3, 1));
            IBishop leftBlackBishop = new Bishop(new Position(4, 1));
            IQueen queenBlack = new Queen(new Position(5, 1));
            IKing kingBlack = new King(new Position(6, 1));
            IBishop rightBlackBishop = new Bishop(new Position(7, 1));
            IKnight rightBlackKnight = new Knight(new Position(8, 1));
            IRook rightBlackRook = new Rook(new Position(9, 1));
            IPawn pawnBlack1 = new Pawn(new Position(2, 2));
            IPawn pawnBlack2 = new Pawn(new Position(3, 2));
            IPawn pawnBlack3 = new Pawn(new Position(4, 2));
            IPawn pawnBlack4 = new Pawn(new Position(5, 2));
            IPawn pawnBlack5 = new Pawn(new Position(6, 2));
            IPawn pawnBlack6 = new Pawn(new Position(7, 2));
            IPawn pawnBlack7 = new Pawn(new Position(8, 2));
            IPawn pawnBlack8 = new Pawn(new Position(9, 2));
            this.ChessPiecesBlack = new List<IChessPiece>
            {
                leftBlackRook,
                leftBlackKnight,
                leftBlackBishop,
                queenBlack,
                kingBlack,
                rightBlackBishop,
                rightBlackKnight,
                rightBlackRook,
                pawnBlack1,
                pawnBlack2,
                pawnBlack3,
                pawnBlack4,
                pawnBlack5,
                pawnBlack6,
                pawnBlack7,
                pawnBlack8
            };

            IRook leftWhiteRook = new Rook(new Position(2, 8));
            IKnight leftWhiteKnight = new Knight(new Position(3, 8));
            IBishop leftWhiteBishop = new Bishop(new Position(4, 8));
            IQueen queenWhite = new Queen(new Position(5, 8));
            IKing kingWhite = new King(new Position(6, 8));
            IBishop rightWhiteBishop = new Bishop(new Position(7, 8));
            IKnight rightWhiteKnight = new Knight(new Position(8, 8));
            IRook rightWhiteRook = new Rook(new Position(9, 8));
            IPawn pawnWhite1 = new Pawn(new Position(2, 7));
            IPawn pawnWhite2 = new Pawn(new Position(3, 7));
            IPawn pawnWhite3 = new Pawn(new Position(4, 7));
            IPawn pawnWhite4 = new Pawn(new Position(5, 7));
            IPawn pawnWhite5 = new Pawn(new Position(6, 7));
            IPawn pawnWhite6 = new Pawn(new Position(7, 7));
            IPawn pawnWhite7 = new Pawn(new Position(8, 7));
            IPawn pawnWhite8 = new Pawn(new Position(9, 7));
            this.ChessPiecesWhite = new List<IChessPiece>
            {
                leftWhiteRook,
                leftWhiteKnight,
                leftWhiteBishop,
                queenWhite,
                kingWhite,
                rightWhiteBishop,
                rightWhiteKnight,
                rightWhiteRook,
                pawnWhite1,
                pawnWhite2,
                pawnWhite3,
                pawnWhite4,
                pawnWhite5,
                pawnWhite6,
                pawnWhite7,
                pawnWhite8
            };
        }
    }
}
