using FoobarFactoryConsoleUI;
using FoobarFactoryConsoleUI.Factories;
using FoobarFactoryConsoleUI.Interfaces;
using FoobarFactoryConsoleUI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder();

builder.Services.AddTransient<IFooService, FooService>();
builder.Services.AddTransient<BarServiceFactory>();
builder.Services.AddHostedService<App>();

IHost app = builder.Build();
app.Run();