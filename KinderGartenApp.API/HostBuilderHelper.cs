using System.Diagnostics.CodeAnalysis;

namespace KinderGartenApp.API;

/// <summary>
/// Proporciona métodos auxiliares para configurar y construir el host de la aplicación.
/// </summary>
[ExcludeFromCodeCoverage]
public static class HostBuilderHelper
{
    /// <summary>
    /// Crea y configura una instancia de <see cref="IHostBuilder"/> con los valores predeterminados.
    /// </summary>
    /// <param name="args">Argumentos de línea de comandos.</param>
    /// <returns>Una instancia configurada de <see cref="IHostBuilder"/>.</returns>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}