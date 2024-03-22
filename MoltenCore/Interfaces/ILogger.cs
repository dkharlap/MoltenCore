namespace MoltenCore.Interfaces
{
    public interface ILogger
    {
        public Task LogException(Exception exception, string? requestId = null, Dictionary<string, string>? properties = null);

        public Task LogMessage(LogType logType, string message, string? requestId = null, Dictionary<string, string>? properties = null);
    }

    public enum LogType
    {
        Info = 0,
        Warning = 1,
        Error = 2,
        Fatal = 3,
    }
}

