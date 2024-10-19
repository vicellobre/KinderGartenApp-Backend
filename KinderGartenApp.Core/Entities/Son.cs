﻿using System.ComponentModel.DataAnnotations;


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
        [CustomValidation(typeof(Son), "ValidarFechaNacimiento")]
        public DateTime BirthDate { get; set; }
        [Required]/////     ya se que no es asi pero lo dejo asi de momento mientras investigo como hacer que se asigne automaticamente, tenganme paciencia estoy aprendiendo
        public int FatherId { get; set; }
        public Padre Father { get; set; } = new();

        public static ValidationResult ValidarFechaNacimiento(DateTime BirthDate, ValidationContext context)
        {
            if (BirthDate > DateTime.Now)
            {
                return new ValidationResult("La fecha de nacimiento no puede ser mayor a la fecha actual.");
            }
            return ValidationResult.Success;
        }
    }
}