namespace LogParser.Models;

public class LogEvent
{
    public string Level { get; set; }

    public string Message { get; set; }

    public string Method { get; set; } = "DEFAULT";

    public DateTime Time { get; set; } = DateTime.Now;
}
