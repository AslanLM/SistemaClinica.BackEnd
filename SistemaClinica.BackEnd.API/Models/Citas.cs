using System;

namespace SistemaClinica.BackEnd.API.Models
{
    public class Citas
    {
        public int IdCita { get; set; }

        public DateTime FechaYHoraInicioCita { get; set; }

        public DateTime FechaYHoraFinCita { get; set; }

        public string CedulaDoctor { get; set; }

        public string CedulaPaciente { get; set; }

        public string IdConsultorio { get; set; }

        public int? IdDiagnostico { get; set; }

        public decimal? MontoDeConsulta { get; set; }

        public decimal? MontoDeMedicamentos { get; set; }

        public decimal? MontoTotal { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string CreadoPor { get; set; }

        public string ModificadoPor { get; set; }

    }
}
