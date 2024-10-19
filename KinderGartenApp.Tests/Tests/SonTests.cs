using KinderGartenApp.Core.Entities;

public class SonTests
{
    [Fact]
    public void Name_CantBeEmpty()
    {
        var son = new Son { Name = "", BirthDate = DateTime.Now.AddYears(-5), ParentId = 123 };

        var exception = Assert.Throws<ArgumentException>(() => son.Validate());
        Assert.Equal("El nombre no puede estar vacío y debe tener un máximo de 100 caracteres.", exception.Message);
    }

    [Fact]
    public void Name_CantBeUpToTheMaximumLength()
    {
        var son = new Son { Name = new string('a', 101), BirthDate = DateTime.Now.AddYears(-5), ParentId = 123 };

        var exception = Assert.Throws<ArgumentException>(() => son.Validate());
        Assert.Equal("El nombre no puede estar vacío y debe tener un máximo de 100 caracteres.", exception.Message);
    }

    [Fact]
    public void BirthDate_CantBeInTheFuture()
    {
        var son = new Son { Name = "Juan", BirthDate = DateTime.Now.AddDays(1), ParentId = 123 };

        var exception = Assert.Throws<ArgumentException>(() => son.Validate());
        Assert.Equal("La fecha de nacimiento no puede ser futura.", exception.Message);
    }

    [Fact]
    public void ParentId_CantBeZero()
    {
        var son = new Son { Name = "Juan", BirthDate = DateTime.Now.AddYears(-5), ParentId = 0 };

        var exception = Assert.Throws<ArgumentException>(() => son.Validate());
        Assert.Equal("El ID del padre no puede estar vacío.", exception.Message);
    }

    [Fact]
    public void Sons_CantBeRepeated()
    {
        var sons = new List<Son>
        {
            new Son { Name = "Juan", BirthDate = DateTime.Now.AddYears(-5), ParentId = 123 },
            new Son { Name = "Juan", BirthDate = DateTime.Now.AddYears(-5), ParentId = 123 }
        };

        var duplicatedList = sons.GroupBy(x => new { x.Name, x.BirthDate, x.ParentId })
                            .Select(g => new { Key = g.Key, Count = g.Count() })
                            .ToList();

        var isDuplicated = duplicatedList.Count > 1;
        Assert.True(isDuplicated);
    }
}
