using LogParser.Models;

namespace LogParser.Helpers;

public static class LogGenerator
{
    public static LogEvent Info(string message)
        => new LogEvent
        {
            Level = "INFORMATION",
            Message = message
        };
}
