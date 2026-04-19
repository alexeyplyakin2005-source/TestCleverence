namespace LogParser.Models;

public class LogEntry
{
    public DateTime DateTime { get; set; }

    public string Level { get; set; }

    public string Method { get; set; }

    public string Message { get; set; }
}
