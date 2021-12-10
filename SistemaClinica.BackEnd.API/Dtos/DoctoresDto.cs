using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaClinica.BackEnd.API.Dtos
{
    public class DoctoresDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(10, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]

        public string CedulaDoctor { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NombreDoctor { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string Telefono { get; set; }

        public bool Activo { get; set; }

    }
}
