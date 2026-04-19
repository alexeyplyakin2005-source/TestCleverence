using LogParser.Interfaces;
using LogParser.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LogParser.Parsers;

public class FormatOneParser : ILogParser
{
    private readonly Regex regex = new Regex(
        @"^(?<date>\d{2}\.\d{2}\.\d{4}) (?<time>\d{2}:\d{2}:\d{2}\.\d+) (?<level>\w+) (?<message>.+)$",
        RegexOptions.Compiled);

    public bool TryParse(string line, out LogEntry entry)
    {
        entry = null;

        var match = regex.Match(line);
        if (!match.Success) return false;

        entry = new LogEntry
        {
            DateTime = DateTime.ParseExact(
                $"{match.Groups["date"]} {match.Groups["time"]}",
                new[] { "dd.MM.yyyy HH:mm:ss.fff", "dd.MM.yyyy HH:mm:ss.ff", "dd.MM.yyyy HH:mm:ss.f" },
                CultureInfo.InvariantCulture,
                DateTimeStyles.None),

            Level = match.Groups["level"].Value,
            Method = "DEFAULT",
            Message = match.Groups["message"].Value
        };

        return true;
    }
}
