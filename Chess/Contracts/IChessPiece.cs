namespace Chess.Contracts
{
    using System.Collections.Generic;

    public interface IChessPiece
    {
        IPosition Position
        {
            get;
            set;
        }

        char GetCharacter();

        bool CanDoTheMove(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn);

        void Move(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn);

        string CheckIfCheck(int turn, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite);
    }
}