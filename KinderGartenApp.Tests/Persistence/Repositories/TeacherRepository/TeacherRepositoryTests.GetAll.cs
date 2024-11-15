using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class TeacherRepositoryTests
{
    [Fact]
    public async Task Can_Get_All_Teachers()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new TeacherRepository(context);

        // Obtener todos los maestros
        var teachers = await repository.GetAllAsync();

        // Verificar que se hayan obtenido todos los maestros
        Assert.NotNull(teachers);
        Assert.NotEmpty(teachers);
    }

    [Fact]
    public async Task Cant_Get_All_Teachers()
    {
        // Crear el contexto sin datos simulados (vacío)
        var context = TestContextFactory.Create();
        var repository = new TeacherRepository(context);

        // Obtener todos los maestros en un contexto vacío
        var teachers = await repository.GetAllAsync();

        // Verificar que la lista de maestros está vacía
        Assert.NotNull(teachers);
        Assert.Empty(teachers);
    }
}
