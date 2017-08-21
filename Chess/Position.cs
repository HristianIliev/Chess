using Chess.Contracts;

namespace Chess
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class Position : IPosition
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        private int collumn;
        private int row;

        public Position(int collumn, int row)
        {
            this.Collumn = collumn;
            this.Row = row;
        }

        public int Collumn
        {
            get
            {
                return this.collumn;
            }

            set
            {
                this.collumn = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                this.row = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is IPosition)
            {
                IPosition other = obj as IPosition;
                if (other.Collumn == this.Collumn && other.Row == this.Row)
                {
                    return true;
                }
            }

            return false;
        }
    }
}