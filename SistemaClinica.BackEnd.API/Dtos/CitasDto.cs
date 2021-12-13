using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaClinica.BackEnd.API.Dtos
{
    public class CitasDto
    {
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public int IdCita { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public DateTime FechaYHoraInicioCita { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public DateTime FechaYHoraFinCita { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string CedulaDoctor { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string CedulaPaciente { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public string IdConsultorio { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public int? IdDiagnostico { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public decimal? MontoDeConsulta { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public decimal? MontoDeMedicamentos { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        public decimal? MontoTotal { get; set; }
        public bool Activo { get; set; }

    }
}

