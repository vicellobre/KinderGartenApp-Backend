using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Tests.Scripts;
using Microsoft.EntityFrameworkCore;

namespace KinderGartenApp.Tests.Persistence.Contexts
{
    public class KinderGartenContextTests
    {
        [Fact]
        public async Task Can_Add_Parent()
        {
            // Crear el contexto con datos simulados
            var context = await TestContextFactory.CreateWithTracker();

            // Agregar un nuevo padre
            var newParent = Parent.Create(Guid.NewGuid(), "Mark", "Taylor", "mark.taylor@example.com", "password789", "456-789-0123");
            await context.Parents.AddAsync(newParent);
            await context.SaveChangesAsync();

            // Verificar que el padre se haya agregado correctamente
            var savedParent = await context.Parents.FindAsync(newParent.Id);
            Assert.NotNull(savedParent);
            Assert.Equal(newParent.FirstName, savedParent.FirstName);
            Assert.Equal(newParent.Email, savedParent.Email);
        }

        [Fact]
        public async Task Can_Add_Teacher()
        {
            // Crear el contexto con datos simulados
            var context = await TestContextFactory.CreateWithTracker();

            // Agregar un nuevo maestro
            var newTeacher = Teacher.Create(Guid.NewGuid(), "Emma", "Wilson", GradeLevel.Kinder2);
            await context.Teachers.AddAsync(newTeacher);
            await context.SaveChangesAsync();

            // Verificar que el maestro se haya agregado correctamente
            var savedTeacher = await context.Teachers.FindAsync(newTeacher.Id);
            Assert.NotNull(savedTeacher);
            Assert.Equal(newTeacher.FirstName, savedTeacher.FirstName);
            Assert.Equal(newTeacher.GradeLevel, savedTeacher.GradeLevel);
        }

        [Fact]
        public async Task Can_Add_Child()
        {
            // Crear el contexto con datos simulados
            var context = await TestContextFactory.CreateWithTracker();

            // Obtener un padre y un maestro existentes
            var parent = await context.Parents.FirstAsync();
            var teacher = await context.Teachers.FirstAsync();

            // Agregar un nuevo niño
            var newChild = Child.Create(Guid.NewGuid(), "Lucas", "Brown", new DateTime(2019, 7, 23), GradeLevel.Kinder2, parent.Id, teacher.Id);
            await context.Children.AddAsync(newChild);
            await context.SaveChangesAsync();

            // Verificar que el niño se haya agregado correctamente
            var savedChild = await context.Children.FindAsync(newChild.Id);
            Assert.NotNull(savedChild);
            Assert.Equal(newChild.FirstName, savedChild.FirstName);
            Assert.Equal(newChild.BirthDate, savedChild.BirthDate);
        }
    }
}
