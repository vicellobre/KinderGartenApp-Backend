using KinderGartenApp.API;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Clase principal del programa que configura y ejecuta el host de la aplicaci�n.
/// </summary>
[ExcludeFromCodeCoverage]
internal class Program
{
    /// <summary>
    /// Punto de entrada principal de la aplicaci�n.
    /// </summary>
    /// <param name="args">Argumentos de l�nea de comandos.</param>
    private static void Main(string[] args)
    {
        HostBuilderHelper.CreateHostBuilder(args).Build().Run();
    }
}
