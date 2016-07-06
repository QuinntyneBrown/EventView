namespace EventView.Utils
{
    public interface ILogger
    {
        void AddProvider(ILoggerProvider provider);
    }
}
