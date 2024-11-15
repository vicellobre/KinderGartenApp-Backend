using KinderGartenApp.Core.Enumarations;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Tests.Scripts;

namespace KinderGartenApp.Tests.Persistence.Repositories;

public partial class TeacherRepositoryTests
{
    [Fact]
    public async Task Can_Get_All_Teachers_By_GradeLevel()
    {
        // Crear el contexto con datos simulados
        var context = await TestContextFactory.CreateWithTracker();
        var repository = new TeacherRepository(context);

        // Obtener maestros por nivel educativo
        var gradeLevel = GradeLevel.Kinder1;
        var teachers = await repository.GetAllByGradeLevel(gradeLevel);

        // Verificar que se hayan obtenido los maestros correctos
        Assert.NotNull(teachers);
        Assert.All(teachers, t => Assert.Equal(gradeLevel, t.GradeLevel));
    }

    [Fact]
    public async Task Cant_Get_All_Teachers_By_GradeLevel_When_Empty()
    {
        // Crear el contexto sin datos simulados (vacío)
        var context = TestContextFactory.Create();
        var repository = new TeacherRepository(context);

        // Probar obtener maestros para un nivel educativo sin maestros
        var emptyGradeLevel = GradeLevel.Kinder2;
        var emptyTeachers = await repository.GetAllByGradeLevel(emptyGradeLevel);

        // Verificar que la lista de maestros está vacía
        Assert.NotNull(emptyTeachers);
        Assert.Empty(emptyTeachers);
    }
}
