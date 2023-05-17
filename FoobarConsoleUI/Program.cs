using FoobarConsoleUI;
using FoobarConsoleUI.Interfaces;
using FoobarConsoleUI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder();

builder.Services.AddTransient<IFooService, FooService>();
builder.Services.AddTransient<IBarService, BarService>(sp =>
{ 
    ILogger<BarService> barLogger = sp.GetRequiredService<ILogger<BarService>>();
    return new BarService(barLogger, "Foobar");
});
builder.Services.AddHostedService<App>();

IHost app = builder.Build();
app.Run();