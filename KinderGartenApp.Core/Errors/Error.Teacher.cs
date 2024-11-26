namespace KinderGartenApp.Core.Errors;

/// <summary>
/// Representa un error con un código y un mensaje descriptivo.
/// </summary>
public readonly partial record struct Error
{
    /// <summary>
    /// Errores específicos relacionados con la entidad Teacher.
    /// </summary>
    public static class Teacher
    {
        /// <summary>
        /// Error que se produce cuando no se encuentra un maestro.
        /// </summary>
        public static readonly Error NotFound = new("Teacher.NotFound", "Teacher not found");

        /// <summary>
        /// Error que se produce cuando un maestro es nulo.
        /// </summary>
        public static readonly Error IsNull = new("Teacher.IsNull", "Teacher cannot be null");

        /// <summary>
        /// Error que se produce cuando el nivel educativo del maestro y el estudiante no coinciden.
        /// </summary>
        public static readonly Func<Enumarations.GradeLevel, Error> GradeLevelMismatch = gradeLevel =>
            new Error("Teacher.GradeLevelMismatch", $"The teacher is from {gradeLevel} grade. Please ensure the teacher and student are in the same grade level.");
    }

    /// <summary>
    /// Errores específicos relacionados con las solicitudes de Teacher.
    /// </summary>
    public static class TeacherRequest
    {
        /// <summary>
        /// Error que se produce cuando la solicitud de registro del maestro es nula.
        /// </summary>
        public static readonly Error RegisterIsNull = new("TeacherRequest.RegisterIsNull", "RegisterTeacher request cannot be null");

        /// <summary>
        /// Error que se produce cuando la solicitud de actualización del maestro es nula.
        /// </summary>
        public static readonly Error UpdateIsNull = new("TeacherRequest.UpdateIsNull", "UpdateTeacher request cannot be null");
    }
}

