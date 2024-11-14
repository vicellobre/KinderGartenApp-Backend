using System.Text.RegularExpressions;

namespace KinderGartenApp.Core.Extensions;

/// <summary>
/// Contiene métodos de extensión para la clase <see cref="string"/>.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Verifica si la cadena es un nombre de persona válido.
    /// </summary>
    /// <param name="input">La cadena a verificar.</param>
    /// <returns><c>true</c> si la cadena es un nombre de persona válido; de lo contrario, <c>false</c>.</returns>
    public static bool IsValidPersonName(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑçÇüÜàÀèÈìÌòÒùÙâêÊîôûäëïöüß]+(?:\s[a-zA-ZáéíóúÁÉÍÓÚñÑçÇüÜàÀèÈìÌòÒùÙâêÊîôûäëïöüß]+)*$");
    }
}


