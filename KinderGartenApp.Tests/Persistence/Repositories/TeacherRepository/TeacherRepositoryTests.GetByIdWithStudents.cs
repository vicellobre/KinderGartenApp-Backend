using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class TeacherRepositoryTests
{
    [Fact]
    public async Task Can_Get_Teacher_With_Students_By_Id()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new TeacherRepository(context);

        // Obtener un maestro existente con sus estudiantes
        var teacher = await context.Teachers.Include(t => t.Students).FirstOrDefaultAsync();
        Assert.NotNull(teacher);  // Asegurarse de que hay un maestro disponible para la prueba

        // Usar el método del repositorio para obtener el maestro con sus estudiantes
        var result = await repository.GetByIdWithStudentsAsNoTrackingAsync(teacher.Id);

        // Verificar que el maestro y sus estudiantes se hayan obtenido correctamente
        Assert.NotNull(result);
        Assert.Equal(teacher.Id, result.Id);
        Assert.NotNull(result.Students);
        Assert.Equal(teacher.Students.Count, result.Students.Count);
    }

    [Fact]
    public async Task Can_Get_Teacher_With_Students_By_Id_Should_Not_Track_Changes()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.CreateWithCleanTranker();
        var repository = new TeacherRepository(context);

        // Obtener un maestro existente con sus estudiantes
        var teacher = await context.Teachers.AsNoTracking().Include(t => t.Students).FirstOrDefaultAsync();
        Assert.NotNull(teacher);  // Asegurarse de que hay un maestro disponible para la prueba

        // Usar el método del repositorio para obtener el maestro con sus estudiantes sin seguimiento
        var result = await repository.GetByIdWithStudentsAsNoTrackingAsync(teacher.Id);

        // Verificar que las entidades no están siendo rastreadas por el contexto
        var trackedEntities = context.ChangeTracker.Entries();
        Assert.Empty(trackedEntities); // Debe estar vacío ya que usamos AsNoTracking
    }

    [Fact]
    public async Task Get_Teacher_With_Students_By_Id_Should_Return_Null_If_Not_Found()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new TeacherRepository(context);

        // Usar un ID inexistente para la prueba
        var nonExistentTeacherId = Guid.NewGuid();

        // Usar el método del repositorio para obtener el maestro con sus estudiantes
        var result = await repository.GetByIdWithStudentsAsNoTrackingAsync(nonExistentTeacherId);

        // Verificar que el resultado es null
        Assert.Null(result);
    }
}
