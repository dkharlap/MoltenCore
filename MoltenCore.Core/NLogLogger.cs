using MoltenCore.Core.Interfaces;

namespace MoltenCore.Core
{
    internal class NLogLogger : ILogger
    {
        public Task LogException(Exception exception, string? requestId = null, Dictionary<string, string>? properties = null)
        {
            throw new NotImplementedException();
        }

        public Task LogMessage(LogType logType, string message, string? requestId = null, Dictionary<string, string>? properties = null)
        {
            throw new NotImplementedException();
        }
    }
}
