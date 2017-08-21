namespace Chess
{
    public interface ILogger
    {
        void Write(string message);

        void WriteLine(string message);
    }
}
