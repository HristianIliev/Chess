namespace Chess
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class ChessPiece : IChessPiece
    {
        private IPosition position;

        public ChessPiece()
        {
        }

        public ChessPiece(IPosition position)
        {
            this.Position = position;
        }

        public IPosition Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
            }
        }

        public virtual bool CanDoTheMove(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            throw new NotImplementedException();
        }

        public IPosition GetPosition()
        {
            return this.Position;
        }

        public virtual char GetCharacter()
        {
            throw new NotImplementedException();
        }

        public virtual void Move(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            if (this.IsThereAnEnemyFigureOnTheNewPosition(newCollumn, newRow, chessPiecesBlack, chessPiecesWhite, turn))
            {
                if (turn == 0)
                {
                    chessPiecesBlack.Remove(chessPiecesBlack.FirstOrDefault(x => x.Position.Row == newRow && x.Position.Collumn == newCollumn));
                }
                else if (turn == 1)
                {
                    chessPiecesWhite.Remove(chessPiecesWhite.FirstOrDefault(x => x.Position.Row == newRow && x.Position.Collumn == newCollumn));
                }
            }

            this.Position.Collumn = newCollumn;
            this.Position.Row = newRow;
        }

        public virtual string CheckIfCheck(int turn, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite)
        {
            return "not a king";
        }

        protected bool IsTheMovementInAStraightLine(int newCollumn, int newRow)
        {
            if (newRow == this.Position.Row && newCollumn != this.Position.Collumn)
            {
                return true;
            }
            else if (newRow != this.Position.Row && newCollumn == this.Position.Collumn)
            {
                return true;
            }

            return false;
        }

        protected bool IsThereAFigureBetweenTheNewPositionAndTheCurrentOnePawn(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            bool result = false;

            if (turn == 0)
            {
                foreach (IChessPiece whiteChessPiece in chessPiecesWhite)
                {
                    int counterRows = this.Position.Row - 1;
                    while (counterRows != newRow)
                    {
                        if (whiteChessPiece.Position.Row == counterRows && whiteChessPiece.Position.Collumn == this.Position.Collumn)
                        {
                            result = true;
                        }

                        counterRows -= 1;
                    }
                }

                foreach (IChessPiece blackChessPiece in chessPiecesBlack)
                {
                    int counterRows = this.Position.Row - 1;
                    while (counterRows != newRow)
                    {
                        if (blackChessPiece.Position.Row == counterRows && blackChessPiece.Position.Collumn == this.Position.Collumn)
                        {
                            result = true;
                        }

                        counterRows -= 1;
                    }
                }
            }
            else if (turn == 1)
            {
                foreach (IChessPiece blackChessPiece in chessPiecesBlack)
                {
                    int counterRows = this.Position.Row + 1;
                    while (counterRows != newRow)
                    {
                        if (blackChessPiece.Position.Row == counterRows && blackChessPiece.Position.Collumn == this.Position.Collumn)
                        {
                            result = true;
                        }

                        counterRows += 1;
                    }
                }

                foreach (IChessPiece whiteChessPiece in chessPiecesWhite)
                {
                    int counterRows = this.Position.Row + 1;
                    while (counterRows != newRow)
                    {
                        if (whiteChessPiece.Position.Row == counterRows && whiteChessPiece.Position.Collumn == this.Position.Collumn)
                        {
                            result = true;
                        }

                        counterRows += 1;
                    }
                }
            }

            return result;
        }

        protected bool IsTheNewPositionOneBlockAwayPawn(int newRow, int turn)
        {
            if (turn == 0)
            {
                if (newRow == this.Position.Row - 1)
                {
                    return true;
                }
            }

            if (turn == 1)
            {
                if (newRow == this.Position.Row + 1)
                {
                    return true;
                }
            }

            return false;
        }

        protected bool IsTheNewPositionTwoBlocksAway(int newRow, int turn)
        {
            if (turn == 0)
            {
                if (newRow == this.Position.Row - 2)
                {
                    return true;
                }
            }

            if (turn == 1)
            {
                if (newRow == this.Position.Row + 2)
                {
                    return true;
                }
            }

            return false;
        }

        protected bool IsAtStartingPosition(int turn)
        {
            if (turn == 0)
            {
                if (this.Position.Row == 7)
                {
                    return true;
                }

                return false;
            }
            else if (turn == 1)
            {
                if (this.Position.Row == 2)
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        protected bool IsTheNewPositionDiagonaly(int newCollumn, int newRow, int turn)
        {
            if (turn == 0)
            {
                if ((newCollumn == this.Position.Collumn - 1 || newCollumn == this.Position.Collumn + 1) && newRow == this.Position.Row - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if ((newCollumn == this.Position.Collumn - 1 || newCollumn == this.Position.Collumn + 1) && newRow == this.Position.Row + 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected bool IsStraightLinePawn(int newCollumn)
        {
            if (newCollumn != this.Position.Collumn)
            {
                return false;
            }

            return true;
        }

        protected bool IsTheNewPositionOnG(int newCollumn, int newRow)
        {
            if (newCollumn == this.Position.Collumn - 1 && newRow == this.Position.Row - 2)
            {
                return true;
            }
            else if (newCollumn == this.Position.Collumn - 1 && newRow == this.Position.Row + 2)
            {
                return true;
            }
            else if (newCollumn == this.Position.Collumn + 1 && newRow == this.Position.Row - 2)
            {
                return true;
            }
            else if (newCollumn == this.Position.Collumn + 1 && newRow == this.Position.Row + 2)
            {
                return true;
            }
            else if (newCollumn == this.Position.Collumn + 2 && newRow == this.Position.Row + 1)
            {
                return true;
            }
            else if (newCollumn == this.Position.Collumn - 2 && newRow == this.Position.Row + 1)
            {
                return true;
            }
            else if (newCollumn == this.Position.Collumn + 2 && newRow == this.Position.Row - 1)
            {
                return true;
            }
            else if (newCollumn == this.Position.Collumn - 2 && newRow == this.Position.Row - 1)
            {
                return true;
            }

            return false;
        }

        protected bool IsTheNewPositionOneBlockAway(int newCollumn, int newRow)
        {
            bool result = false;

            if (newRow == this.Position.Row + 1 && newCollumn == this.Position.Collumn)
            {
                result = true;
            }
            else if (newRow == this.Position.Row - 1 && newCollumn == this.Position.Collumn)
            {
                result = true;
            }
            else if (newRow == this.Position.Row && newCollumn == this.Position.Collumn - 1)
            {
                result = true;
            }
            else if (newRow == this.Position.Row && newCollumn == this.Position.Collumn + 1)
            {
                result = true;
            }
            else if (newRow == this.Position.Row + 1 && newCollumn == this.Position.Collumn + 1)
            {
                result = true;
            }
            else if (newRow == this.Position.Row - 1 && newCollumn == this.Position.Collumn + 1)
            {
                result = true;
            }
            else if (newRow == this.Position.Row - 1 && newCollumn == this.Position.Collumn - 1)
            {
                result = true;
            }
            else if (newRow == this.Position.Row + 1 && newCollumn == this.Position.Collumn - 1)
            {
                result = true;
            }

            return result;
        }

        protected bool IsThereAFigureBetweenTheNewPositionAndTheCurrentOneDiagonal(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite)
        {
            bool result = false;

            foreach (IChessPiece whiteChessPiece in chessPiecesWhite)
            {
                int counterRows;
                int counterCollumns;
                if (newRow < this.Position.Row && newCollumn < this.Position.Collumn)
                {
                    counterRows = this.Position.Row - 1;
                    counterCollumns = this.Position.Collumn - 1;
                    while (counterRows != newRow && counterCollumns != newCollumn)
                    {
                        if (whiteChessPiece.Position.Row == counterRows && whiteChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterRows -= 1;
                        counterCollumns -= 1;
                    }
                }
                else if (newRow > this.Position.Row && newCollumn < this.Position.Collumn)
                {
                    counterRows = this.Position.Row + 1;
                    counterCollumns = this.Position.Collumn - 1;
                    while (counterRows != newRow && counterCollumns != newCollumn)
                    {
                        if (whiteChessPiece.Position.Row == counterRows && whiteChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterRows += 1;
                        counterCollumns -= 1;
                    }
                }
                else if (newRow > this.Position.Row && newCollumn > this.Position.Collumn)
                {
                    counterRows = this.Position.Row + 1;
                    counterCollumns = this.Position.Collumn + 1;
                    while (counterRows != newRow && counterCollumns != newCollumn)
                    {
                        if (whiteChessPiece.Position.Row == counterRows && whiteChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterRows += 1;
                        counterCollumns += 1;
                    }
                }
                else if (newRow < this.Position.Row && newCollumn > this.Position.Collumn)
                {
                    counterRows = this.Position.Row - 1;
                    counterCollumns = this.Position.Collumn + 1;
                    while (counterRows != newRow && counterCollumns != newCollumn)
                    {
                        if (whiteChessPiece.Position.Row == counterRows && whiteChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterRows -= 1;
                        counterCollumns += 1;
                    }
                }
            }

            foreach (IChessPiece blackChessPiece in chessPiecesBlack)
            {
                int counterRows;
                int counterCollumns;
                if (newRow < this.Position.Row && newCollumn < this.Position.Collumn)
                {
                    counterRows = this.Position.Row - 1;
                    counterCollumns = this.Position.Collumn - 1;
                    while (counterRows != newRow && counterCollumns != newCollumn)
                    {
                        if (blackChessPiece.Position.Row == counterRows && blackChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterRows -= 1;
                        counterCollumns -= 1;
                    }
                }
                else if (newRow > this.Position.Row && newCollumn < this.Position.Collumn)
                {
                    counterRows = this.Position.Row + 1;
                    counterCollumns = this.Position.Collumn - 1;
                    while (counterRows != newRow && counterCollumns != newCollumn)
                    {
                        if (blackChessPiece.Position.Row == counterRows && blackChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterRows += 1;
                        counterCollumns -= 1;
                    }
                }
                else if (newRow > this.Position.Row && newCollumn > this.Position.Collumn)
                {
                    counterRows = this.Position.Row + 1;
                    counterCollumns = this.Position.Collumn + 1;
                    while (counterRows != newRow && counterCollumns != newCollumn)
                    {
                        if (blackChessPiece.Position.Row == counterRows && blackChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterRows += 1;
                        counterCollumns += 1;
                    }
                }
                else if (newRow < this.Position.Row && newCollumn > this.Position.Collumn)
                {
                    counterRows = this.Position.Row - 1;
                    counterCollumns = this.Position.Collumn + 1;
                    while (counterRows != newRow && counterCollumns != newCollumn)
                    {
                        if (blackChessPiece.Position.Row == counterRows && blackChessPiece.Position.Collumn == counterCollumns)
                        {
                            result = true;
                        }

                        counterRows -= 1;
                        counterCollumns += 1;
                    }
                }
            }

            return result;
        }

        protected bool IsTheMovementDiagonal(int newCollumn, int newRow)
        {
            bool result = false;
            int counterRows = this.Position.Row;
            int counterCollumns = this.Position.Collumn;

            if (newRow < this.Position.Row && newCollumn < this.Position.Collumn)
            {
                while (true)
                {
                    if (counterRows == newRow && counterCollumns == newCollumn)
                    {
                        result = true;
                        break;
                    }

                    if (counterRows < newRow || counterCollumns < newCollumn)
                    {
                        break;
                    }

                    counterRows -= 1;
                    counterCollumns -= 1;
                }
            }
            else if (newRow < this.Position.Row && newCollumn > this.Position.Collumn)
            {
                while (true)
                {
                    if (counterRows == newRow && counterCollumns == newCollumn)
                    {
                        result = true;
                        break;
                    }

                    if (counterRows < newRow || counterCollumns > newCollumn)
                    {
                        break;
                    }

                    counterRows -= 1;
                    counterCollumns += 1;
                }
            }
            else if (newRow > this.Position.Row && newCollumn < this.Position.Collumn)
            {
                while (true)
                {
                    if (counterRows == newRow && counterCollumns == newCollumn)
                    {
                        result = true;
                        break;
                    }

                    if (counterRows > newRow || counterCollumns < newCollumn)
                    {
                        break;
                    }

                    counterRows += 1;
                    counterCollumns -= 1;
                }
            }
            else if (newRow > this.Position.Row && newCollumn > this.Position.Collumn)
            {
                while (true)
                {
                    if (counterRows == newRow && counterCollumns == newCollumn)
                    {
                        result = true;
                        break;
                    }

                    if (counterRows > newRow || counterCollumns > newCollumn)
                    {
                        break;
                    }

                    counterRows += 1;
                    counterCollumns += 1;
                }
            }

            return result;
        }

        protected bool IsThereAnEnemyFigureOnTheNewPosition(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            bool result = false;

            if (turn == 0)
            {
                foreach (IChessPiece blackChessPiece in chessPiecesBlack)
                {
                    if (blackChessPiece.Position.Row == newRow && blackChessPiece.Position.Collumn == newCollumn)
                    {
                        result = true;
                    }
                }
            }
            else if (turn == 1)
            {
                foreach (IChessPiece whiteChessPiece in chessPiecesWhite)
                {
                    if (whiteChessPiece.Position.Row == newRow && whiteChessPiece.Position.Collumn == newCollumn)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        protected bool IsThereAnAllyFigureOnTheNewPosition(int newCollumn, int newRow, IList<IChessPiece> chessPiecesBlack, IList<IChessPiece> chessPiecesWhite, int turn)
        {
            bool result = false;

            if (turn == 0)
            {
                foreach (IChessPiece whiteChessPiece in chessPiecesWhite)
                {
                    if (whiteChessPiece.Position.Row == newRow && whiteChessPiece.Position.Collumn == newCollumn)
                    {
                        result = true;
                    }
                }
            }
            else if (turn == 1)
            {
                foreach (IChessPiece blackChessPiece in chessPiecesBlack)
                {
                    if (blackChessPiece.Position.Row == newRow && blackChessPiece.Position.Collumn == newCollumn)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
