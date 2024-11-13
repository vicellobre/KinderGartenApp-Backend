using KinderGartenApp.API.Extensions;
using KinderGartenApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace KinderGartenApp.API;

/// <summary>
/// Configura los servicios y la canalización de solicitudes de la aplicación.
/// </summary>
[ExcludeFromCodeCoverage]
public class Startup
{
    /// <summary>
    /// Configuración de la aplicación.
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="Startup"/> con la configuración especificada.
    /// </summary>
    /// <param name="configuration">La configuración de la aplicación.</param>
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    /// <summary>
    /// Configura los servicios de la aplicación.
    /// </summary>
    /// <param name="services">La colección de servicios para configurar.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        // Configuración del contexto de la base de datos
        services.AddDbContext<KinderGartenContext>();

        // Agrega dependencias adicionales
        services.AddDependency();

        // Configuración de los controladores (API Endpoints)
        services.AddControllers();

        // Configuración de Swagger/OpenAPI (documentación de la API)
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    /// <summary>
    /// Configura la canalización de solicitudes de la aplicación.
    /// </summary>
    /// <param name="app">La aplicación para configurar la canalización de solicitudes.</param>
    /// <param name="env">El entorno en el que se está ejecutando la aplicación.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configura la canalización de solicitudes HTTP.
        if (env.IsDevelopment())
        {
            // Habilita Swagger
            app.UseSwagger();
            // Configura la interfaz de usuario de Swagger
            app.UseSwaggerUI();
        }

        // Redirige el tráfico HTTP a HTTPS
        app.UseHttpsRedirection();

        app.UseRouting();
        // Configuración de autorización
        app.UseAuthorization();

        // Asigna los controladores para procesar las solicitudes HTTP
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

