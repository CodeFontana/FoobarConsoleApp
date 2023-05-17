using FoobarConsoleUI.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FoobarConsoleUI;

public class App : IHostedService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConfiguration _config;
    private readonly ILogger<App> _logger;
    private readonly IFooService _fooService;
    private readonly IBarService _barService;

    public App(IHostApplicationLifetime hostApplicationLifetime,
               IConfiguration configuration,
               ILogger<App> logger,
               IFooService fooService,
               IBarService barService)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _config = configuration;
        _logger = logger;
        _fooService = fooService;
        _barService = barService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _hostApplicationLifetime.ApplicationStarted.Register(async () =>
        {
            try
            {
                await Task.Yield(); // https://github.com/dotnet/runtime/issues/36063
                await Task.Delay(1000); // Additional delay for Microsoft.Hosting.Lifetime messages
                Execute();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception!");
            }
            finally
            {
                _hostApplicationLifetime.StopApplication();
            }
        });

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public void Execute()
    {
        _fooService.Foo();
        _barService.Bar();
    }
}
