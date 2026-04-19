using LogParser.Interfaces;
using LogParser.Models;

namespace LogParser.Parsers;

public class CompositeLogParser : ILogParser
{
    private readonly List<ILogParser> _parsers;

    public CompositeLogParser(IEnumerable<ILogParser> parsers)
    {
        _parsers = parsers.ToList();
    }

    public bool TryParse(string line, out LogEntry entry)
    {
        foreach (var parser in _parsers)
        {
            if (parser.TryParse(line, out entry))
                return true;
        }

        entry = null;
        return false;
    }
}
