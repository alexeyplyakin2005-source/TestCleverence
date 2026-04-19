using LogParser.Helpers;
using LogParser.Interfaces;
using LogParser.Models;
using LogParser.Parsers;
using LogParser.Services;

namespace LogParser;

internal class Program
{
    static void Main(string[] args)
    {
        var baseDir = AppContext.BaseDirectory;

        var inputPath = Path.Combine(baseDir, "input.txt");
        var outputPath = Path.Combine(baseDir, "output.txt");
        var problemsPath = Path.Combine(baseDir, "problems.txt");

        var logBuffer = new CustomLogger(inputPath);

        var logs = new List<LogEvent>();

        Console.Write("Enter first number: ");
        var num1 = Console.ReadLine();

        Console.Write("Enter second number: ");
        var num2 = Console.ReadLine();

        logBuffer.Add(new LogEvent
        {
            Level = "INFO",
            Message = $"Input1: {num1}"
        });

        logBuffer.Add(new LogEvent
        {
            Level = "INFO",
            Message = $"Input2: {num2}"
        });

        var sum = Convert.ToInt32(num1) + Convert.ToInt32(num2);

        logBuffer.Add(new LogEvent
        {
            Level = "INFO",
            Message = $"Sum: {sum}"
        });

        var parser = new CompositeLogParser(new ILogParser[]
        {
            new FormatOneParser(),
            new FormatTwoParser()
        });

        var processor = new LogProcessor(parser);

        processor.Process(inputPath, outputPath, problemsPath);

        Console.WriteLine("DONE");
    }
}

