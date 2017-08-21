namespace Chess.ChessPieces
{
    using Contracts;
    using System.Collections.Generic;

    public class Rook : ChessPiece, IRook
    {
        private const char Symbol = 'R';

        public Rook()
        {
        }

        public Rook(IPosition position) : base(position)
        {
        }

        public override char GetCharacter()
        {
            return Symbol;
        }

        public override bool CanDoTheMove(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            if (this.IsTheMovementInAStraightLine(newCollumn, newRow) && 
                !this.IsThereAnAllyFigureOnTheNewPosition(newCollumn, newRow, chessPiecesBlack, chessPiecesWhite, turn) &&
                !this.IsThereAFigureBetweenTheNewPositionAndTheCurrentOneStraightLine(newCollumn, newRow, chessPiecesBlack, chessPiecesWhite))
            {
                return true;
            }

            return false;
        }

        public override void Move(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            base.Move(newCollumn, newRow, chessPiecesBlack, chessPiecesWhite, turn);
        }

        // This one must stay here
        private bool IsThereAFigureBetweenTheNewPositionAndTheCurrentOneStraightLine(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite)
        {
            bool result = false;

            foreach (IChessPiece whiteChessPiece in chessPiecesWhite)
            {
                int counterRows;
                int counterCollumns;
                if (newRow < this.Position.Row && newCollumn == this.Position.Collumn)
                {
                    counterRows = this.Position.Row;
                    counterCollumns = this.Position.Collumn;
                    while (counterRows != newRow)
                    {
                        if (whiteChessPiece is Rook)
                        {
                        }
                        else if (whiteChessPiece.Position.Row == counterRows && whiteChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterRows -= 1;
                    }
                }
                else if (newRow > this.Position.Row && newCollumn == this.Position.Collumn)
                {
                    counterRows = this.Position.Row;
                    counterCollumns = this.Position.Collumn;
                    while (counterRows != newRow)
                    {
                        if (whiteChessPiece is Rook)
                        {
                        }
                        else if (whiteChessPiece.Position.Row == counterRows && whiteChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterRows += 1;
                    }
                }
                else if (newRow == this.Position.Row && newCollumn > this.Position.Collumn)
                {
                    counterRows = this.Position.Row;
                    counterCollumns = this.Position.Collumn;
                    while (counterCollumns != newCollumn)
                    {
                        if (whiteChessPiece is Rook)
                        {
                        }
                        else if (whiteChessPiece.Position.Row == counterRows && whiteChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterCollumns += 1;
                    }
                }
                else if (newRow == this.Position.Row && newCollumn < this.Position.Collumn)
                {
                    counterRows = this.Position.Row;
                    counterCollumns = this.Position.Collumn;
                    while (counterCollumns != newCollumn)
                    {
                        if (whiteChessPiece is Rook)
                        {
                        }
                        else if (whiteChessPiece.Position.Row == counterRows && whiteChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterCollumns -= 1;
                    }
                }
            }

            foreach (IChessPiece blackChessPiece in chessPiecesBlack)
            {
                int counterRows;
                int counterCollumns;
                if (newRow < this.Position.Row && newCollumn == this.Position.Collumn)
                {
                    counterRows = this.Position.Row;
                    counterCollumns = this.Position.Collumn;
                    while (counterRows != newRow)
                    {
                        if (blackChessPiece is Rook)
                        {
                        }
                        else if (blackChessPiece.Position.Row == counterRows && blackChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterRows -= 1;
                    }
                }
                else if (newRow > this.Position.Row && newCollumn == this.Position.Collumn)
                {
                    counterRows = this.Position.Row;
                    counterCollumns = this.Position.Collumn;
                    while (counterRows != newRow)
                    {
                        if (blackChessPiece is Rook)
                        {
                        }
                        else if (blackChessPiece.Position.Row == counterRows && blackChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterRows += 1;
                    }
                }
                else if (newRow == this.Position.Row && newCollumn > this.Position.Collumn)
                {
                    counterRows = this.Position.Row;
                    counterCollumns = this.Position.Collumn;
                    while (counterCollumns != newCollumn)
                    {
                        if (blackChessPiece is Rook)
                        {
                        }
                        else if (blackChessPiece.Position.Row == counterRows && blackChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterCollumns += 1;
                    }
                }
                else if (newRow == this.Position.Row && newCollumn < this.Position.Collumn)
                {
                    counterRows = this.Position.Row;
                    counterCollumns = this.Position.Collumn;
                    while (counterCollumns != newCollumn)
                    {
                        if (blackChessPiece is Rook)
                        {
                        }
                        else if (blackChessPiece.Position.Row == counterRows && blackChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterCollumns -= 1;
                    }
                }
            }

            return result;
        }
    }
}
