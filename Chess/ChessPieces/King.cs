namespace Chess.ChessPieces
{
    using Contracts;
    using System.Collections.Generic;

    public class King : ChessPiece, IKing
    {
        private const char Symbol = 'K';

        public King()
        {
        }

        public King(IPosition position) : base(position)
        {
        }

        public override char GetCharacter()
        {
            return Symbol;
        }

        public override bool CanDoTheMove(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            if (this.IsTheNewPositionOneBlockAway(newCollumn, newRow) && !this.IsThereAnAllyFigureOnTheNewPosition(newCollumn, newRow, chessPiecesBlack, chessPiecesWhite, turn))
            {
                return true;
            }

            return false;
        }

        public override void Move(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            base.Move(newCollumn, newRow, chessPiecesBlack, chessPiecesWhite, turn);
        }

        public override string CheckIfCheck(int turn, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite)
        {
            if (turn == 0)
            {
                foreach (IChessPiece whitePiece in chessPiecesWhite)
                {
                    if (whitePiece.CanDoTheMove(this.Position.Collumn, this.Position.Row, chessPiecesBlack, chessPiecesWhite, 0))
                    {
                        return "Check";
                    }
                }
            }
            else if (turn == 1)
            {
                foreach (IChessPiece blackPiece in chessPiecesBlack)
                {
                    if (blackPiece.CanDoTheMove(this.Position.Collumn, this.Position.Row, chessPiecesBlack, chessPiecesWhite, 1))
                    {
                        return "Check";
                    }
                }
            }

            return "Not check";
        }
    }
}
