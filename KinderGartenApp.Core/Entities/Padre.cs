using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KinderGartenApp.Core.Entities;

public class Padre
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo nombre no debe ser vacío")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El campo de correo no debe ser vacío")]
    public string Email { get; set; }

    [Required(ErrorMessage = "El campo de contraseña no debe ser vacío")]
    public string Password;

    [RegularExpression("^[0-9]{10}$", ErrorMessage = "El número telefónico debe tener diez (10) dígitos")]
    public string Telefono { get; set; }
}