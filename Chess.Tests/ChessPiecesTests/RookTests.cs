namespace Chess.Tests.ChessPiecesTests
{
    using System.Collections.Generic;
    using ChessPieces;
    using Contracts;
    using NUnit.Framework;

    [TestFixture]
    public class RookTests
    {
        [Test]
        public void CanDoTheMove_ShouldReturnTrue_WhenTheMovementIsInAStraightLineThereIsntAnAllyOnTheNewPositionAndThereIsntAFigureBetweenTheNewPositionAndTheCurrentOne()
        {
            bool expected = true;
            int turn = 0;
            int newCollumn = 2;
            int newRow = 6;
            IList<IChessPiece> blackPieces = this.OrderBlackPieces();
            IList<IChessPiece> whitePieces = this.OrderWhitePieces();
            whitePieces[8].Position = new Position(2, 5);
            IPosition positionForSut = new Position(2, 8);
            IChessPiece sut = new Rook(positionForSut);

            bool actual = sut.CanDoTheMove(newCollumn, newRow, blackPieces, whitePieces, turn);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanDoTheMove_ShouldReturnFalse_WhenTheMovementIsNotInAStraightLineThereIsntAnAllyOnTheNewPositionAndThereIsntAFigureBetweenTheNewPositionAndTheCurrentOne()
        {
            bool expected = false;
            int turn = 0;
            int newCollumn = 3;
            int newRow = 6;
            IList<IChessPiece> blackPieces = this.OrderBlackPieces();
            IList<IChessPiece> whitePieces = this.OrderWhitePieces();
            whitePieces[8].Position = new Position(2, 5);
            IPosition positionForSut = new Position(2, 8);
            IChessPiece sut = new Rook(positionForSut);

            bool actual = sut.CanDoTheMove(newCollumn, newRow, blackPieces, whitePieces, turn);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanDoTheMove_ShouldReturnFalse_WhenTheMovementIsInAStraightLineButThereIsAnAllyOnTheNewPositionAndThereIsntAFigureBetweenTheNewPositionAndTheCurrentOne()
        {
            bool expected = false;
            int turn = 0;
            int newCollumn = 2;
            int newRow = 7;
            IList<IChessPiece> blackPieces = this.OrderBlackPieces();
            IList<IChessPiece> whitePieces = this.OrderWhitePieces();
            IPosition positionForSut = new Position(2, 8);
            IChessPiece sut = new Rook(positionForSut);

            bool actual = sut.CanDoTheMove(newCollumn, newRow, blackPieces, whitePieces, turn);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CanDoTheMove_ShouldReturnFalse_WhenTheMovementIsInAStraightLineThereIsntAnAllyOnTheNewPositionButThereIsAFigureBetweenTheNewPositionAndTheCurrentOne()
        {
            bool expected = false;
            int turn = 0;
            int newCollumn = 2;
            int newRow = 6;
            IList<IChessPiece> blackPieces = this.OrderBlackPieces();
            IList<IChessPiece> whitePieces = this.OrderWhitePieces();
            IPosition positionForSut = new Position(2, 8);
            IChessPiece sut = new Rook(positionForSut);

            bool actual = sut.CanDoTheMove(newCollumn, newRow, blackPieces, whitePieces, turn);

            Assert.AreEqual(expected, actual);
        }

        private IList<IChessPiece> OrderWhitePieces()
        {
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
            IList<IChessPiece> chessPiecesWhite = new List<IChessPiece>
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

            return chessPiecesWhite;
        }

        private IList<IChessPiece> OrderBlackPieces()
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
            IList<IChessPiece> chessPiecesBlack = new List<IChessPiece>
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

            return chessPiecesBlack;
        }
    }
}
