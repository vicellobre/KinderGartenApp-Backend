using KinderGartenApp.Application.Contracts.Services;
using KinderGartenApp.Application.DTOs.Teachers.Register;
using KinderGartenApp.Application.Filters;
using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Contracts.UnitOfWorks;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Shared;

namespace KinderGartenApp.Infrastructure.Services;

/// <summary>
/// Servicio para la gestión de maestros (Teacher).
/// </summary>
public class TeacherService : ITeacherService
{
    /// <summary>
    /// Unidad de trabajo para manejar transacciones.
    /// </summary>
    public readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Repositorio de maestros.
    /// </summary>
    public readonly ITeacherRepository _teacherRepository;

    /// <summary>
    /// Inicializa una nueva instancia del servicio <see cref="TeacherService"/>.
    /// </summary>
    /// <param name="unitOfWork">La unidad de trabajo.</param>
    /// <param name="teacherRepository">El repositorio de maestros.</param>
    /// <exception cref="ArgumentNullException">Se lanza cuando alguno de los parámetros es nulo.</exception>
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
            // Convertir DTO a entidad Teacher
            var teacher = (Teacher)message;

            // Validar la entidad Teacher
            var validationResult = TeacherValidator.Validate(teacher);
            if (!validationResult.IsSuccess)
            {
                return Result<RegisterTeacherResponse>.Failure(validationResult.Errors);
            }

            // Normalizar la entidad Teacher
            teacher = TeacherFilter.Normalize(teacher);

            // Registrar el nuevo Teacher
            _teacherRepository.Add(teacher);
            await _unitOfWork.CommitAsync();

            // Convertir entidad Teacher a DTO de respuesta
            var response = (RegisterTeacherResponse)teacher;

            // Retornar el resultado exitoso
            return Result<RegisterTeacherResponse>.Success(response);
        }
        catch (Exception ex)
        {
            // Manejo de excepciones con tipo de excepción como código
            return Result<RegisterTeacherResponse>.Failure(ex);
        }
    }
}
