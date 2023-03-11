using Microsoft.Extensions.Hosting;

namespace ConsoleAppBackgroundTask;

public sealed class BackgroundTask : IHostedService, IDisposable
{
    private Timer? timer;

    public Task StartAsync(CancellationToken stoppingToken)
    {
        this.timer = new Timer(RunService, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

        return Task.CompletedTask;
    }

    private void RunService(object state)
    {
        Console.WriteLine($"Time: {DateTime.Now:HH:mm:ss}");
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        this.timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        this.timer?.Dispose();
    }
}

