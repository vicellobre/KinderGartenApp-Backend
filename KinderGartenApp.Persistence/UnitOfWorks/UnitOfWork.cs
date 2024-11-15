using KinderGartenApp.Core.Contracts.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Persistence.UnitOfWorks;

/// <summary>
/// Implementación de la interfaz <see cref="IUnitOfWork"/> para gestionar transacciones y operaciones de base de datos.
/// </summary>
public sealed class UnitOfWork : IUnitOfWork
{
    private bool _disposed;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="UnitOfWork"/> con el contexto de base de datos proporcionado.
    /// </summary>
    /// <param name="dbContext">El contexto de base de datos utilizado para las operaciones.</param>
    /// <exception cref="ArgumentNullException">Se produce cuando <paramref name="dbContext"/> es null.</exception>
    public UnitOfWork(DbContext? dbContext)
    {
        Context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// Obtiene el contexto de la base de datos utilizado para acceder y manipular los datos.
    /// </summary>
    public DbContext Context { get; }

    /// <inheritdoc />
    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await Context.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public void Commit()
    {
        Context.SaveChanges();
    }

    /// <summary>
    /// Libera los recursos no administrados utilizados por la instancia de <see cref="UnitOfWork"/>.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Libera los recursos gestionados y no gestionados utilizados por la instancia de <see cref="UnitOfWork"/>.
    /// </summary>
    /// <param name="disposing">Indica si se deben liberar los recursos gestionados.</param>
    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                try
                {
                    Context.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error disposing context: {ex.Message}");
                }
            }
            _disposed = true;
        }
    }
}
