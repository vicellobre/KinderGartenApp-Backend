using KinderGartenApp.Core.Entities;
using KinderGartenApp.Persistence.Contexts;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class TeacherRepositoryTests
{
    [Fact]
    public void Constructor_With_Valid_Context_Should_Create_Instance()
    {
        // Crear el contexto con datos simulados
        var context = TestContextFactory.CreateContext();

        // Crear una instancia de TeacherRepository con un contexto válido
        var repository = new TeacherRepository(context);

        // Verificar que la instancia se haya creado correctamente
        Assert.NotNull(repository);
    }

    [Fact]
    public void Constructor_With_Null_Context_Should_Throw_ArgumentNullException()
    {
        // Crear una instancia de TeacherRepository con un contexto nulo
        KinderGartenContext? nullContext = null;

        // Se espera una excepción al intentar crear una instancia con un contexto nulo
        Assert.Throws<ArgumentNullException>(() => new TeacherRepository(nullContext!));
    }

    [Fact]
    public void Constructor_With_Invalid_Context_Should_Throw_InvalidOperationException()
    {
        var options = new DbContextOptionsBuilder<KinderGartenContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        // Crear un contexto sin DbSet<Teacher> para simular un contexto inválido
        var contextMock = new Mock<KinderGartenContext>(options);
        contextMock.Setup(c => c.Set<Teacher>()).Returns((DbSet<Teacher>)null!);

        // Se espera una excepción al intentar crear una instancia con un contexto inválido
        var exception = Assert.Throws<InvalidOperationException>(() => new TeacherRepository(contextMock.Object));
        Assert.Equal($"The DbSet for '{typeof(Teacher)}' could not be obtained from the context.", exception.Message);
    }
}
