using KinderGartenApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace KinderGartenApp.Persistence.Abstracts;

/// <summary>
/// Clase base abstracta para repositorios que proporciona operaciones comunes sobre entidades.
/// </summary>
/// <typeparam name="TEntity">El tipo de la entidad.</typeparam>
[ExcludeFromCodeCoverage]
public abstract class RepositoryBase<TEntity> where TEntity : class
{
    /// <summary>
    /// El conjunto de entidades gestionadas por este repositorio.
    /// </summary>
    protected DbSet<TEntity> Set { get; init; }

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="RepositoryBase{TEntity}"/>.
    /// </summary>
    /// <param name="context">El contexto de base de datos utilizado para gestionar el conjunto de entidades.</param>
    /// <exception cref="ArgumentNullException">Lanzada si <paramref name="context"/> es null.</exception>
    /// <exception cref="InvalidOperationException">Lanzada si no se puede obtener el conjunto de entidades del contexto.</exception>
    public RepositoryBase(KinderGartenContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        Set = context.Set<TEntity>() ?? throw new InvalidOperationException($"The DbSet for '{nameof(TEntity)}' could not be obtained from the context.");
    }
}
