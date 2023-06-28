using System.ComponentModel.DataAnnotations;

namespace TRABAJO_FINAL.Models
{
    public class LoginTemporal
    {
        [Required(ErrorMessage="El campo CORREO es obligatorio")]
        public string Correou { get; set; }

        [Required(ErrorMessage="El campo CONTRASEÑA es obligatorio")]
        public string Contraseñau { get; set; }
    }
}
