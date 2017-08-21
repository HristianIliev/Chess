namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IBoardDrawer
    {
        ILogger Logger
        {
            get;
            set;
        }

        void DrawPlayingBoardWithPieces(IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite);
    }
}
