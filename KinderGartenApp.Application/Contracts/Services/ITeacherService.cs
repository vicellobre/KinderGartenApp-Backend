using KinderGartenApp.Application.DTOs.Teachers.Register;
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
    Task<Result<RegisterTeacherResponse>> Register(RegisterTeacherMessage message);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    //Task<Result<GetTeacherResponse>> Get(GetTeacherMessage message);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    //Task<Result<UpdateTeacherResponse>> Update(UpdateTeacherMessage message);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    //Task<Result<DeleteTeacherResponse>> Delete(DeleteTeacherMessage message);
}