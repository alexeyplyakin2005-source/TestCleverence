using LogParser.Interfaces;

namespace LogParser.Services;

public class LogProcessor(ILogParser logParser)
{
    public void Process(string input, string output, string problems)
    {
        Console.WriteLine("READING FILE VERSION:");
        Console.WriteLine(File.ReadAllText(input));

        using var reader = new StreamReader(input);
        using var writer = new StreamWriter(output, append: true);
        using var problemWriter = new StreamWriter(problems);

        string line;

        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine("LINE: " + line);

            bool parsed = logParser.TryParse(line, out var entry);

            Console.WriteLine("PARSED: " + parsed);

            if (parsed)
                writer.WriteLine(LogFormatter.Format(entry));
            else
                problemWriter.WriteLine(line);
        }
    }
}
