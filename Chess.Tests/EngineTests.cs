namespace Chess.Tests
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using NUnit.Framework;
    using ChessPieces;

    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void ChessPiecesBlack_ShouldThrowArgumentNullException_WhenCalledWithNull()
        {
            IEngine sut = new Engine();

            Assert.Throws<ArgumentNullException>(() => sut.ChessPiecesBlack = null);
        }

        [Test]
        public void ChessPiecesBlack_ShouldNotThrowArgumentNullException_WhenCalledWithValidValue()
        {
            IEngine sut = new Engine();

            Assert.DoesNotThrow(() => sut.ChessPiecesBlack = new List<IChessPiece>
            {
                new Rook(new Position(3, 1))
            });
        }

        [Test]
        public void ChessPiecesBlack_ShouldCorrectlyAssignValue_WhenValueIsValid()
        {
            IList<IChessPiece> chessPiecesBlack = new List<IChessPiece>
            {
                new Rook(new Position(3, 1))
            };
            IEngine sut = new Engine();

            sut.ChessPiecesBlack = chessPiecesBlack;

            Assert.AreEqual(sut.ChessPiecesBlack, chessPiecesBlack);
        }

        [Test]
        public void ChessPiecesWhite_ShouldThrowArgumentNullException_WhenCalledWithNull()
        {
            IEngine sut = new Engine();

            Assert.Throws<ArgumentNullException>(() => sut.ChessPiecesWhite = null);
        }

        [Test]
        public void ChessPiecesWhite_ShouldNotThrowArgumentNullException_WhenCalledWithValidValue()
        {
            IEngine sut = new Engine();

            Assert.DoesNotThrow(() => sut.ChessPiecesWhite = new List<IChessPiece>
            {
                new Rook(new Position(3, 1))
            });
        }

        [Test]
        public void ChessPiecesWhite_ShouldCorrectlyAssignValue_WhenValueIsValid()
        {
            IList<IChessPiece> chessPiecesWhite = new List<IChessPiece>
            {
                new Rook(new Position(3, 1))
            };
            IEngine sut = new Engine();

            sut.ChessPiecesWhite = chessPiecesWhite;

            Assert.AreEqual(sut.ChessPiecesWhite, chessPiecesWhite);
        }
    }
}
