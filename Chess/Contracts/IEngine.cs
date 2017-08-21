namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IEngine
    {
        bool Checkmate
        {
            get;
            set;
        }

        IList<IChessPiece> ChessPiecesBlack
        {
            get;
            set;
        }

        IList<IChessPiece> ChessPiecesWhite
        {
            get;
            set;
        }

        void StartGame(ILogger logger, IReader reader);
    }
}
