using KinderGartenApp.Core;
using KinderGartenApp.Core.Entities;

public class ChildTests
{
    [Fact]
    public void Name_CantBeEmpty()
    {
        var child = new Child { FullName = "", BirthDate = DateTime.Now.AddYears(-5), ParentId = 123 };

        var exception = Assert.Throws<ArgumentException>(() => ChildValidator.Validate(child));
        Assert.Equal("El nombre no puede estar vacío o empezar o terminar con un espacio en blanco.", exception.Message);
    }

    [Fact]
    public void Name_CantStartWithBlank()
    {
        var child = new Child { FullName = " jose", BirthDate = DateTime.Now.AddYears(-5), ParentId = 123 };

        var exception = Assert.Throws<ArgumentException>(() => ChildValidator.Validate(child));
        Assert.Equal("El nombre no puede estar vacío o empezar o terminar con un espacio en blanco.", exception.Message);
    }

    [Fact]
    public void Name_CantEndWithBlank()
    {
        var child = new Child { FullName = "jose ", BirthDate = DateTime.Now.AddYears(-5), ParentId = 123 };

        var exception = Assert.Throws<ArgumentException>(() => ChildValidator.Validate(child));
        Assert.Equal("El nombre no puede estar vacío o empezar o terminar con un espacio en blanco.", exception.Message);
    }

    [Fact]
    public void Name_CantBeUpToTheMaximumLength()
    {
        var child = new Child { FullName = new string('a', 101), BirthDate = DateTime.Now.AddYears(-5), ParentId = 123 };

        var exception = Assert.Throws<ArgumentException>(() => ChildValidator.Validate(child));
        Assert.Equal("El nombre no puede tener más de 100 caracteres.", exception.Message);
    }

    [Fact]
    public void BirthDate_CantBeInTheFuture()
    {
        var child = new Child { FullName = "Juan", BirthDate = DateTime.Now.AddDays(1), ParentId = 123 };

        var exception = Assert.Throws<ArgumentException>(() => ChildValidator.Validate(child));
        Assert.Equal("La fecha de nacimiento no puede ser mayor a la fecha actual.", exception.Message);
    }

    [Fact]
    public void ParentId_CantBeZero()
    {
        var child = new Child { FullName = "Juan", BirthDate = DateTime.Now.AddYears(-5), ParentId = 0 };

        var exception = Assert.Throws<ArgumentException>(() => ChildValidator.Validate(child));
        Assert.Equal("El ID del padre no puede ser menor o igual a 0.", exception.Message);
    }

    [Fact]
    public void ParentId_CantBeLowerThanZero()
    {
        var child = new Child { FullName = "Juan", BirthDate = DateTime.Now.AddYears(-5), ParentId = -1 };

        var exception = Assert.Throws<ArgumentException>(() => ChildValidator.Validate(child));
        Assert.Equal("El ID del padre no puede ser menor o igual a 0.", exception.Message);
    }

    [Fact]
    public void ChildId_CantBeRepeated()
    {
        var children = new List<Child>
        {
            new Child { Id = Guid.NewGuid(), FullName = "Juan", BirthDate = DateTime.Now.AddYears(-5), ParentId = 123 },
            new Child { Id = Guid.NewGuid(), FullName = "Pablo", BirthDate = DateTime.Now.AddYears(-5), ParentId = 321 }
        };

        Assert.NotEqual(children[0].Id, children[1].Id);
    }

    [Fact]
    public void Sons_CantBeRepeated()
    {
        var children = new List<Child>
        {
            new Child { FullName = "Juan", BirthDate = DateTime.Now.AddYears(-5), ParentId = 123 },
            new Child { FullName = "Juan", BirthDate = DateTime.Now.AddYears(-5), ParentId = 123 }
        };

        var duplicatedList = children.GroupBy(x => new { x.FullName, x.BirthDate, x.ParentId })
                            .Select(g => new { Key = g.Key, Count = g.Count() })
                            .ToList();

        var isDuplicated = duplicatedList.Count > 1;
        Assert.True(isDuplicated);
    }
}
