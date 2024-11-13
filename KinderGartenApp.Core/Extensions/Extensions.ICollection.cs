using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Shared;

namespace KinderGartenApp.Core.Extensions;

public static class CollectionExtensions
{
    /// <summary>
    /// Comprueba si la colección está vacía.
    /// </summary>
    /// <typeparam name="T">El tipo de elementos en la colección.</typeparam>
    /// <param name="collection">La colección a comprobar.</param>
    /// <returns>True si la colección está vacía; de lo contrario, false.</returns>
    public static bool IsEmpty<T>(this ICollection<T> collection)
    {
        return collection.Count == 0;
    }
}