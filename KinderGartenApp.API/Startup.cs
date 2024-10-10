using KinderGartenApp.API.Extensions;

namespace KinderGartenApp.API
{
    public static class Startup
    {
        public static WebApplication Initialize(string[] args)
        {
            // Crea una instancia del constructor de la aplicación
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            
            var app = builder.Build();
            Configure(app);

            return app;
        }

        // Configura los servicios que serán utilizados por la aplicación
        static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Agrega dependencias adicionales
            builder.Services.AddDependency();

            // Configuración de los controladores (API Endpoints)
            builder.Services.AddControllers();

            // Configuración de Swagger/OpenAPI (documentación de la API)
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        // Configura la aplicación y define cómo se procesarán las solicitudes HTTP
        static void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Habilita Swagger
                app.UseSwagger();
                // Configura la interfaz de usuario de Swagger
                app.UseSwaggerUI();
            }

            // Redirige el tráfico HTTP a HTTPS
            app.UseHttpsRedirection();

            // Configuración de autorización
            app.UseAuthorization();

            // Asigna los controladores para procesar las solicitudes HTTP
            app.MapControllers();
        }
    }
}
