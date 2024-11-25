using KinderGartenApp.Application.Contracts.Services;
using KinderGartenApp.Application.DTOs.Teachers.Deletes;
using KinderGartenApp.Application.DTOs.Teachers.Get;
using KinderGartenApp.Application.DTOs.Teachers.Register;
using KinderGartenApp.Application.DTOs.Teachers.Update;
using KinderGartenApp.Application.Filters;
using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Contracts.UnitOfWorks;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Shared;

namespace KinderGartenApp.Infrastructure.Services;

/// <summary>
/// Servicio para la gestión de maestros (Teacher).
/// </summary>
public class TeacherService : ITeacherService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(IUnitOfWork? unitOfWork, ITeacherRepository? teacherRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _teacherRepository = teacherRepository ?? throw new ArgumentNullException(nameof(teacherRepository));
    }

    /// <summary>
    /// Registra un nuevo maestro (Teacher).
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del maestro a registrar.</param>
    /// <returns>Un resultado que contiene la respuesta del registro del maestro.</returns>
    public async Task<Result<RegisterTeacherResponse>> Register(RegisterTeacherMessage message)
    {
        try
        {
            var teacher = (Teacher)message;
            var validationResult = TeacherValidator.Validate(teacher);
            if (!validationResult.IsSuccess)
            {
                return Result<RegisterTeacherResponse>.Failure(validationResult.Errors);
            }

            teacher = TeacherFilter.Normalize(teacher);
            _teacherRepository.Add(teacher);
            await _unitOfWork.CommitAsync();

            var response = (RegisterTeacherResponse)teacher;

            return Result<RegisterTeacherResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<RegisterTeacherResponse>.Failure(ex);
        }
    }

    /// <summary>
    /// Obtiene un maestro (Teacher) por su identificador.
    /// </summary>
    /// <param name="message">El mensaje que contiene el identificador del maestro a obtener.</param>
    /// <returns>Un resultado que contiene la respuesta del maestro obtenido.</returns>
    public async Task<Result<GetTeacherResponse>> Get(GetTeacherMessage message)
    {
        try
        {
            var teacher = await _teacherRepository.GetByIdAsync(message.Id);

            if (teacher is null)
            {
                return Result<GetTeacherResponse>.Failure(Error.Create("NotFound", "Teacher not found"));
            }

            var response = (GetTeacherResponse)teacher;

            return Result<GetTeacherResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<GetTeacherResponse>.Failure(ex);
        }
    }

    /// <summary>
    /// Actualiza un maestro (Teacher).
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del maestro a actualizar.</param>
    /// <returns>Un resultado que contiene la respuesta del maestro actualizado.</returns>
    public async Task<Result<UpdateTeacherResponse>> Update(UpdateTeacherMessage message)
    {
        try
        {
            var existingTeacher = await _teacherRepository.GetByIdAsync(message.Id);
            if (existingTeacher is null)
            {
                return Result<UpdateTeacherResponse>.Failure(Error.Create("NotFound", "Teacher not found"));
            }

            var teacher = (Teacher)message;
            var validationResult = TeacherValidator.Validate(teacher);
            if (!validationResult.IsSuccess)
            {
                return Result<UpdateTeacherResponse>.Failure(validationResult.Errors);
            }
            
            teacher = TeacherFilter.Normalize(teacher);

            // Actualizar los campos de existingTeacher con los valores de teacher
            existingTeacher.FirstName = teacher.FirstName;
            existingTeacher.LastName = teacher.LastName;
            existingTeacher.GradeLevel = teacher.GradeLevel;

            await _unitOfWork.CommitAsync();

            var response = (UpdateTeacherResponse)teacher;

            return Result<UpdateTeacherResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<UpdateTeacherResponse>.Failure(ex);
        }
    }

    /// <summary>
    /// Elimina un maestro (Teacher).
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del maestro a eliminar.</param>
    /// <returns>Un resultado que contiene la respuesta del maestro eliminado.</returns>
    public async Task<Result<DeleteTeacherResponse>> Delete(DeleteTeacherMessage message)
    {
        try
        {
            var existingTeacher = await _teacherRepository.GetByIdAsync(message.Id);
            if (existingTeacher is null)
            {
                return Result<DeleteTeacherResponse>.Failure(Error.Create("NotFound", "Teacher not found"));
            }

            _teacherRepository.Remove(existingTeacher);
            await _unitOfWork.CommitAsync();

            var response = (DeleteTeacherResponse)existingTeacher;

            return Result<DeleteTeacherResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<DeleteTeacherResponse>.Failure(ex);
        }
    }

}
