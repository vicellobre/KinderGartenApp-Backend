using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Scripts;

/// <summary>
/// Clase para la creación de instancias de contexto de base de datos utilizadas en las pruebas.
/// </summary>
public static class TestContextFactory
{
    /// <summary>
    /// Crea y devuelve una instancia de KinderGartenContext configurada para usar una base de datos en memoria.
    /// </summary>
    /// <returns>Instancia de KinderGartenContext configurada para pruebas.</returns>
    public static KinderGartenContext Create()
    {
        // Configura las opciones del contexto de base de datos en memoria
        var options = new DbContextOptionsBuilder<KinderGartenContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Usar un nombre de base de datos único cada vez
            .Options;

        // Crea una instancia del contexto de base de datos
        var dbContext = new KinderGartenContext(options);

        // Asegura que la base de datos en memoria esté eliminada antes de crearla nuevamente
        dbContext.Database.EnsureDeleted();

        // Crea la base de datos en memoria
        dbContext.Database.EnsureCreated();

        // Devuelve el contexto de base de datos
        return dbContext;
    }

    /// <summary>
    /// Inicializa datos simulados en el contexto de base de datos para el jardín de infantes.
    /// SIN entidades rastreadas
    /// </summary>
    /// <returns>Instancia del contexto de base de datos con datos simulados.</returns>
    public static async Task<KinderGartenContext> CreateWithTracker()
    {
        // Crear una lista de padres simulados
        var parents = new List<Parent>
        {
            Parent.Create(Guid.NewGuid(), "John", "Doe", "john.doe@example.com", "password123", "123-456-7890"),
            Parent.Create(Guid.NewGuid(), "Jane", "Smith", "jane.smith@example.com", "password456", "098-765-4321")
        };

        // Crear una lista de maestros simulados
        var teachers = new List<Teacher>
        {
            Teacher.Create(Guid.NewGuid(), "Alice", "Johnson", GradeLevel.PreKinder),
            Teacher.Create(Guid.NewGuid(), "Bob", "Brown", GradeLevel.Kinder1)
        };

        // Crear una lista de niños simulados
        var children = new List<Child>
        {
            Child.Create(Guid.NewGuid(), "Anna", "Doe", new DateTime(2018, 5, 1), GradeLevel.Kinder1, parents[0].Id, teachers[0].Id),
            Child.Create(Guid.NewGuid(), "Chris", "Smith", new DateTime(2017, 3, 15), GradeLevel.Kinder1, parents[1].Id, teachers[1].Id)
        };

        // Crear el contexto de base de datos en memoria
        var context = Create();

        // Agregar los padres simulados al contexto
        await context.Parents.AddRangeAsync(parents);

        // Agregar los maestros simulados al contexto
        await context.Teachers.AddRangeAsync(teachers);

        // Agregar los niños simulados al contexto
        await context.Children.AddRangeAsync(children);

        // Guardar los cambios en el contexto
        await context.SaveChangesAsync();

        // Devolver el contexto configurado con datos simulados
        return context;
    }

    /// <summary>
    /// Inicializa datos simulados en el contexto de base de datos para el jardín de infantes.
    /// CON entidades rastreadas
    /// </summary>
    /// <returns>Instancia del contexto de base de datos con datos simulados.</returns>
    public static async Task<KinderGartenContext> CreateWithCleanTranker()
    {
        var context = await CreateWithTracker();
        context.ChangeTracker.Clear();
        return context;
    }
}
