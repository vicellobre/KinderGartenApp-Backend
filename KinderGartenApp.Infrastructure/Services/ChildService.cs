using KinderGartenApp.Application.Contracts.Services;
using KinderGartenApp.Application.DTOs.Children.AddParent;
using KinderGartenApp.Application.DTOs.Children.AddTeacher;
using KinderGartenApp.Application.DTOs.Children.Deletes;
using KinderGartenApp.Application.DTOs.Children.Get;
using KinderGartenApp.Application.DTOs.Children.Register;
using KinderGartenApp.Application.DTOs.Children.Update;
using KinderGartenApp.Application.Filters;
using KinderGartenApp.Application.Validators;
using KinderGartenApp.Core.Contracts.Repositories;
using KinderGartenApp.Core.Contracts.UnitOfWorks;
using KinderGartenApp.Core.Entities;
using KinderGartenApp.Core.Errors;
using KinderGartenApp.Core.Shared;

namespace KinderGartenApp.Infrastructure.Services;

/// <summary>
/// Servicio para la gestión de niños (Child).
/// </summary>
public class ChildService : IChildService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITeacherRepository _teacherRepository;
    private readonly IChildRepository _studentRepository;
    private readonly IParentRepository _parentRepository;

    public ChildService(IUnitOfWork? unitOfWork, ITeacherRepository? teacherRepository, IChildRepository? studentRepository, IParentRepository? parentRepository)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _teacherRepository = teacherRepository ?? throw new ArgumentNullException(nameof(teacherRepository));
        _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        _parentRepository = parentRepository ?? throw new ArgumentNullException(nameof(parentRepository));
    }

    /// <summary>
    /// Registra un nuevo niño (Child).
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del niño a registrar.</param>
    /// <returns>Un resultado que contiene la respuesta del registro del niño.</returns>
    public async Task<Result<RegisterChildResponse>> Register(RegisterChildMessage message)
    {
        try
        {
            var student = (Child)message;
            var validationResult = ChildValidator.Validate(student);
            if (!validationResult.IsSuccess)
            {
                return Result<RegisterChildResponse>.Failure(validationResult.Errors);
            }

            student = ChildFilter.Normalize(student);
            _studentRepository.Add(student);
            await _unitOfWork.CommitAsync();

            var response = (RegisterChildResponse)student;

            return Result<RegisterChildResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<RegisterChildResponse>.Failure(ex);
        }
    }

    /// <summary>
    /// Obtiene un niño (Child) por su identificador.
    /// </summary>
    /// <param name="message">El mensaje que contiene el identificador del niño a obtener.</param>
    /// <returns>Un resultado que contiene la respuesta del niño obtenido.</returns>
    public async Task<Result<GetChildResponse>> Get(GetChildMessage message)
    {
        try
        {
            var child = await _studentRepository.GetByIdAsync(message.Id);

            if (child is null)
            {
                return Result<GetChildResponse>.Failure(Error.Children.NotFound);
            }

            var response = (GetChildResponse)child;

            return Result<GetChildResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<GetChildResponse>.Failure(ex);
        }
    }

    /// <summary>
    /// Actualiza un niño (Child).
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del niño a actualizar.</param>
    /// <returns>Un resultado que contiene la respuesta del niño actualizado.</returns>
    public async Task<Result<UpdateChildResponse>> Update(UpdateChildMessage message)
    {
        try
        {
            var studentToUpdate = await _studentRepository.GetByIdAsync(message.Id);
            if (studentToUpdate is null)
            {
                return Result<UpdateChildResponse>.Failure(Error.Children.NotFound);
            }

            var child = (Child)message;
            var validationResult = ChildValidator.Validate(child);
            if (!validationResult.IsSuccess)
            {
                return Result<UpdateChildResponse>.Failure(validationResult.Errors);
            }
            
            child = ChildFilter.Normalize(child);

            // Actualizar los campos de studentToUpdate con los valores de child
            studentToUpdate.FirstName = child.FirstName;
            studentToUpdate.LastName = child.LastName;
            studentToUpdate.GradeLevel = child.GradeLevel;

            await _unitOfWork.CommitAsync();

            var response = (UpdateChildResponse)child;

            return Result<UpdateChildResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<UpdateChildResponse>.Failure(ex);
        }
    }

    /// <summary>
    /// Elimina un niño (Child).
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del niño a eliminar.</param>
    /// <returns>Un resultado que contiene la respuesta del niño eliminado.</returns>
    public async Task<Result<DeleteChildResponse>> Delete(DeleteChildMessage message)
    {
        try
        {
            var studentToUpdate = await _studentRepository.GetByIdAsync(message.Id);
            if (studentToUpdate is null)
            {
                return Result<DeleteChildResponse>.Failure(Error.Children.NotFound);
            }

            _studentRepository.Delete(studentToUpdate);
            await _unitOfWork.CommitAsync();

            var response = (DeleteChildResponse)studentToUpdate;

            return Result<DeleteChildResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<DeleteChildResponse>.Failure(ex);
        }
    }

    /// <summary>
    /// Añade un maestro a un niño.
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del maestro a añadir.</param>
    /// <returns>Un resultado que contiene la respuesta del maestro añadido.</returns>
    public async Task<Result<AddTeacherResponse>> AddTeacher(AddTeacherMessage message)
    {
        try
        {
            var child = await _studentRepository.GetByIdAsync(message.ChildId);
            if (child is null)
            {
                return Result<AddTeacherResponse>.Failure(Error.Children.NotFound);
            }

            var teacher = await _teacherRepository.GetByIdAsync(message.TeacherId);
            if (teacher is null)
            {
                return Result<AddTeacherResponse>.Failure(Error.Children.NotFound);
            }

            // Asignar el maestro al niño
            child.TeacherId = message.TeacherId;

            await _unitOfWork.CommitAsync();

            var response = new AddTeacherResponse
            {
                ChildId = child.Id,
                ChildFirstName = child.FirstName,
                ChildLastName = child.LastName,
                TeacherId = teacher.Id,
                TeacherFirstName = teacher.FirstName,
                TeacherLastName = teacher.LastName
            };

            return Result<AddTeacherResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<AddTeacherResponse>.Failure(ex);
        }
    }

    /// <summary>
    /// Añade un padre a un niño.
    /// </summary>
    /// <param name="message">El mensaje que contiene los detalles del padre a añadir.</param>
    /// <returns>Un resultado que contiene la respuesta del padre añadido.</returns>
    public async Task<Result<AddParentResponse>> AddParent(AddParentMessage message)
    {
        try
        {
            var child = await _studentRepository.GetByIdAsync(message.ChildId);
            if (child is null)
            {
                return Result<AddParentResponse>.Failure(Error.Children.NotFound);
            }

            var parent = await _parentRepository.GetByIdAsync(message.ParentId);
            if (parent is null)
            {
                return Result<AddParentResponse>.Failure(Error.Children.NotFound);
            }

            // Asignar el padre al niño
            child.ParentId = message.ParentId;

            await _unitOfWork.CommitAsync();

            var response = new AddParentResponse
            {
                ChildId = child.Id,
                ChildFirstName = child.FirstName,
                ChildLastName = child.LastName,
                ParentId = parent.Id,
                ParentFirstName = parent.FirstName,
                ParentLastName = parent.LastName
            };

            return Result<AddParentResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<AddParentResponse>.Failure(ex);
        }
    }
}
