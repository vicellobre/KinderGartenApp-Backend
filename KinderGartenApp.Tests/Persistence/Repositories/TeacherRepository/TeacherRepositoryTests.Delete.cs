using System;
using System.Threading.Tasks;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace KinderGartenApp.Tests.Persistence.Repositories
{
    public partial class TeacherRepositoryTests
    {
        [Fact]
        public async Task Can_Delete_Teacher()
        {
            // Crear el contexto con datos simulados
            var context = await TestContextFactory.InitializeDataAsync();
            var repository = new TeacherRepository(context);

            // Obtener un maestro existente
            var teacher = await context.Teachers.FirstAsync();

            // Eliminar el maestro
            repository.Delete(teacher);
            await context.SaveChangesAsync();

            // Verificar que el maestro se haya eliminado correctamente
            var deletedTeacher = await repository.GetByIdAsync(teacher.Id);
            Assert.Null(deletedTeacher);
        }

        [Fact]
        public async Task Cant_Delete_Null_Teacher()
        {
            // Crear el contexto con datos simulados
            var context = await TestContextFactory.InitializeDataAsync();
            var repository = new TeacherRepository(context);

            // Contar maestros antes de intentar eliminar un maestro nulo
            var initialCount = await context.Teachers.CountAsync();

            // Intentar eliminar un maestro nulo
            Teacher? nullTeacher = null;

            // Se espera una excepción al intentar eliminar un maestro nulo
            await Assert.ThrowsAsync<ArgumentNullException>(() => {
                repository.Delete(nullTeacher!);
                return context.SaveChangesAsync();
            });

            // Contar maestros después de intentar eliminar un maestro nulo
            var finalCount = await context.Teachers.CountAsync();

            // Verificar que la cantidad de maestros no haya cambiado
            Assert.Equal(initialCount, finalCount);
        }

        [Fact]
        public async Task Cant_Delete_NonExistent_Teacher()
        {
            // Crear el contexto con datos simulados
            var context = await TestContextFactory.InitializeDataAsync();
            var repository = new TeacherRepository(context);

            // Contar maestros antes de intentar eliminar un maestro inexistente
            var initialCount = await context.Teachers.CountAsync();

            // Crear un maestro con un ID inexistente
            var nonExistentTeacher = Teacher.Create(Guid.NewGuid(), "Non", "Existent", GradeLevel.Kinder3);

            // Intentar eliminar el maestro inexistente y manejar la excepción
            await Assert.ThrowsAsync<DbUpdateConcurrencyException>(() => {
                repository.Delete(nonExistentTeacher);
                return context.SaveChangesAsync();
            });

            // Contar maestros después de intentar eliminar un maestro inexistente
            var finalCount = await context.Teachers.CountAsync();

            // Verificar que la cantidad de maestros no haya cambiado
            Assert.Equal(initialCount, finalCount);
        }
    }
}
