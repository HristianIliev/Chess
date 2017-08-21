namespace Chess.ChessPieces
{
    using System.Collections.Generic;
    using Contracts;

    public class Pawn : ChessPiece, IPawn
    {
        private const char Symbol = 'P';

        public Pawn()
        {
        }

        public Pawn(IPosition position) : base(position)
        {
        }

        public override char GetCharacter()
        {
            return Symbol;
        }

        public override bool CanDoTheMove(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            if (this.IsTheNewPositionDiagonaly(newCollumn, newRow, turn) && 
                this.IsThereAnEnemyFigureOnTheNewPosition(newCollumn, newRow, chessPiecesBlack, chessPiecesWhite, turn))
            {
                return true;
            }
            else if (this.IsAtStartingPosition(turn) && 
                     this.IsStraightLinePawn(newCollumn) && 
                     this.IsTheNewPositionTwoBlocksAway(newRow, turn) && 
                     !this.IsThereAFigureBetweenTheNewPositionAndTheCurrentOnePawn(newCollumn, newRow, chessPiecesBlack, chessPiecesWhite, turn))
            {
                return true;
            }
            else if (this.IsStraightLinePawn(newCollumn) && 
                     this.IsTheNewPositionOneBlockAwayPawn(newRow, turn) && 
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
