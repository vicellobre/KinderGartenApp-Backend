using KinderGartenApp.API;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Clase principal del programa que configura y ejecuta el host de la aplicación.
/// </summary>
[ExcludeFromCodeCoverage]
internal class Program
{
    /// <summary>
    /// Punto de entrada principal de la aplicación.
    /// </summary>
    /// <param name="args">Argumentos de línea de comandos.</param>
    private static void Main(string[] args)
    {
        HostBuilderHelper.CreateHostBuilder(args).Build().Run();
    }
}
