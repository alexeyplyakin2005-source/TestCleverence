using LogParser.Models;

namespace LogParser.Interfaces;

public interface ILogParser
{
    bool TryParse(string line, out LogEntry entry);
}
