using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class TeacherRepositoryTests
{
    [Fact]
    public async Task Can_Get_Teacher_By_Id_AsNoTracking()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.InitializeDataAsync();
        var repository = new TeacherRepository(context);

        // Obtener un maestro existente sin seguimiento de cambios
        var teacher = await context.Teachers.FirstAsync();
        var retrievedTeacher = await repository.GetByIdAsNoTrackingAsync(teacher.Id);

        // Verificar que el maestro se haya obtenido correctamente
        Assert.NotNull(retrievedTeacher);
        Assert.Equal(teacher.Id, retrievedTeacher.Id);
        Assert.Equal(teacher.FirstName, retrievedTeacher.FirstName);
    }

    [Fact]
    public async Task Cant_Get_Teacher_By_Id_AsNoTracking()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.InitializeDataAsync();
        var repository = new TeacherRepository(context);

        // Probar obtener un maestro con un ID inexistente sin seguimiento de cambios
        var nonExistentTeacher = await repository.GetByIdAsNoTrackingAsync(Guid.NewGuid());

        // Verificar que el resultado sea null
        Assert.Null(nonExistentTeacher);
    }
}
