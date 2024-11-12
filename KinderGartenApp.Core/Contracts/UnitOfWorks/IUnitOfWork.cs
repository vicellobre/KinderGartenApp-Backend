namespace KinderGartenApp.Core.Contracts.UnitOfWorks;

/// <summary>
/// Define una interfaz para la unidad de trabajo, que proporciona métodos para 
/// guardar los cambios en la base de datos, incluyendo métodos sincrónicos y asincrónicos.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Guarda los cambios en la base de datos de manera asincrónica.
    /// </summary>
    /// <param name="cancellationToken">Token de cancelación opcional para cancelar la operación asincrónica.</param>
    /// <returns>Una tarea que representa la operación asincrónica de guardado de cambios.</returns>
    Task CommitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Guarda los cambios en la base de datos.
    /// </summary>
    void Commit();
}
