using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class TeacherRepositoryTests
{
    [Fact]
    public async Task Can_Update_Teacher()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new TeacherRepository(context);

        // Obtener un maestro existente
        var teacher = await context.Teachers.FirstAsync();

        // Actualizar el nombre del maestro
        teacher.FirstName = "UpdatedName";
        repository.Update(teacher);
        await context.SaveChangesAsync();

        // Verificar que el maestro se haya actualizado correctamente
        var updatedTeacher = await repository.GetByIdAsync(teacher.Id);
        Assert.NotNull(updatedTeacher);
        Assert.Equal("UpdatedName", updatedTeacher.FirstName);
    }

    [Fact]
    public async Task Cannot_Update_Null_Teacher_With_Clean_ChangeTracker()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.CreateWithCleanTranker();
        var repository = new TeacherRepository(context);

        // Intentar actualizar un maestro nulo
        Teacher? nullTeacher = null;

        // Se espera una excepción al intentar actualizar un maestro nulo
        await Assert.ThrowsAsync<NullReferenceException>(() => {
            repository.Update(nullTeacher!);
            return context.SaveChangesAsync();
        });

        // Verificar que no se haya actualizado ningún maestro con nombre nulo
        var teachers = await repository.GetAllAsync();
        Assert.All(teachers, t => Assert.NotNull(t.FirstName));
    }

    [Fact]
    public async Task Cannot_Update_Null_Teacher_With_Unclean_ChangeTracker()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new TeacherRepository(context);

        // Intentar actualizar un maestro nulo
        Teacher? nullTeacher = null;

        // Se espera una excepción al intentar actualizar un maestro nulo
        await Assert.ThrowsAsync<ArgumentNullException>(() => {
            repository.Update(nullTeacher!);
            return context.SaveChangesAsync();
        });

        // Verificar que no se haya actualizado ningún maestro con nombre nulo
        var teachers = await repository.GetAllAsync();
        Assert.All(teachers, t => Assert.NotNull(t.FirstName));
    }

    [Fact]
    public async Task Cant_Update_NonExistent_Teacher()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new TeacherRepository(context);

        // Crear un maestro con un ID inexistente
        var nonExistentTeacher = Teacher.Create(Guid.NewGuid(), "Non", "Existent", GradeLevel.Kinder3);

        // Intentar actualizar el maestro inexistente
        nonExistentTeacher.FirstName = "UpdatedName";
        repository.Update(nonExistentTeacher);

        // Se espera una excepción al intentar guardar los cambios
        await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => {
            return context.SaveChangesAsync();
        });

        // Verificar que no se haya actualizado ningún maestro inexistente
        var teachers = await repository.GetAllAsync();
        Assert.All(teachers, t => Assert.NotEqual("Non", t.FirstName));
    }
}
