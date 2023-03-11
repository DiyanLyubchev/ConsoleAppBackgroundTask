// See https://aka.ms/new-console-template for more information
using ConsoleAppBackgroundTask;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
                .ConfigureHostConfiguration(config => { })
                .ConfigureServices((context, service) =>
                {
                    service.AddHostedService<BackgroundTask>();
                })
                .UseConsoleLifetime()
                .Build();

host.Run();

