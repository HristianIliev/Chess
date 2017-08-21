namespace Chess.ChessPieces
{
    using System.Collections.Generic;
    using Contracts;

    public class Bishop : ChessPiece, IBishop
    {
        private const char Symbol = 'B';

        public Bishop()
        {
        }

        public Bishop(IPosition position) : base(position)
        {
        }

        public override char GetCharacter()
        {
            return Symbol;
        }

        public override bool CanDoTheMove(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            if (this.IsTheMovementDiagonal(newCollumn, newRow) && 
                !this.IsThereAFigureBetweenTheNewPositionAndTheCurrentOneDiagonal(newCollumn, newRow, chessPiecesBlack, chessPiecesWhite) && 
                !this.IsThereAnAllyFigureOnTheNewPosition(newCollumn, newRow, chessPiecesBlack, chessPiecesWhite, turn))
            {
                return true;
            }

            return false;
        }

        public override void Move(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            base.Move(newCollumn, newRow, chessPiecesBlack, chessPiecesWhite, turn);
        }
    }
}