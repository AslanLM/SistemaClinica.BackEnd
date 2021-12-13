using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaClinica.BackEnd.API.Dtos
{
    public class MedicamentosDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [MaxLength(10, ErrorMessage = "{0} tiene que tener máximo {1} caracteres")]

        public string IdMedicamento { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string NombreMedicamento { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public int Precio { get; set; }

        public bool Activo { get; set; }

    }
}
