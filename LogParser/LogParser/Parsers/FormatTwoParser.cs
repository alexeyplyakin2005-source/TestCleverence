using LogParser.Interfaces;
using LogParser.Models;
using System.Text.RegularExpressions;

namespace LogParser.Parsers;

public class FormatTwoParser : ILogParser
{
    private readonly Regex regex = new Regex(
        @"^(?<date>\d{4}-\d{2}-\d{2}) (?<time>\d{2}:\d{2}:\d{2}\.\d+)\| (?<level>\w+)\|\d+\|(?<method>[^|]+)\| (?<message>.+)$",
        RegexOptions.Compiled);

    public bool TryParse(string line, out LogEntry entry)
    {
        entry = null;

        var match = regex.Match(line);
        if (!match.Success) return false;

        entry = new LogEntry
        {
            DateTime = DateTime.Parse($"{match.Groups["date"]} {match.Groups["time"]}"),
            Level = match.Groups["level"].Value,
            Method = match.Groups["method"].Value,
            Message = match.Groups["message"].Value
        };

        return true;
    }
}
