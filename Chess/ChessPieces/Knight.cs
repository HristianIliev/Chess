namespace Chess.ChessPieces
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Knight : ChessPiece, IKnight
    {
        private const char Symbol = 'H';

        public Knight()
        {
        }

        public Knight(IPosition position) : base(position)
        {
        }

        public override char GetCharacter()
        {
            return Symbol;
        }

        public override bool CanDoTheMove(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            if (this.IsTheNewPositionOnG(newCollumn, newRow) && !this.IsThereAnAllyFigureOnTheNewPosition(newCollumn, newRow, chessPiecesBlack, chessPiecesWhite, turn))
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