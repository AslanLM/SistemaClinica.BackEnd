using System;

namespace SistemaClinica.BackEnd.API.Models
{
    public class Citas
	{
		public int IdCitas { get; set; }

		public DateTime FechaYHoraInicioCita { get; set; }

		public DateTime FechaYHoraFinCita { get; set; }

		public string CedulaDoctor { get; set; }

		public string PacienteDoctor { get; set; }

		public string IdConsultorio { get; set; }

		public int IdDiagnostico { get; set; }

		public decimal MontoDeConsulta { get; set; }

		public decimal MontoDeMedicamento { get; set; }


		public bool Activo { get; set; }

		public DateTime FechaCreacion { get; set; }

		public DateTime? FechaModificacion { get; set; }

		public string CreadoPor { get; set; }

		public string ModificadoPor { get; set; }

	}
}
