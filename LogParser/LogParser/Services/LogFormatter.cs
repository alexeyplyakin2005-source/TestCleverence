using LogParser.Helpers;
using LogParser.Models;

namespace LogParser.Services;

public static class LogFormatter
{
    public static string Format(LogEntry entry)
    {
        return $"{entry.DateTime:yyyy-MM-dd}\t{entry.DateTime:HH:mm:ss.ffff}\t" +
               $"{LogLevelNormalizer.Normalize(entry.Level)}\t" +
               $"{entry.Method}\t{entry.Message}";
    }
}
