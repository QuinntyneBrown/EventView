namespace EventView.Utils
{
    public interface ILoggerProvider
    {
        ILogger CreateLogger(string name);
    }
}
