using FoobarFactoryConsoleUI.Interfaces;
using FoobarFactoryConsoleUI.Services;
using Microsoft.Extensions.Logging;

namespace FoobarFactoryConsoleUI.Factories;

public class BarServiceFactory
{
    private readonly ILoggerFactory _loggerFactory;

    public BarServiceFactory(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }

    public IBarService CreateInstance(string inputText)
    {
        ILogger<BarService> _barLogger = _loggerFactory.CreateLogger<BarService>();
        return new BarService(_barLogger, inputText);
    }
}
