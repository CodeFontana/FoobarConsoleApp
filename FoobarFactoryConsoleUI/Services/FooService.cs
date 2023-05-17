using FoobarFactoryConsoleUI.Interfaces;
using Microsoft.Extensions.Logging;

namespace FoobarFactoryConsoleUI.Services;

public class FooService : IFooService
{
    private readonly ILogger<FooService> _logger;

    public FooService(ILogger<FooService> logger)
    {
        _logger = logger;
    }

    public void Foo()
    {
        _logger.LogInformation("Foo");
    }
}
