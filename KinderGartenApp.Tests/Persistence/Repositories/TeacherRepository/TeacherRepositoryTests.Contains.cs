using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class TeacherRepositoryTests
{
    [Fact]
    public async Task Can_Check_If_Teacher_Exists()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.InitializeDataAsync();
        var repository = new TeacherRepository(context);

        // Obtener un maestro existente
        var teacher = await context.Teachers.FirstAsync();

        // Verificar que el maestro existe
        var exists = await repository.Contains(teacher.Id);
        Assert.True(exists);
    }
    
    [Fact]
    public async Task Can_Check_If_Teacher_NotExists()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.InitializeDataAsync();
        var repository = new TeacherRepository(context);

        // Verificar que un maestro inexistente no existe
        var nonExists = await repository.Contains(Guid.NewGuid());
        Assert.False(nonExists);
    }
}
