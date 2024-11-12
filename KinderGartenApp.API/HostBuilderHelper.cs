using System.Diagnostics.CodeAnalysis;

namespace KinderGartenApp.API;

[ExcludeFromCodeCoverage]
public static class HostBuilderHelper
{
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}