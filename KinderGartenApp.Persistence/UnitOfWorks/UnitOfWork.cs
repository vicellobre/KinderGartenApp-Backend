using KinderGartenApp.Core.Contracts.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Persistence.UnitOfWorks;

/// <summary>
/// Implementación de la interfaz IUnitOfWork para gestionar transacciones y operaciones de base de datos.
/// </summary>
/// <remarks>
/// Constructor que inicializa una nueva instancia de UnitOfWork con el contexto de la base de datos proporcionado.
/// </remarks>
/// <param name="dbContext">Contexto de la base de datos (CoWorkingContext).</param>
public sealed class UnitOfWork(DbContext dbContext) : IUnitOfWork
{
    private bool _disposed;

    /// <summary>
    /// Obtiene el contexto de la base de datos utilizado para acceder y manipular los datos.
    /// </summary>
    public DbContext Context { get; } = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

    /// <summary>
    /// Confirma los cambios realizados en el contexto de la base de datos de manera asíncrona.
    /// </summary>
    /// <returns>Una tarea asincrónica que representa la operación de confirmación.</returns>
    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await Context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Confirma los cambios realizados en el contexto de la base de datos.
    /// </summary>
    public void Commit()
    {
        Context.SaveChanges();
    }

    /// <summary>
    /// Libera los recursos no administrados utilizados por la instancia de UnitOfWork.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                try
                {
                    Context?.Dispose();
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