namespace Chess.ChessPieces
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Queen : ChessPiece, IQueen
    {
        private const char Symbol = 'Q';

        public Queen()
        {
        }

        public Queen(IPosition position) : base(position)
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
            else if (this.IsTheMovementInAStraightLine(newCollumn, newRow) &&
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
                        if (whiteChessPiece is Queen)
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
                        if (whiteChessPiece is Queen)
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
                        if (whiteChessPiece is Queen)
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
                        if (whiteChessPiece is Queen)
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
                        if (blackChessPiece is Queen)
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
                        if (blackChessPiece is Queen)
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
                        if (blackChessPiece is Queen)
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
                        if (blackChessPiece is Queen)
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
