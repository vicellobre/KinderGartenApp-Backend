using KinderGartenApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace KinderGartenApp.Persistence.Contexts;

/// <summary>
/// El contexto de la base de datos para la aplicación KinderGartenApp.
/// </summary>
[ExcludeFromCodeCoverage]
public class KinderGartenContext : DbContext
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="KinderGartenContext"/> con las opciones especificadas.
    /// </summary>
    /// <param name="options">Las opciones de configuración del contexto.</param>
    /// <param name="configuration">La configuración de la aplicación.</param>
    public KinderGartenContext(DbContextOptions<KinderGartenContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    /// <summary>
    /// Obtiene o establece la colección de niños en el contexto.
    /// </summary>
    public DbSet<Child> Children { get; set; }

    /// <summary>
    /// Obtiene o establece la colección de padres en el contexto.
    /// </summary>
    public DbSet<Parent> Parents { get; set; }

    /// <summary>
    /// Obtiene o establece la colección de maestros en el contexto.
    /// </summary>
    public DbSet<Teacher> Teachers { get; set; }

    /// <summary>
    /// Configura las opciones del contexto.
    /// </summary>
    /// <param name="optionsBuilder">El constructor de opciones del contexto.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration.GetConnectionString("ConnectionKinderGarten");
        optionsBuilder.UseSqlServer(connectionString);
    }

    /// <summary>
    /// Configura el modelo de datos para el contexto.
    /// </summary>
    /// <param name="modelBuilder">El constructor del modelo.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Padres
        modelBuilder.Entity<Parent>(parent =>
        {
            parent.ToTable("Parents");
            parent.HasKey(p => p.Id);
            parent.Property(t => t.FirstName).IsRequired();
            parent.Property(t => t.LastName).IsRequired();
            parent.Property(t => t.Email).IsRequired().HasMaxLength(100);
            parent.Property(p => p.Password).IsRequired().HasMaxLength(50);
            parent.Property(e => e.Phone).HasMaxLength(15);
            parent.HasIndex(p => p.Email).IsUnique();

            parent.Ignore(p => p.Sons);
        });

        // Maestros
        modelBuilder.Entity<Teacher>(teacher =>
        {
            teacher.ToTable("Teachers");
            teacher.HasKey(t => t.Id);
            teacher.Property(t => t.FirstName).IsRequired();
            teacher.Property(t => t.LastName).IsRequired();
            teacher.Property(t => t.GradeLevel).IsRequired();

            teacher.Ignore(t => t.Students);
        });

        // Niños
        modelBuilder.Entity<Child>(child =>
        {
            child.ToTable("Children");
            child.HasKey(c => c.Id);
            child.Property(c => c.FirstName).IsRequired();
            child.Property(c => c.LastName).IsRequired();
            child.Property(c => c.BirthDate).IsRequired();
            child.Property(c => c.GradeLevel).IsRequired();
            // relación con padres
            child.HasOne(c => c.Parent)
                 .WithMany(c => c.Sons)
                 .HasForeignKey(c => c.ParentId);
            // relación con maestros
            child.HasOne(c => c.Teacher)
                 .WithMany(c => c.Students)
                 .HasForeignKey(c => c.TeacherId);
        });
    }
}
