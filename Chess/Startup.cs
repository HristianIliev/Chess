namespace Chess
{
    using Chess.Contracts;
    using Providers;

    public class Startup
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            ILogger logger = new Logger();
            IReader reader = new Reader();
        
            engine.StartGame(logger, reader);
        }
    }
}
