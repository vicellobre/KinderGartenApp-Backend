namespace KinderGartenApp.Core.Contracts.UnitOfWorks;

/// <summary>
/// Interfaz para la unidad de trabajo, que encapsula el contexto de base de datos y las operaciones de guardado.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Guarda los cambios en la base de datos de manera asincrónica.
    /// </summary>
    Task CommitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Guarda los cambios en la base de datos.
    /// </summary>
    void Commit();
}