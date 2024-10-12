using System.Diagnostics.CodeAnalysis;

namespace KinderGartenApp.API.Extensions
{
    /// <summary>
    /// Clase estática para configurar la inyección de dependencias en la aplicación.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class IoC
    {
        /// <summary>
        /// Método de extensión para agregar las dependencias necesarias a la colección de servicios.
        /// </summary>
        /// <param name="services">Colección de servicios de la aplicación.</param>
        /// <returns>Colección de servicios con las nuevas dependencias agregadas.</returns>
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {

            // Inyectar UnitOfWork
            //services.AddScoped<IUnitOfWork>(p => new UnitOfWork(p.GetRequiredService<DbContext>()));

            return services;
        }
    }
}
