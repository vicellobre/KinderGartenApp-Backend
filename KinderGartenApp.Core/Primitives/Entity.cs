namespace KinderGartenApp.Core.Primitives;

/// <summary>
/// Clase base abstracta que representa una entidad con un identificador único de tipo GUID.
/// Implementa la interfaz <see cref="IEquatable{Entity}"/> para comparar entidades.
/// </summary>
public abstract class Entity : IEquatable<Entity>
{
    /// <summary>
    /// Identificador único de la entidad.
    /// Este campo se inicializa al momento de creación y no puede modificarse.
    /// </summary>
    public Guid Id { get; private init; }

    // Constructores
    /// <summary>
    /// Constructor protegido sin parámetros para inicializar la entidad.
    /// </summary>
    protected Entity() { }

    /// <summary>
    /// Constructor protegido que permite inicializar la entidad con un identificador específico.
    /// </summary>
    /// <param name="id">Identificador único de la entidad.</param>
    protected Entity(Guid id) : base() => Id = id;

    /// <summary>
    /// Sobrecarga del operador <c>==</c> para comparar dos entidades.
    /// </summary>
    /// <param name="first">Primera entidad a comparar.</param>
    /// <param name="second">Segunda entidad a comparar.</param>
    /// <returns>Devuelve <c>true</c> si ambas entidades son iguales; de lo contrario, <c>false</c>.</returns>
    public static bool operator ==(Entity? first, Entity? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    /// <summary>
    /// Sobrecarga del operador <c>!=</c> para comparar dos entidades.
    /// </summary>
    /// <param name="first">Primera entidad a comparar.</param>
    /// <param name="second">Segunda entidad a comparar.</param>
    /// <returns>Devuelve <c>true</c> si las entidades son diferentes; de lo contrario, <c>false</c>.</returns>
    public static bool operator !=(Entity? first, Entity? second)
    {
        return !(first == second);
    }

    /// <summary>
    /// Determina si la entidad actual es igual a otra entidad del mismo tipo.
    /// </summary>
    /// <param name="other">Otra entidad para comparar con esta instancia.</param>
    /// <returns>Devuelve <c>true</c> si las entidades son iguales; de lo contrario, <c>false</c>.</returns>
    public bool Equals(Entity? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return other.Id == Id;
    }

    /// <summary>
    /// Determina si la entidad actual es igual a otro objeto.
    /// </summary>
    /// <param name="obj">Objeto a comparar con esta instancia.</param>
    /// <returns>Devuelve <c>true</c> si el objeto es una entidad y es igual a esta instancia; de lo contrario, <c>false</c>.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj is not Entity entity)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return entity.Id == Id;
    }

    /// <summary>
    /// Devuelve un código hash para la entidad, basado en el identificador único.
    /// </summary>
    /// <returns>Código hash de la entidad.</returns>
    public override int GetHashCode() => Id.GetHashCode() * 41;
}
