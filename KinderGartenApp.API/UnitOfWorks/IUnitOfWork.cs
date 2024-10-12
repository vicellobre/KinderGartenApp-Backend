using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.API.UnitOfWorks
{
    /// <summary>
    /// Interfaz para la unidad de trabajo, que encapsula el contexto de base de datos y las operaciones de guardado.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Obtiene el contexto de la base de datos.
        /// </summary>
        DbContext Context { get; }

        /// <summary>
        /// Guarda los cambios en la base de datos de manera asincrónica.
        /// </summary>
        Task CommitAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Guarda los cambios en la base de datos.
        /// </summary>
        void Commit();
    }
}
