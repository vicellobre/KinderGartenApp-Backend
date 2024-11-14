using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class TeacherRepositoryTests
{
    [Fact]
    public async Task Can_Add_Teacher()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.InitializeDataAsync();
        var repository = new TeacherRepository(context);

        // Agregar un nuevo maestro
        var newTeacher = Teacher.Create(Guid.NewGuid(), "Emma", "Wilson", GradeLevel.Kinder2);
        repository.Add(newTeacher);
        await context.SaveChangesAsync();

        // Verificar que el maestro se haya agregado correctamente
        var savedTeacher = await repository.GetByIdAsync(newTeacher.Id);
        Assert.NotNull(savedTeacher);
        Assert.Equal(newTeacher.FirstName, savedTeacher.FirstName);
        Assert.Equal(newTeacher.GradeLevel, savedTeacher.GradeLevel);
    }

    [Fact]
    public async Task Cant_Add_Null_Teacher()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.InitializeDataAsync();
        var repository = new TeacherRepository(context);

        // Contar maestros antes de intentar eliminar un maestro nulo
        var initialCount = await context.Teachers.CountAsync();

        // Intentar agregar un maestro nulo
        Teacher? nullTeacher = null;

        // Se espera una excepción al intentar agregar un maestro nulo
        await Assert.ThrowsAsync<ArgumentNullException>(() => {
            repository.Add(nullTeacher!);
            return context.SaveChangesAsync();
        });

        // Contar maestros después de intentar agregar un maestro nulo
        var finalCount = await context.Teachers.CountAsync();
        // Verificar que la cantidad de maestros no haya cambiado
        Assert.Equal(initialCount, finalCount);
    }

    [Fact]
    public async Task Cant_Add_Duplicate_Teacher()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.InitializeDataAsync();
        var repository = new TeacherRepository(context);

        // Obtener un maestro existente
        var existingTeacher = await context.Teachers.FirstAsync();

        // Detach the existing entity to simulate adding a duplicate entity
        context.Entry(existingTeacher).State = EntityState.Detached;

        // Intentar agregar el mismo maestro nuevamente
        var duplicateTeacher = Teacher.Create(existingTeacher.Id, existingTeacher.FirstName, existingTeacher.LastName, existingTeacher.GradeLevel);

        // Agregar el maestro duplicado y esperar una excepción
        await Assert.ThrowsAsync<ArgumentException>(() => {
            repository.Add(duplicateTeacher);
            return context.SaveChangesAsync();
        });

        // Verificar que no se haya agregado un maestro duplicado
        var teachers = await repository.GetAllAsync();
        var count = await context.Teachers.CountAsync(t => t.Id == existingTeacher.Id);
        Assert.Equal(1, count);
    }
}
