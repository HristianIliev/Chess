namespace Chess.Contracts
{
    public interface IPosition
    {
        int Row
        {
            get;
            set;
        }

        int Collumn
        {
            get;
            set;
        }

        bool Equals(object obj);
    }
}
