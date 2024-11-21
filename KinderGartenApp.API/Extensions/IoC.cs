﻿using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Contracts.UnitOfWorks;
using KinderGartenApp.Persistence.Contexts;
using KinderGartenApp.Persistence.Repositories;
using KinderGartenApp.Persistence.UnitOfWorks;
using System.Diagnostics.CodeAnalysis;

namespace KinderGartenApp.API.Extensions;

/// <summary>
/// Proporciona métodos de extensión para la inyección de dependencias.
/// </summary>
[ExcludeFromCodeCoverage]
public static class IoC
{
    /// <summary>
    /// Agrega las dependencias necesarias al contenedor de servicios.
    /// </summary>
    /// <param name="services">La colección de servicios a la que se agregarán las dependencias.</param>
    /// <returns>La colección de servicios con las dependencias agregadas.</returns>
    public static IServiceCollection AddDependency(this IServiceCollection services)
    {
        // Inyectar UnitOfWork
        services.AddScoped<IUnitOfWork>(p => new UnitOfWork(p.GetRequiredService<KinderGartenContext>()));

        // Inyectar los servicios específicos de Parent, Teacher y Child
        services.AddScoped<ITeacherRepository>(p => new TeacherRepository(p.GetRequiredService<KinderGartenContext>()));
        services.AddScoped<IChildRepository>(c => new ChildRepository(c.GetRequiredService<KinderGartenContext>()));
        services.AddScoped<IParentRepository>(x => new ParentRepository(x.GetRequiredService<KinderGartenContext>()));

        return services;
    }
}
