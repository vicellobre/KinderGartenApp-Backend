using KinderGartenApp.Application.DTOs.Children.AddTeacher;
using KinderGartenApp.Application.DTOs.Children.AddParent;
using KinderGartenApp.Application.DTOs.Children.Deletes;
using KinderGartenApp.Application.DTOs.Children.Get;
using KinderGartenApp.Application.DTOs.Children.Register;
using KinderGartenApp.Application.DTOs.Children.Update;
using KinderGartenApp.Core.Shared;

namespace KinderGartenApp.Application.Contracts.Services;

/// <summary>
/// Interface que define los métodos para la gestión de niños (Child).
/// </summary>
public interface IChildService
{
    /// <summary>
    /// Registra un nuevo niño (Child).
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del niño a registrar.</param>
    /// <returns>Un resultado que contiene la respuesta del registro del niño.</returns>
    Task<Result<RegisterChildResponse>> Register(RegisterChildMessage message);

    /// <summary>
    /// Obtiene un niño (Child) por su identificador.
    /// </summary>
    /// <param name="message">El mensaje que contiene el identificador del niño a obtener.</param>
    /// <returns>Un resultado que contiene la respuesta del niño obtenido.</returns>
    Task<Result<GetChildResponse>> Get(GetChildMessage message);

    /// <summary>
    /// Actualiza un niño (Child).
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del niño a actualizar.</param>
    /// <returns>Un resultado que contiene la respuesta del niño actualizado.</returns>
    Task<Result<UpdateChildResponse>> Update(UpdateChildMessage message);

    /// <summary>
    /// Elimina un niño (Child).
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del niño a eliminar.</param>
    /// <returns>Un resultado que contiene la respuesta del niño eliminado.</returns>
    Task<Result<DeleteChildResponse>> Delete(DeleteChildMessage message);

    /// <summary>
    /// Añade un maestro a un niño.
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del maestro a añadir.</param>
    /// <returns>Un resultado que contiene la respuesta del maestro añadido.</returns>
    Task<Result<AddTeacherResponse>> AddTeacher(AddTeacherMessage message);

    /// <summary>
    /// Añade un padre a un niño.
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del padre a añadir.</param>
    /// <returns>Un resultado que contiene la respuesta del padre añadido.</returns>
    Task<Result<AddParentResponse>> AddParent(AddParentMessage message);
}
