using KinderGartenApp.Application.DTOs.Teachers.AddStudent;
using KinderGartenApp.Application.DTOs.Teachers.Deletes;
using KinderGartenApp.Application.DTOs.Teachers.Get;
using KinderGartenApp.Application.DTOs.Teachers.Register;
using KinderGartenApp.Application.DTOs.Teachers.Update;
using KinderGartenApp.Core.Shared;

namespace KinderGartenApp.Application.Contracts.Services;

/// <summary>
/// Interface que define los métodos para la gestión de maestros (Teacher).
/// </summary>
public interface ITeacherService
{
    /// <summary>
    /// Registra un nuevo maestro (Teacher).
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del maestro a registrar.</param>
    /// <returns>Un resultado que contiene la respuesta del registro del maestro.</returns>
    Task<Result<RegisterTeacherResult>> Register(RegisterTeacherMessage message);

    /// <summary>
    /// Obtiene un maestro (Teacher) por su identificador.
    /// </summary>
    /// <param name="message">El mensaje que contiene el identificador del maestro a obtener.</param>
    /// <returns>Un resultado que contiene la respuesta del maestro obtenido.</returns>
    Task<Result<GetTeacherResult>> Get(GetTeacherMessage message);

    /// <summary>
    /// Actualiza un maestro (Teacher).
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del maestro a actualizar.</param>
    /// <returns>Un resultado que contiene la respuesta del maestro actualizado.</returns>
    Task<Result<UpdateTeacherResult>> Update(UpdateTeacherMessage message);

    /// <summary>
    /// Elimina un maestro (Teacher).
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del maestro a eliminar.</param>
    /// <returns>Un resultado que contiene la respuesta del maestro eliminado.</returns>
    Task<Result<DeleteTeacherResult>> Delete(DeleteTeacherMessage message);

    /// <summary>
    /// Añade un estudiante a un maestro.
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del estudiante a añadir.</param>
    /// <returns>Un resultado que contiene la respuesta del estudiante añadido.</returns>
    Task<Result<AddStudentResult>> AddStudent(AddStudentMessage message);
}
