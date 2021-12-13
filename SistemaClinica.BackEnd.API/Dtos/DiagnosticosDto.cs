using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaClinica.BackEnd.API.Dtos
{
    public class DiagnosticosDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public int IdDiagnostico { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string Diagnostico { get; set; }

        public bool Activo { get; set; }
    }
}
