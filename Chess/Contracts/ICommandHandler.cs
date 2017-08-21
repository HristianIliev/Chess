namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface ICommandHandler
    {
        IReader Reader
        {
            get;
            set;
        }

        ILogger Logger
        {
            get;
            set;
        }

        void HandleCommand(IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn);
    }
}
