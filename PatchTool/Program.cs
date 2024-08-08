using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatchToolService.Classes;

HostApplicationBuilder builder = new HostApplicationBuilder(args);

builder.Services.AddScoped<JSONManipulation,JSONManipulation>();
builder.Services.AddScoped<VersionSelectionHelper, VersionSelectionHelper>();
builder.Services.AddScoped<VersionNumberHelper, VersionNumberHelper>();

using IHost host = builder.Build();

Start(host.Services);

await host.RunAsync();

static void Start(IServiceProvider hostProvider)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    var versionSelectionHelper = provider.GetRequiredService<VersionSelectionHelper>();

    versionSelectionHelper.VersionSelectionPrompt();
}

Console.ReadLine();