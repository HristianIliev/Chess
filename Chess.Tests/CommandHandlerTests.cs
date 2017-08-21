namespace Chess.Tests
{
    using System;
    using System.Collections.Generic;
    using ChessPieces;
    using Contracts;
    using Moq;
    using NUnit.Framework;
    using Providers;

    [TestFixture]
    public class CommandHandlerTests
    {
        [Test]
        public void Ctor_ShouldCorrectlyAssignValues_WhenInvoked()
        {
            var readerStub = new Mock<IReader>();
            var loggerStub = new Mock<ILogger>();

            ICommandHandler commandHandler = new CommandHandler(readerStub.Object, loggerStub.Object);

            Assert.AreEqual(commandHandler.Reader, readerStub.Object);
        }

        [Test]
        public void Reader_ShouldThrowArgumentNullException_WhenReaderIsNull()
        {
            IReader reader = null;
            var loggerStub = new Mock<ILogger>();

            Assert.Throws<ArgumentNullException>(() => new CommandHandler(reader, loggerStub.Object));
        }

        [Test]
        public void Reader_ShouldNotThrowArgumentNullException_WhenReaderIsValid()
        {
            IReader reader = new Reader();
            var loggerStub = new Mock<ILogger>();

            Assert.DoesNotThrow(() => new CommandHandler(reader, loggerStub.Object));
        }

        [Test]
        public void Reader_ShouldCorrectlyAssignValue_WhenReaderIsValid()
        {
            IReader reader = new Reader();
            var loggerStub = new Mock<ILogger>();

            ICommandHandler sut = new CommandHandler(reader, loggerStub.Object);

            Assert.AreEqual(sut.Reader, reader);
        }

        [Test]
        public void Logger_ShouldThrowArgumentNullException_WhenCalledWithNullLogger()
        {
            var readerStub = new Mock<IReader>();
            ILogger logger = null;

            Assert.Throws<ArgumentNullException>(() => new CommandHandler(readerStub.Object, logger));
        }

        [Test]
        public void Logger_ShouldNotThrowArgumentNullException_WhenCalledWithValidLogger()
        {
            var readerStub = new Mock<IReader>();
            ILogger logger = new Logger();

            Assert.DoesNotThrow(() => new CommandHandler(readerStub.Object, logger));
        }

        [Test]
        public void Logger_ShouldCorrectlyAssignValue_WhenLoggerIsValid()
        {
            var readerStub = new Mock<IReader>();
            ILogger logger = new Logger();

            ICommandHandler sut = new CommandHandler(readerStub.Object, logger);

            Assert.AreEqual(sut.Logger, logger);
        }

        [Test]
        public void HandleCommand_ShouldCallReaderOneTime_WhenCalled()
        {
            var readerMock = new Mock<IReader>();
            readerMock.Setup(x => x.ReadLine()).Returns("A7 A5");
            var loggerStub = new Mock<ILogger>();
            IList<IChessPiece> chessPiecesBlackStub = new List<IChessPiece>();
            IList<IChessPiece> chessPiecesWhiteStub = new List<IChessPiece> { new Pawn(new Position(2, 7)) };
            ICommandHandler sut = new CommandHandler(readerMock.Object, loggerStub.Object);
            int turn = 2;

            sut.HandleCommand(chessPiecesBlackStub, chessPiecesWhiteStub, turn);

            readerMock.Verify(x => x.ReadLine(), Times.Once());
        }

        [Test]
        public void HandleCommand_ShouldThrowInvalidOperationException_WhenCalledWithCommandWithInvalidWhtieChessPiece()
        {
            var readerStub = new Mock<IReader>();
            readerStub.Setup(x => x.ReadLine()).Returns("A7 A4");
            var loggerStub = new Mock<ILogger>();
            IList<IChessPiece> chessPiecesBlackStub = new List<IChessPiece>
            {
            };
            IList<IChessPiece> chessPiecesWhiteStub = new List<IChessPiece> { new Pawn(new Position(2, 7)) };
            ICommandHandler sut = new CommandHandler(readerStub.Object, loggerStub.Object);
            int turn = 0;
            string expectedMessage = "This white chess piece cannot move like that";

            Exception ex = Assert.Catch<InvalidOperationException>(() => sut.HandleCommand(chessPiecesBlackStub, chessPiecesWhiteStub, turn));

            StringAssert.Contains(expectedMessage, ex.Message);
        }

        [Test]
        public void HandleCommand_ShouldThrowInvalidOperationException_WhenCalledWithCommandWithInvalidBlackChessPiece()
        {
            var readerStub = new Mock<IReader>();
            readerStub.Setup(x => x.ReadLine()).Returns("A7 A4");
            var loggerStub = new Mock<ILogger>();
            IList<IChessPiece> chessPiecesBlackStub = new List<IChessPiece> { new Pawn(new Position(2, 7)) };
            IList<IChessPiece> chessPiecesWhiteStub = new List<IChessPiece> { };
            ICommandHandler sut = new CommandHandler(readerStub.Object, loggerStub.Object);
            int turn = 1;
            string expectedMessage = "This black chess piece cannot move like that";

            Exception ex = Assert.Catch<InvalidOperationException>(() => sut.HandleCommand(chessPiecesBlackStub, chessPiecesWhiteStub, turn));

            StringAssert.Contains(expectedMessage, ex.Message);
        }
    }
}
