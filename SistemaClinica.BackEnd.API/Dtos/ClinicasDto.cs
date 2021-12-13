using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaClinica.BackEnd.API.Dtos
{
    public class ClinicasDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public int IdClinica { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NombreClinica { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string CedulaJuridica { get; set; }

        public bool Activo { get; set; }

    }
}
