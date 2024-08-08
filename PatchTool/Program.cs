using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatchToolService.Classes;
using PatchToolService.Interfaces;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddScoped<IApplication, Application>();
    services.AddScoped<IJSONManipulation, JSONManipulation>();
    services.AddScoped<IVersionNumberHelper, VersionNumberHelper>();
    services.AddScoped<IVersionSelectionHelper, VersionSelectionHelper>();
    services.AddScoped<IFilePathHelper, FilePathHelper>();
}).Build();



var app = host.Services.GetRequiredService<IApplication>();

app.Start(false);

