using KinderGartenApp.Core.Entities;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class TeacherRepositoryTests
{
    [Fact]
    public async Task Can_Get_Teacher_By_Id()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.InitializeDataAsync();
        var repository = new TeacherRepository(context);

        // Obtener un maestro existente
        var teacher = await context.Teachers.FirstAsync();
        var retrievedTeacher = await repository.GetByIdAsync(teacher.Id);

        // Verificar que el maestro se haya obtenido correctamente
        Assert.NotNull(retrievedTeacher);
        Assert.Equal(teacher.Id, retrievedTeacher.Id);
        Assert.Equal(teacher.FirstName, retrievedTeacher.FirstName);

        // Probar obtener un maestro con un ID inexistente
        var nonExistentTeacher = await repository.GetByIdAsync(Guid.NewGuid());
        Assert.Null(nonExistentTeacher);
    }

    [Fact]
    public async Task Cant_Get_Teacher_By_Id()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.InitializeDataAsync();
        var repository = new TeacherRepository(context);

        // Probar obtener un maestro con un ID inexistente
        var nonExistentTeacher = await repository.GetByIdAsync(Guid.NewGuid());

        // Verificar que el resultado sea null
        Assert.Null(nonExistentTeacher);
    }
}
