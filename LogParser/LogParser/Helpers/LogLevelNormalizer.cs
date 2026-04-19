namespace LogParser.Helpers;

public static class LogLevelNormalizer
{
    public static string Normalize(string level)
    {
        return level.ToUpper() switch
        {
            "INFORMATION" => "INFO",
            "INFO" => "INFO",
            "WARNING" => "WARN",
            "WARN" => "WARN",
            "ERROR" => "ERROR",
            "DEBUG" => "DEBUG",
            _ => "INFO"
        };
    }
}
