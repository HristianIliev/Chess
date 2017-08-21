namespace Chess.Tests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Providers;
    using Contracts;
    using ChessPieces;

    [TestFixture]
    public class BoardDrawerTests
    {
        [Test]
        public void Ctor_ShouldCorrectlyAssignLogger_WhenInvoked()
        {
            ILogger loggerStub = new Logger();

            IBoardDrawer sut = new BoardDrawer(loggerStub);

            Assert.AreNotEqual(null, sut.Logger);
        }

        [Test]
        public void Logger_ShouldThrowArgumentNullException_WhenCalledWithNullLogger()
        {
            ILogger logger = null;

            Assert.Throws<ArgumentNullException>(() => new BoardDrawer(logger));
        }

        [Test]
        public void Logger_ShouldNotThrowArgumentNullException_WhenCalledWithValidLogger()
        {
            ILogger logger = new Logger();

            Assert.DoesNotThrow(() => new BoardDrawer(logger));
        }

        [Test]
        public void Logger_ShouldCorrectlyAssignValue_WhenLoggerIsValid()
        {
            ILogger logger = new Logger();

            IBoardDrawer sut = new BoardDrawer(logger);

            Assert.AreEqual(sut.Logger, logger);
        }

        [Test]
        public void DrawPlayingBoardWithPieces_ShouldCallLoggerWriteCorrectTimes_WhenCalled()
        {
            int numberOfTimesLoggerWriteShouldBeCalled = 121;
            IList<IChessPiece> piecesForTheFirstPlayerStub = new List<IChessPiece>()
            {
                new Rook(new Position(2, 1))
            };
            IList<IChessPiece> piecesForTheSecondPlayerStub = new List<IChessPiece>()
            {
                new Rook(new Position(3, 2))
            };
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.WriteLine(It.IsAny<string>()));
            loggerMock.Setup(x => x.Write(It.IsAny<string>()));
            IBoardDrawer sut = new BoardDrawer(loggerMock.Object);

            sut.DrawPlayingBoardWithPieces(piecesForTheFirstPlayerStub, piecesForTheSecondPlayerStub);

            loggerMock.Verify(x => x.Write(It.IsAny<string>()), Times.Exactly(numberOfTimesLoggerWriteShouldBeCalled));
        }

        [Test]
        public void DrawPlayingBoardWithPieces_ShouldCallLoggerWriteLineCorrectTimes_WhenCalled()
        {
            int numberOfTimesLoggerWriteLineShouldBeCalled = 12;
            IList<IChessPiece> piecesForTheFirstPlayerStub = new List<IChessPiece>()
            {
                new Rook(new Position(3, 2))
            };
            IList<IChessPiece> piecesForTheSecondPlayerStub = new List<IChessPiece>()
            {
                new Rook(new Position(1, 2))
            };
            var loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.WriteLine(It.IsAny<string>()));
            loggerMock.Setup(x => x.Write(It.IsAny<string>()));
            IBoardDrawer sut = new BoardDrawer(loggerMock.Object);

            sut.DrawPlayingBoardWithPieces(piecesForTheFirstPlayerStub, piecesForTheSecondPlayerStub);

            loggerMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(numberOfTimesLoggerWriteLineShouldBeCalled));
        }
    }
}
