using FoobarConsoleUI.Interfaces;
using Microsoft.Extensions.Logging;

namespace FoobarConsoleUI.Services;

public class BarService : IBarService
{
    private readonly ILogger<BarService> _logger;
    private readonly string _inputText;

    public BarService(ILogger<BarService> logger, 
                      string inputText)
    {
        _logger = logger;
        _inputText = inputText;
    }

    public void Bar()
    {
        _logger.LogInformation($"Bar: {_inputText}");
    }
}
