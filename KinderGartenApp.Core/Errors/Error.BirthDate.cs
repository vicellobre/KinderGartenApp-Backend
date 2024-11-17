namespace KinderGartenApp.Core.Errors;

/// <summary>
/// Representa un error con un código y un mensaje descriptivo.
/// </summary>
public readonly partial record struct Error
{
    /// <summary>
    /// Errores relacionados con el primer nombre.
    /// </summary>
    public static class BirthDate
    {
        /// <summary>
        /// Indica que la fecha de nacimiento no puede ser menor al minimo de edad.
        /// </summary>
        /// <param name="minimumYearsOld">El minimo de años.</param>
        /// <returns>Una nueva instancia de <see cref="Error"/> con un mensaje que indica que la edad está por debajo del minimo.</returns>
        public static readonly Func<int, Error> InvalidAge = minimumYearsOld => new Error("BirthDate.InvalidAge", $"The birth date cannot be less than {minimumYearsOld} years ago.");
    }
}
