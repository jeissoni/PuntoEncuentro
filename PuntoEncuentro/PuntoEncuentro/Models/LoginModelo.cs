using System.ComponentModel.DataAnnotations;

namespace PuntoEncuentro.Models
{
    public class LoginModelo
    {
        [Required] //Dato requerido //Validar que se ingrese un email valido
        [Display(Name = "Usuario")] //Mensaje indicar obligatorio
        public string InputUsuario { get; set; }

        [Required] //Dato requerido
        [DataType(DataType.Password)] //Indicar dato  tipo password
        [StringLength(20, MinimumLength = 3)] //Longitud minima y maxima
        [Display(Name = "Contraseña ")] //Mensaje indicar obligatorio
        public string InputPassword { get; set; }
    }
}