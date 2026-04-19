using LogParser.Interfaces;
using LogParser.Models;
using System.Threading.Channels;

namespace LogParser.Services;

public class CustomLogger 
{
    private readonly Channel<LogEvent> _channel;
    private readonly string _path;
    private readonly CancellationTokenSource _cts = new();
    private readonly Task _worker;

    public CustomLogger(string path)
    {
        _path = path;

        _channel = Channel.CreateUnbounded<LogEvent>();

        _worker = Task.Run(ProcessQueueAsync);
    }

    public void Add(LogEvent log)
    {
        _channel.Writer.TryWrite(log);
    }

    private async Task ProcessQueueAsync()
    {
        await foreach (var log in _channel.Reader.ReadAllAsync(_cts.Token))
        {
            var line =
                $"{log.Time:dd.MM.yyyy HH:mm:ss.fff} {log.Level} {log.Message}{Environment.NewLine}";

            await File.AppendAllTextAsync(_path, line);
        }
    }

    public async Task DisposeAsync()
    {
        _channel.Writer.Complete();
        _cts.Cancel();

        await _worker;
    }

    public void Dispose()
    {
        DisposeAsync().GetAwaiter().GetResult();
    }
}
