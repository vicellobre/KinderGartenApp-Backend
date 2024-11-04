using KinderGartenApp.API.Extensions;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Configura los servicios que serán utilizados por la aplicación
    public void ConfigureServices(IServiceCollection services)
    {
        // Agrega dependencias adicionales
        services.AddDependency();

        // Configuración de los controladores (API Endpoints)
        services.AddControllers();

        // Configuración de Swagger/OpenAPI (documentación de la API)
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    // Configura la aplicación y define cómo se procesarán las solicitudes HTTP
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
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
