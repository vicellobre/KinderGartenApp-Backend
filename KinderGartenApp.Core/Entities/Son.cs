using System.ComponentModel.DataAnnotations;


namespace KinderGartenApp.Core.Entities
{
	public class Son
	{
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Name { get; set; } = "";
        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Son), "ValidateDateBirth")]
        public DateTime BirthDate { get; set; }
        [Required]/////     ya se que no es asi pero lo dejo asi de momento mientras investigo como hacer que se asigne automaticamente, tenganme paciencia estoy aprendiendo
        public int ParentId { get; set; }
        public Padre Parent { get; set; } = new();

        public static ValidationResult ValidateDateBirth(DateTime BirthDate, ValidationContext context)
        {
            if (BirthDate > DateTime.Now)
            {
                return new ValidationResult("La fecha de nacimiento no puede ser mayor a la fecha actual.");
            }
            return ValidationResult.Success;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name) || Name.Length > 100)
                throw new ArgumentException("El nombre no puede estar vacío y debe tener un máximo de 100 caracteres.");

            if (BirthDate > DateTime.Now)
                throw new ArgumentException("La fecha de nacimiento no puede ser futura.");

            if (ParentId <= 0)
                throw new ArgumentException("El ID del padre no puede estar vacío.");
        }
    }
}