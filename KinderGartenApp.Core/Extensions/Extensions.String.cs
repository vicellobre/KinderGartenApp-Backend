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

    /// <summary>
    /// Verifica si la cadena es un correo electrónico válido.
    /// </summary>
    /// <param name="input">La cadena a verificar.</param>
    /// <returns><c>true</c> si la cadena es un correo electrónico válido; de lo contrario, <c>false</c>.</returns>
    public static bool IsValidEmail(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    }

    /// <summary>
    /// Verifica si la cadena es un número de teléfono válido.
    /// </summary>
    /// <param name="input">La cadena a verificar.</param>
    /// <returns><c>true</c> si la cadena es un número de teléfono válido; de lo contrario, <c>false</c>.</returns>
    public static bool IsValidPhone(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^\d{10}$");
    }

    /// <summary>
    /// Verifica si la cadena es una contraseña válida.
    /// </summary>
    /// <param name="input">La cadena a verificar.</param>
    /// <returns><c>true</c> si la cadena es una contraseña válida; de lo contrario, <c>false</c>.</returns>
    public static bool IsValidPassword(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"^(?=(.*[a-z]))(?=(.*[A-Z]))(?=(.*\d))(?=(.*[!@#$%^&*(),.?"":{}|<>]))[a-zA-Z\d!@#$%^&*(),.?"":{}|<> ]*$");
    }

    /// <summary>
    /// Capitaliza la primera letra de una palabra y convierte el resto a minúsculas.
    /// </summary>
    /// <param name="word">La palabra a capitalizar.</param>
    /// <returns>La palabra capitalizada.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro word es nulo o vacío.</exception>
    public static string CapitalizeWord(this string word)
    {
        return string.IsNullOrWhiteSpace(word) ? throw new ArgumentNullException(nameof(word)) : char.ToUpper(word[0]) + word[1..].ToLower();
    }

    /// <summary>
    /// Reemplaza las tabulaciones, retornos de carro y saltos de línea con un espacio.
    /// </summary>
    /// <param name="input">La cadena de texto a procesar.</param>
    /// <returns>Una nueva cadena con los caracteres reemplazados por espacios.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro input es nulo o vacío.</exception>
    public static string ReplaceControlCharsWithSpace(this string input)
    {
        return input is null
            ? throw new ArgumentNullException(nameof(input))
            : input.Replace('\t', ' ')
                   .Replace('\r', ' ')
                   .Replace('\n', ' ');
    }

    /// <summary>
    /// Capitaliza las primeras letras de cada palabra en la cadena de texto,
    /// incluyendo el manejo de nuevas líneas y tabulaciones.
    /// </summary>
    /// <param name="input">La cadena de texto a capitalizar.</param>
    /// <returns>Una nueva cadena con las palabras capitalizadas.</returns>
    /// <exception cref="ArgumentNullException">Se lanza cuando el parámetro input es nulo o vacío.</exception>
    public static string CapitalizeWords(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        // Reemplazar caracteres de control con espacios
        var processedInput = input.ReplaceControlCharsWithSpace();

        // Remover espacios en blanco iniciales y finales, y manejar nuevas líneas y tabulaciones
        var trimmedInput = processedInput.Trim();
        if (string.IsNullOrWhiteSpace(trimmedInput))
        {
            return string.Empty;
        }

        var words = trimmedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var capitalizedWords = words.Select(word => word.CapitalizeWord());

        return string.Join(' ', capitalizedWords);
    }
}
